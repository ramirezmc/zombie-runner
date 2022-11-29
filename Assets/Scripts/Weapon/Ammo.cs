using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
	[SerializeField]AmmoSlot[] ammoSlots;
	
	int currentAmmo;
	int maxAmmo;
	
	[System.Serializable]
	private class AmmoSlot
	{
		public AmmoType ammoType;
		public int maxAmmoAmount;
	}
	
	private AmmoSlot GetAmmoSlot(AmmoType ammoType)
	{
		foreach(AmmoSlot slot in ammoSlots)
		{
			if (slot.ammoType == ammoType)
			{
				return slot;
			}
		}
		return null;
	}
	
	public void MaxWeapAmmo(AmmoType ammoType)
	{
		currentAmmo = GetAmmoSlot(ammoType).maxAmmoAmount;
	}
	
	public int ReturnCurrentAmmo()
	{
		return currentAmmo;
	}
	
	public int ReturnMaxAmmo(AmmoType ammoType)
	{
		return GetAmmoSlot(ammoType).maxAmmoAmount;
	}
	
	public void DecreaseAmmo()
	{
		if (currentAmmo > 0)
		{
			currentAmmo -= 1;
			return;
		}
	}
	
	public void Reload(AmmoType ammoType)
	{
		currentAmmo = GetAmmoSlot(ammoType).maxAmmoAmount;
	}
}
