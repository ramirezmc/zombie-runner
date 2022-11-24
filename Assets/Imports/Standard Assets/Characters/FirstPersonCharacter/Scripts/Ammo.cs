using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
	[SerializeField]int maxAmmo = 8;
	[SerializeField]float reloadTime = 1f;
	int currentAmmo;
	
	protected void Start()
	{
		currentAmmo = maxAmmo;
	}
	
	protected void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			Reload();
		}
	}
	
	public int ReturnCurrentAmmo()
	{
		return currentAmmo;
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
		StartCoroutine ("ReloadAmmo");
	}
	
	IEnumerator ReloadAmmo()
	{
		Debug.Log("I am reloading!");
		yield return new WaitForSeconds(reloadTime);
		Debug.Log("I have reloaded");
		currentAmmo = maxAmmo;
	}
}
