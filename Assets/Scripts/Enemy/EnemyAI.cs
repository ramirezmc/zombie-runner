using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	
	[SerializeField]float chaseRange = 5f;
	[SerializeField]float turnSpeed = 10f;
	Transform target;
	bool isProvoked = false;
	
	NavMeshAgent navMeshAgent;
	float distanceToTarget = Mathf.Infinity;
	
	protected void Awake()
	{
		target = FindObjectOfType<PlayerHealth>().transform;
	}
	
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
		
		if (distanceToTarget <= chaseRange)
		{
			isProvoked = true;
		}
	}
	
	void EngageTarget()
	{
		FaceToTarget();
		if(distanceToTarget >= navMeshAgent.stoppingDistance)
		{
			ChaseTarget();
		}
		else if(distanceToTarget <= navMeshAgent.stoppingDistance)
		{
			AttackTarget();
		}
	}
	
	public void OnDamageTaken()
	{
		isProvoked = true;
	}
	
	void ChaseTarget()
	{
		GetComponent<Animator>().SetBool("isAttacking", false);
		GetComponent<Animator>().SetTrigger("Move");
		navMeshAgent.SetDestination(target.position);
	}
	
	void AttackTarget()
	{
		
		GetComponent<Animator>().SetBool("isAttacking", true);
	}
	
	void FaceToTarget()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
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
