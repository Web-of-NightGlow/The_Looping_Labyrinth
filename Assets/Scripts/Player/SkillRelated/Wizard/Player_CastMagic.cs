using UnityEngine;

public class Player_CastMagic : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;
    public float castCooldown = 0.5f;
    public PlayerMovement playerMovement;
    
    private Vector2 aimDirection = Vector2.right;
    private float castTimer;

    public Animator anim;

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
            //FOR DIRECTIONAL SHOOTING IMPLEMENT LATER
            anim.SetFloat("aimX", aimDirection.x);
            anim.SetFloat("aimY", aimDirection.y);
        }
    }

    public void Shoot()
    {
        if(castTimer > 0)
        {
            fireball fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity).GetComponent<fireball>();
            fireball.direction = aimDirection;
            castTimer = castCooldown;
        }
        anim.SetBool("isShooting", false);
        playerMovement.isShooting = false;
    }
}
