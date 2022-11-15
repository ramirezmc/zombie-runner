using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	[SerializeField]Transform target;
	[SerializeField]float chaseRange = 5f;
	
	NavMeshAgent navMeshAgent;
	float distanceToTarget = Mathf.Infinity;
	
    void Start()
    {
	    navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
	{
		EnemyChase();
    }
    
	void EnemyChase()
	{
		//Follows the player if within range
		distanceToTarget = Vector3.Distance(target.position, transform.position);
		if (distanceToTarget <= chaseRange)
		{
			navMeshAgent.SetDestination(target.position);
		}
	}
	
	void OnDrawGizmosSelected()
	{
		//Shows chase range of enemy
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, chaseRange);
	}
}
