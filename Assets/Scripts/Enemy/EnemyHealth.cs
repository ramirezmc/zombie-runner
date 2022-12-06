using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public bool isAlive = true;
	[SerializeField]int maxHitPoints = 100;
	Animator animator;
	int currentHitPoints;
	
	protected void Awake()
	{
		animator = GetComponent<Animator>();
	}
	
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
		else if(currentHitPoints < 1 && isAlive)
		{
			isAlive = false;
			animator.SetTrigger("death");
		}
	}
}
