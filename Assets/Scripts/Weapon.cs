using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponZoom), typeof(Ammo))]
public class Weapon : MonoBehaviour
{
	[SerializeField]Camera FPCamera;
	[SerializeField]ParticleSystem MuzzleFlash;
	[SerializeField]GameObject hitVFX;
	
	
	[SerializeField]float gunRange = 100f;
	[SerializeField]int weaponDamage = 10;
	
	EnemyHealth enemyHealth;
	Ammo ammoSystem;
	int weaponCurrentAmmo = 0;
	
	protected void Awake()
	{
		enemyHealth = FindObjectOfType<EnemyHealth>();
		ammoSystem = GetComponent<Ammo>();
		
	}
	
    void Update()
    {
	    if (Input.GetButtonDown("Fire1"))
	    {
	    	Shoot();
	    }
    }
    
	void Shoot()
	{
		weaponCurrentAmmo = ammoSystem.ReturnCurrentAmmo();
		if (weaponCurrentAmmo > 0)
		{
			MuzzleFlash.Play();
			ammoSystem.DecreaseAmmo();
			ProcessRaycast();
		}
		else
		{
			ammoSystem.Reload();
		}
	}
	
	void ProcessRaycast()
	{
		RaycastHit hitInfo;
		if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hitInfo, gunRange))
		{
			if(hitInfo.transform.tag == "Enemy")
			{
				hitInfo.transform.GetComponent<EnemyHealth>().TakeDamage(weaponDamage);
			}
			else
			{
				CreateImpactVFX(hitInfo);
			}
		}
		else
		{
			return;
		}
	}
	
	void CreateImpactVFX(RaycastHit info)
	{
		GameObject impact = Instantiate(hitVFX, info.point, Quaternion.LookRotation(info.normal));
		Destroy(impact, 0.1f);
	}
}
