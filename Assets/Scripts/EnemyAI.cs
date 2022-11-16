﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	[SerializeField]Transform target;
	[SerializeField]float chaseRange = 5f;
	bool isProvoked = false;
	
	NavMeshAgent navMeshAgent;
	float distanceToTarget = Mathf.Infinity;
	
    void Start()
    {
	    navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
	{
		EnemyChaseRange();
    }
    
	void EnemyChaseRange()
	{
		
		distanceToTarget = Vector3.Distance(target.position, transform.position);
		if (isProvoked)
		{
			EngageTarget();
		}
		else if (distanceToTarget <= chaseRange)
		{
			isProvoked = true;
		}
	}
	
	void EngageTarget()
	{
		if(distanceToTarget >= navMeshAgent.stoppingDistance)
		{
			ChaseTarget();
		}
		
		if(distanceToTarget <= navMeshAgent.stoppingDistance)
		{
			AttackTarget();
		}
	}
	
	void ChaseTarget()
	{
		navMeshAgent.SetDestination(target.position);
	}
	
	void AttackTarget()
	{
		Debug.Log("I am hitting player");
	}
	
	void OnDrawGizmosSelected()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		//Shows chase range of enemy
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, chaseRange);
		Gizmos.DrawWireSphere(transform.position, navMeshAgent.stoppingDistance);
	}
}
