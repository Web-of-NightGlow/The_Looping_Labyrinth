using UnityEngine;

public class Player_CastMagic : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;
    public PlayerMovement playerMovement;
    public Animator anim;
    AudioManager audioManager;

    public float primaryCooldown = 0.5f;
    public float secondaryCooldown = 1.2f;
    private float castTimer = 0f;

    private bool useSecondary = false;
    private Vector2 aimDirection = Vector2.right;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }



    void Update()
    {
        castTimer = Mathf.Max(0, castTimer - Time.deltaTime);
        HandleAiming();

        //PRIMARY
        if (Input.GetButtonDown("Fire1") && castTimer <= 0) //Set to K right now
        {
            playerMovement.isShooting = true;
            useSecondary = false;
            audioManager.PlaySFX(audioManager.fireballClip);

            anim.SetBool("isSecond", false);   // ensure secondary is off
            anim.SetBool("isShooting", true);  // play primary animation
        }

        //SECONDARY
        if (Input.GetButtonDown("Fire2") && castTimer <= 0) //Set to J right now
        {
            playerMovement.isShooting = true;
            useSecondary = true;
            audioManager.PlaySFX(audioManager.fireballClip);

            anim.SetBool("isShooting", false); // ensure primary is off
            anim.SetBool("isSecond", true);    // play secondary animation
        }

        //safety net reset
        if (playerMovement.isShooting && castTimer <= 0)
        {
            playerMovement.isShooting = false;
        }
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

        anim.SetBool("isShooting", false);
        anim.SetBool("isSecond", false);

        playerMovement.isShooting = false;

        useSecondary = false; // keep LAST
    }


    void ShootSpreadInternal()
    {
        float spreadAngle = 20f;

        SpawnFireball(aimDirection);
        SpawnFireball(RotateVector(aimDirection, -spreadAngle));
        SpawnFireball(RotateVector(aimDirection, spreadAngle));
    }

    void SpawnFireball(Vector2 direction)
    {
        fireball fb = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity)
                    .GetComponent<fireball>();

        fb.direction = direction.normalized;
        fb.damageMultiplier = useSecondary ? 1.5f : 1f;
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