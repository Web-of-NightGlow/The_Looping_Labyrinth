using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3;
    public float attackRange  = 2;
    public float attackCooldown = 2;
    public float playerDetectionRange = 5;
    public Transform detectionPoint;
    public LayerMask playerLayer;

    private float attackCooldownTimer;
    private EnemyState enemyState;
    private int facingDirection = 1;
    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (CompareTag("Boss") && BossMemory.Instance != null && BossMemory.Instance.hasData)
        {
            speed = BossMemory.Instance.savedSpeed;
        }

        ChangeState(EnemyState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayer();
        if(attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }

        if (enemyState == EnemyState.Chasing)
        {
           Chase();
        }
        else if(enemyState == EnemyState.Attacking)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }


    void Chase()
    {
        if(player.position.x < transform.position.x && facingDirection == 1 || player.position.x > transform.position.x && facingDirection == -1)
        {
            Flip();
        }
        Vector2 direction = (player.position - transform.position).normalized; 
        rb.linearVelocity = direction * speed;
    }


    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectionRange, playerLayer);
        
        if(hits.Length > 0)
        {
            player = hits[0].transform;

            //If the player is within attack range and the attack cooldown is ready, attack the player
            if(Vector2.Distance(transform.position, player.position) <= attackRange && attackCooldownTimer <= 0)
            {
            attackCooldownTimer = attackCooldown;
            ChangeState(EnemyState.Attacking); 
            }
            else if(Vector2.Distance(transform.position, player.position) > attackRange)
            {
                ChangeState(EnemyState.Chasing);
            }
        } 
        else
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }


    void ChangeState(EnemyState newState)
        {
            //Exit current animation
            if(enemyState == EnemyState.Idle)
            {anim.SetBool("isIdle", false);}
            else if(enemyState == EnemyState.Chasing)
            {anim.SetBool("isChasing", false);}
            else if(enemyState == EnemyState.Attacking)
            {anim.SetBool("isAttacking", false);}

            //Update current state
            enemyState = newState;

            if(enemyState == EnemyState.Chasing)
            {anim.SetBool("isChasing", true);}
            else if(enemyState == EnemyState.Idle)
            {anim.SetBool("isIdle", true);}
            else if(enemyState == EnemyState.Attacking)
            {anim.SetBool("isAttacking", true);}
        }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectionRange);
    }


    public enum EnemyState
    {
    Idle,
    Chasing,
    Attacking
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}