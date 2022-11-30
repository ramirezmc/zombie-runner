using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
	[SerializeField]AmmoSlot[] ammoSlots;
	
	int currentAmmo;
	
	[System.Serializable]
	private class AmmoSlot
	{
		public AmmoType ammoType;
		public int magazineSize;
		public int ammoReserve;
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
	
	public void MagazineSize(AmmoType ammoType)
	{
		currentAmmo = GetAmmoSlot(ammoType).magazineSize;
	}
	
	public int ReturnCurrentAmmo()
	{
		return currentAmmo;
	}
	
	public int ReturnMagazineSize(AmmoType ammoType)
	{
		return GetAmmoSlot(ammoType).magazineSize;
	}
	
	public int ReturnAmmoReserve(AmmoType ammoType)
	{
		return GetAmmoSlot(ammoType).ammoReserve;
	}
	
	public void AddReserveAmmo(AmmoType ammoType, int ammoAmmount)
	{
		GetAmmoSlot(ammoType).ammoReserve += ammoAmmount;
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
		if(GetAmmoSlot(ammoType).magazineSize < GetAmmoSlot(ammoType).ammoReserve)
		{
			currentAmmo = GetAmmoSlot(ammoType).magazineSize;
			GetAmmoSlot(ammoType).ammoReserve -= GetAmmoSlot(ammoType).magazineSize;
			return;
		}
		else if (GetAmmoSlot(ammoType).magazineSize > GetAmmoSlot(ammoType).ammoReserve)
		{
			currentAmmo = GetAmmoSlot(ammoType).ammoReserve;
			GetAmmoSlot(ammoType).ammoReserve -= GetAmmoSlot(ammoType).ammoReserve;
			return;
		}
	}
}
