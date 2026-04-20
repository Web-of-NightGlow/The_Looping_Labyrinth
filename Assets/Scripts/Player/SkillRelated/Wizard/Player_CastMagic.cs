using UnityEngine;

public class Player_CastMagic : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;
    public PlayerMovement playerMovement;
    public Animator anim;
    public float primaryCooldown = 0.5f;
    public float secondaryCooldown = 1.2f;
    public float castTimer = 0f;
    private bool useSecondary = false;

    private float primaryTimer;
    private float secondaryTimer;
    private Vector2 aimDirection = Vector2.right;

    // Update is called once per frame
    void Update()
    {
        castTimer -= Time.deltaTime;
        HandleAiming();

        if (Input.GetButtonDown("Fire1") && castTimer <= 0)
        {
            playerMovement.isShooting = true;
            anim.SetBool("isShooting", true);
        }

        if (Input.GetButtonDown("Fire2") && castTimer <= 0)
        {
            playerMovement.isShooting = true;
            anim.SetBool("isShooting", true);

            useSecondary = true; // 👈 NEW FLAG
        }
    }


    private void OnEnable()
    {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(1, 1);
    }

    private void OnDisable()
    {
        anim.SetLayerWeight(0, 1);
        anim.SetLayerWeight(1, 0);
    }


    private void HandleAiming()
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


    public void Shoot()
    {
        if (useSecondary)
        {
            ShootSpreadInternal();
            castTimer = secondaryCooldown;
        }
        else
        {
            SpawnFireball(aimDirection);
            castTimer = primaryCooldown;
        }

        useSecondary = false;

        anim.SetBool("isShooting", false);
        playerMovement.isShooting = false;
    }


    void ShootSpreadInternal()
    {
        float spreadAngle = 20f;

        SpawnFireball(aimDirection);
        SpawnFireball(RotateVector(aimDirection, -spreadAngle));
        SpawnFireball(RotateVector(aimDirection, spreadAngle));

        anim.SetBool("isShooting", false);
        playerMovement.isShooting = false;
    }


    void SpawnFireball(Vector2 direction)
    {
        fireball fb = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity)
                    .GetComponent<fireball>();

        fb.direction = direction.normalized;
        fb.damageMultiplier = 1.5f;
    }

    Vector2 RotateVector(Vector2 v, float degrees)
    {
        float rad = degrees * Mathf.Deg2Rad;
        float sin = Mathf.Sin(rad);
        float cos = Mathf.Cos(rad);

        return new Vector2(
            cos * v.x - sin * v.y,
            sin * v.x + cos * v.y
        );
    }
}
