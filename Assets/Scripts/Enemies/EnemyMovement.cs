using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    private EnemyState enemyState;
    private int facingDirection = 1;
    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState == EnemyState.Chasing)
        {
            if(player.position.x < transform.position.x && facingDirection == 1 || player.position.x > transform.position.x && facingDirection == -1)
            {
                Flip();
            }
            Vector2 direction = (player.position - transform.position).normalized; 
            rb.linearVelocity = direction * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(player == null)
            {
                player = collision.transform;
            }
            ChangeState(EnemyState.Chasing);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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

            //Update current state
            enemyState = newState;

            if(enemyState == EnemyState.Chasing)
            {anim.SetBool("isChasing", true);}
            else if(enemyState == EnemyState.Idle)
            {anim.SetBool("isIdle", true);}
        }


    public enum EnemyState
    {
    Idle,
    Chasing,
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}