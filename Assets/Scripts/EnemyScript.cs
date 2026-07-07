using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public enum State { Patrol, Chase, Attack }
    public State currentState = State.Patrol;
    public GameObject playerObject;

    [Header("References")]
    public Transform[] patrolPoints;
    public Transform player;

    [Header("Settings")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float chaseDistance = 8f;
    public float attackDistance = 1.5f;
    public float attackCooldown = 1f;

    [Header("State Materials")]
    public Material patrolMaterial;
    public Material chaseMaterial;
    public Material attackMaterial;

    private Renderer rend;
    private int patrolIndex = 0;
    private float attackTimer = 0f;

    [SerializeField] private int damage = 1;

    private PlayerStats playerStats;

    public int EnemyHealth;
    public int MaxEnemyHealth = 3;



    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = patrolMaterial;
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerStats = player.GetComponent<PlayerStats>();
        }
        else
        {
            Debug.LogError("Player object not found in the scene.");
        }

        EnemyHealth = MaxEnemyHealth;
    }

   

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;

            case State.Chase:
                Chase();
                break;

            case State.Attack:
                Attack();
                break;
        }

        attackTimer -= Time.deltaTime;

        if (EnemyHealth <= 0)
        {
            Debug.Log("Enemy is dead");
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int amount)
    {
        EnemyHealth -= amount;
        Debug.Log("Enemy took damage! Current health: " + EnemyHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {

            TakeDamage(1);
        }
    }

    // -------- PATROL -------- //
    void Patrol()
    {
        rend.material = patrolMaterial;

        Transform point = patrolPoints[patrolIndex];
        MoveTowards(point.position, patrolSpeed);

        if (Vector3.Distance(transform.position, point.position) < 0.3f)
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;

        if (Vector3.Distance(transform.position, player.position) < chaseDistance)
            currentState = State.Chase;
    }

    // -------- CHASE -------- //
    void Chase()
    {
        rend.material = chaseMaterial;

        MoveTowards(player.position, chaseSpeed);

        float dist = Vector3.Distance(transform.position, player.position);

        if (dist > chaseDistance + 2f)
            currentState = State.Patrol;

        if (dist < attackDistance)
            currentState = State.Attack;
    }

    // -------- ATTACK -------- //
    void Attack()
    {
        rend.material = attackMaterial;

        transform.LookAt(player);
        float dist = Vector3.Distance(transform.position, player.position);

        if (dist > attackDistance)
        {
            currentState = State.Chase;
            return;
        }

        if (attackTimer <= 0f)
        {
            Debug.Log("Enemy attacked the player!");
            attackTimer = attackCooldown;

            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }
            else
            {
                Debug.LogError("PlayerStats component not found on the player.");
            }

        }

        
    }

    // -------- MOVEMENT -------- //
    void MoveTowards(Vector3 target, float speed)
    {
        Vector3 dir = (target - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
        transform.LookAt(target);
    }

    // -------- GIZMOS -------- //
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}

