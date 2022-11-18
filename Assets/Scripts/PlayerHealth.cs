using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField]int maxPlayerHitPoints = 100;
	int currentPlayerHitPoints;
	
	protected void Start()
	{
		currentPlayerHitPoints = maxPlayerHitPoints;
	}
	
	public void PlayerHit(int damageTook)
	{
		if (currentPlayerHitPoints <= 0)
		{
			Debug.Log("You died lmao");
		}
		currentPlayerHitPoints -= damageTook;
		Debug.Log(currentPlayerHitPoints);
	}
	
	public int ReturnCurrentHealth()
	{
		return currentPlayerHitPoints;
	}
}
