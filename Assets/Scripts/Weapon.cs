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
	[SerializeField]float fireRate = 1;
	[SerializeField]float reloadTime = 1f;
	
	[SerializeField]bool isFullAuto = false;
	
	
	EnemyHealth enemyHealth;
	Ammo ammo;
	
	bool canShoot = true;
	int weapCurrentAmmo ;
	int weapMaxAmmo;
	
	protected void Awake()
	{
		enemyHealth = FindObjectOfType<EnemyHealth>();
		ammo = GetComponent<Ammo>();
		
	}
	
    void Update()
    {
	    if (Input.GetButtonDown("Fire1") && canShoot == true)
	    {
	    	StartCoroutine(Shoot());
	    }
	    
	    if (Input.GetKeyDown(KeyCode.R) && canShoot == true)
	    {
	    	StartCoroutine(ReloadWeapon());
	    }
    }
	
	IEnumerator ReloadWeapon()
	{
		weapCurrentAmmo = ammo.ReturnCurrentAmmo();
		weapMaxAmmo = ammo.ReturnMaxAmmo();
		canShoot = false;
		if( weapCurrentAmmo < weapMaxAmmo)
		{
			ammo.Reload();
			Debug.Log("Im reloading!");
			yield return new WaitForSeconds(reloadTime);
			Debug.Log("I have reloaded");
			canShoot = true;
		}
		else
		{
			yield return new WaitForSeconds(0);
			canShoot = true;
		}
		
	}
	
	IEnumerator Shoot()
	{
		canShoot = false;
		if (ammo.ReturnCurrentAmmo() != 0)
		{
			MuzzleFlash.Play();
			ammo.DecreaseAmmo();
			ProcessRaycast();
			yield return new WaitForSeconds(fireRate);
			canShoot = true;
		}
		else
		{
			StartCoroutine(ReloadWeapon());
			canShoot = true;
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