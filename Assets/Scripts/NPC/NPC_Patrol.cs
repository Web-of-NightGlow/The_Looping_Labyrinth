using System.Collections;
using UnityEngine;

public class NPC_Patrol : MonoBehaviour
{
    public Vector2[] patrolPoints;
    public float speed = 2f;
    public float waitTime = 1.5f;

    private bool isWaiting = false;
    private Vector2 target;
    private Rigidbody2D rb;
    private Animator animator;
    private int currentPatrolIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        StartCoroutine(SetPatrolPoint());
    }

    // Update is called once per frame
    void Update()
    {
        if(isWaiting)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 direction = ((Vector3)target - transform.position).normalized;
        if(direction.x < 0 && transform.localScale.x > 0 || direction.x > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        rb.linearVelocity = direction*speed;

        if(Vector2.Distance(transform.position, target) < 0.1f)
        {
            StartCoroutine(SetPatrolPoint());
        }
    }

    IEnumerator SetPatrolPoint()
    {
        isWaiting = true;
        animator.Play("Idle");
        yield return new WaitForSeconds(waitTime);

        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        target = patrolPoints[currentPatrolIndex];
        isWaiting = false;
        animator.Play("Walk");
    }
}
