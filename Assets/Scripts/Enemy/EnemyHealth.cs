using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	[SerializeField]int maxHitPoints = 100;
	int currentHitPoints;
	
	protected void Start()
	{
		currentHitPoints = maxHitPoints;
	}
	
	public void TakeDamage(int damage)
	{
		if (currentHitPoints > 1)
		{
			BroadcastMessage("OnDamageTaken");
			currentHitPoints -= damage;
		}
		else
		{
			//Destroy(gameObject);
		}
	}
}
