using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField]Camera FPCamera;
	[SerializeField]ParticleSystem MuzzleFlash;
	[SerializeField]GameObject hitVFX;
	[SerializeField]float gunRange = 100f;
	[SerializeField]int weaponDamage = 10;
	
	EnemyHealth enemyHealth;
	
	protected void Awake()
	{
		enemyHealth = FindObjectOfType<EnemyHealth>();
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
		MuzzleFlash.Play();
		ProcessRaycast();
	}
	void ProcessRaycast()
	{
		RaycastHit hitInfo;
		if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hitInfo, gunRange))
		{
			if(hitInfo.transform.tag == "Enemy")
			{
				enemyHealth.TakeDamage(weaponDamage);
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
