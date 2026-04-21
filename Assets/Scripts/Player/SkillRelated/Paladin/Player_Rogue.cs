using UnityEngine;

public class Player_Rogue : MonoBehaviour
{
    [Header("References")]
    public Animator anim;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public PlayerMovement playerMovement;
    public PlayerHealth playerHealth;

    [Header("Primary Attack")]
    private float attackTimer;

    [Header("Shadow Step")]
    public float dashDistance = 4f;
    public float dashCooldown = 2f;
    private float dashTimer;

    private Vector2 aimDirection = Vector2.right;

    void Update()
    {
        HandleTimers();
        HandleAiming();

        //PRIMARY ATTACK
        if (Input.GetButtonDown("Slash") && attackTimer <= 0)
        {
            anim.SetBool("isAttacking", true);
            attackTimer = StatsManager.Instance.attackCooldown;
        }

        //SHADOW STEP (Secondary)
        if (Input.GetButtonDown("Fire2") && dashTimer <= 0)
        {
            playerMovement.isShooting = true; // lock movement during animation
            anim.SetBool("isSecond", true);
            dashTimer = dashCooldown;
        }
    }

    void HandleTimers()
    {
        attackTimer = Mathf.Max(0, attackTimer - Time.deltaTime);
        dashTimer = Mathf.Max(0, dashTimer - Time.deltaTime);
    }

    void HandleAiming()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            aimDirection = new Vector2(horizontal, vertical).normalized;
            anim.SetFloat("aimX", aimDirection.x);
            anim.SetFloat("aimY", aimDirection.y);
        }
    }

    // Called by animation event
    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(
            attackPoint.position,
            StatsManager.Instance.weaponRange,
            enemyLayer
        );

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<EnemyHealth>()
                ?.ChangeHealth(-(StatsManager.Instance.damage));
        }
    }

    public void FinishAttack()
    {
        anim.SetBool("isAttacking", false);
    }

    // Called by animation event
    public void PerformShadowStep()
    {
        playerHealth.isInvulnerable = true;
        Vector3 targetPosition = transform.position + (Vector3)(aimDirection * dashDistance);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, aimDirection, dashDistance, LayerMask.GetMask("Obstacle"));

        if (hit)
        {
            transform.position = hit.point - (Vector2)aimDirection * 0.5f;
        }
        else
        {
            transform.position = targetPosition;
        }
        Invoke(nameof(DisableInvulnerability), 0.3f);

        anim.SetBool("isSecond", false);
        playerMovement.isShooting = false;
    }


    void DisableInvulnerability()
    {
        playerHealth.isInvulnerable = false;
    }
}