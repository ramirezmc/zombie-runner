using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
	[SerializeField]int maxAmmo = 8;
	int currentAmmo;
	
	protected void Start()
	{
		currentAmmo = maxAmmo;
	}
	
	public int ReturnCurrentAmmo()
	{
		return currentAmmo;
	}
	
	public int ReturnMaxAmmo()
	{
		return maxAmmo;
	}
	
	public void DecreaseAmmo()
	{
		if (currentAmmo > 0)
		{
			currentAmmo -= 1;
			return;
		}
	}
	
	public void Reload()
	{
		currentAmmo = maxAmmo;
	}
}
