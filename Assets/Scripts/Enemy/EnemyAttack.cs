using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	[SerializeField]int enemyDamage = 25;
	PlayerHealth playerHealth;
	
    void Start()
	{
		playerHealth = FindObjectOfType<PlayerHealth>();
    }

	public void AttackPlayerEvent()
	{
		if(playerHealth == null){ return; }
		playerHealth.PlayerHit(enemyDamage);
	}
}
