using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public StatsUI statsUI;
    public PlayerHealth playerHealth;
    AudioManager audioManager;
    
    private float timer;

    [Header("Holy Armor")]
    public float holyArmorDuration = 2f;
    public float holyArmorCooldown = 5f;

    private float holyArmorTimer;
    private float holyArmorCooldownTimer;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ActivateHolyArmor();
        }

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (holyArmorCooldownTimer > 0)
        {
            holyArmorCooldownTimer -= Time.deltaTime;
        }

        if (holyArmorTimer > 0)
        {
            holyArmorTimer -= Time.deltaTime;

            if (holyArmorTimer <= 0)
            {
                DisableHolyArmor();
            }
        }
    }


    public void Attack()
    {
        if(timer <= 0)
        {
            audioManager.PlaySFX(audioManager.weaponSwingClip);
            anim.SetBool("isAttacking", true);

            timer = StatsManager.Instance.attackCooldown;
        }
    }


    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, StatsManager.Instance.weaponRange, enemyLayer);

        foreach (Collider2D hit in enemies)
        {
            EnemyHealth enemyHealth = hit.GetComponentInParent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.ChangeHealth(-(StatsManager.Instance.damage));
            }
        }
    }


    public void FinishAttack()
    {
        anim.SetBool("isAttacking", false);
    }


    public void ActivateHolyArmor()
    {
        if (holyArmorCooldownTimer > 0) return;

        anim.SetBool("isSecond", true); // your secondary animation
        Debug.Log("Holy Armor Activated!");

        playerHealth.isInvulnerable = true;
        holyArmorTimer = holyArmorDuration;
        holyArmorCooldownTimer = holyArmorCooldown;
    }


    void DisableHolyArmor()
    {
        playerHealth.isInvulnerable = false;
        anim.SetBool("isSecond", false);
    }
}
