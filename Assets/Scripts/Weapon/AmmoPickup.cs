using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
	[SerializeField]int ammoAmount = 4;
	[SerializeField]AmmoType ammoType;
	Ammo ammo;
	
	protected void Awake()
	{
		ammo = FindObjectOfType<Ammo>();
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			Debug.Log("I have been picked up");
			ammo.AddReserveAmmo(ammoType, ammoAmount);
			Destroy(gameObject);
		}
	}
	
}
