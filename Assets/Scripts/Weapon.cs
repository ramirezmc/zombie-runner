using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField]Camera FPCamera;
	[SerializeField]float gunRange = 100f;
	[SerializeField]int weaponDamage = 10;
	
	EnemyHealth enemyHealth;
	
	protected void Awake()
	{
		enemyHealth = FindObjectOfType<EnemyHealth>();
	}
	
    void Update()
    {
	    if (Input.GetButton("Fire1"))
	    {
	    	Shoot();
	    }
    }
    
	void Shoot()
	{
		RaycastHit hitInfo;
		if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hitInfo, gunRange))
		{
			//add vfx here
			if(hitInfo.transform.tag == "Enemy")
			{
				enemyHealth.TakeDamage(weaponDamage);
				Debug.Log("I have hit " + hitInfo.transform.name);
			}
			
			
		}
		else
		{
			return;
		}
	}
}
