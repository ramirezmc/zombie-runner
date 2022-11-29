using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	[SerializeField] int currentWeapon = 0;
	
	WeaponZoom weaponZoom;
	
	protected void Awake()
	{
		weaponZoom = GetComponentInChildren<WeaponZoom>();
	}
    void Update()
	{
		int previousWeapon = currentWeapon;
		
		ProcessKeyInput();
		ProcessScrollWheel();
		
		if (previousWeapon != currentWeapon)
		{
			ManageCurrentGun();
		}
    }
    
	void ManageCurrentGun()
	{
		int weaponIndex = 0;
		foreach (Transform weapon in transform)
		{
			if (weaponIndex == currentWeapon)
			{
				weapon.gameObject.SetActive(true);
			}
			else
			{
				weapon.gameObject.SetActive(false);
			}
			weaponIndex ++;
		}
	}
	
	void ProcessKeyInput()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			currentWeapon = 0;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			currentWeapon = 1;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			currentWeapon = 2;
		}
	}
	
	void ProcessScrollWheel()
	{
		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			if (currentWeapon >= transform.childCount - 1)
			{
				currentWeapon = 0;
			}
			else
			{
				currentWeapon++;
			}
		}
		else if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			if (currentWeapon <= 0)
			{
				currentWeapon = transform.childCount - 1;
			}
			else
			{
				currentWeapon--;
			}
		}
	}
}
