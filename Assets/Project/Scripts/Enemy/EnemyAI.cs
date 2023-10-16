using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform targetTransform;

    NavMeshAgent navAgent;

    public LayerMask whatIsPlayer;

    //Patrolling
    public Transform walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    bool playerInSightRange, playerInAttackRange;

    bool disableMovements = false;

    void Awake()
    {
        if(!targetTransform)
        {
            targetTransform = GameObject.Find("Player").transform;
        }

        navAgent = GetComponent<NavMeshAgent>();
        navAgent.updateRotation = false;
        navAgent.updateUpAxis = false;
    }
    void OnEnable()
	{
		StaticEvents.Combat.OnPlayerDeath += DisableMovements;
        StaticEvents.Combat.OnEnemyDeath += DisableMovements;
	}
    void OnDisable()
	{
		StaticEvents.Combat.OnPlayerDeath -= DisableMovements;
        StaticEvents.Combat.OnEnemyDeath -= DisableMovements;
	}

    void SetTarget(Transform target)
    {
        targetTransform = target;
    }

    void FixedUpdate()
    {
        HandleStates();
    }

    void HandleStates()
    {
        if(disableMovements)
            return;

        playerInSightRange = Physics2D.OverlapCircle(transform.position, sightRange, whatIsPlayer) != null;
        playerInAttackRange = Physics2D.OverlapCircle(transform.position, attackRange, whatIsPlayer) != null;

        //if(!playerInSightRange && !playerInAttackRange) Patrolling();
        if(playerInSightRange && !playerInAttackRange) ChaseTarget();
        if(playerInSightRange && playerInAttackRange) TryAttackTarget();
    }


    public void DisableMovements(GameObject targetObject)
	{
        if(gameObject == targetObject)
            DisableMovements();
	}
    public void DisableMovements()
    {
        navAgent.SetDestination(transform.position);
        disableMovements = true;
    }
    public void EnableMovements() => disableMovements = false;

    void Patrolling()
    {
        if(!walkPointSet) SearchWalkPoint();

        if(walkPointSet) 
            navAgent.SetDestination(walkPoint.position);

        Vector3 distanceToWalkPoint = transform.position - walkPoint.position;

        //reach walkPoint
        if(distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomY = Random.Range(-walkPointRange, walkPointRange);

        walkPoint.position = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z);

        walkPointSet = true;
    }
    void ChaseTarget()
    {
        navAgent.SetDestination(targetTransform.position);
    }
    void TryAttackTarget()
    {
        navAgent.SetDestination(transform.position);
        //transform.LookAt(targetTransform);

        if(!alreadyAttacked)
        {
            alreadyAttacked = true;
            AttackTarget();
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    void AttackTarget()
    {
        Collider2D targetCollider2D = Physics2D.OverlapCircle(transform.position, attackRange, whatIsPlayer);

        if (targetCollider2D.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(25f);
        }
    }
    void ResetAttack()
    {
        alreadyAttacked = false;
    }


    void OnDrawGizmos()
    {
        DrawSightGizmos();
    }
    void OnDrawGizmosSelected()
    {
        //DrawSightGizmos();
    }
    void DrawSightGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}