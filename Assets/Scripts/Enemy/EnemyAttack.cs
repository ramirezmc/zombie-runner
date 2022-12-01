using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	[SerializeField]int enemyDamage = 25;
	EnemyHealth enemyHealth;
	PlayerHealth playerHealth;
	
    void Start()
	{
		enemyHealth = GetComponent<EnemyHealth>();
		playerHealth = FindObjectOfType<PlayerHealth>();
    }

	public void AttackPlayerEvent()
	{
		if (enemyHealth.isAlive)
		{
			if(playerHealth == null){ return; }
			playerHealth.PlayerHit(enemyDamage);
		}
		return;
	}
}
