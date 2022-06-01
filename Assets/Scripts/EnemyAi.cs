
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Soldier))]

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    [SerializeField] Transform enemy;

    public LayerMask whatIsGround;
    private LayerMask whatIsEnemy;
    private Soldier soldier;
    
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        soldier = GetComponent<Soldier>();
        soldier.EquipGun(soldier.gun);
        whatIsEnemy = soldier.enemyLayer;
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsEnemy);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(enemy.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        transform.LookAt(enemy);

        Vector3 muzzlePosition = soldier.gun.muzzle.position;
        Vector3 playerPosition = enemy.position;
        Vector3 direction = (playerPosition - muzzlePosition).normalized;
        float distance = Vector3.Distance(muzzlePosition, playerPosition);
        bool hitMap = Physics.Raycast(muzzlePosition, direction, distance, whatIsGround);
        Debug.DrawRay(muzzlePosition, direction);
        if (soldier.gun.State != Gun.GunState.Shooting && !hitMap)
        {
            //Attack code here
            soldier.gun.ShootAt(enemy);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
