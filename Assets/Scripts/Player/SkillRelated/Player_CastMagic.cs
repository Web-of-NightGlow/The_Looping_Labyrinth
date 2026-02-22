using UnityEngine;

public class Player_CastMagic : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;
    public float castCooldown = 0.5f;
    
    private Vector2 aimDirection = Vector2.right;
    private float castTimer;

    // Update is called once per frame
    void Update()
    {
        castTimer -= Time.deltaTime;
        HandleAiming();

        if (Input.GetButtonDown("Fire1") && castTimer <= 0)
        {
            Shoot();
        }
    }

    private void HandleAiming()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            aimDirection = new Vector2(horizontal, vertical).normalized;
        }
    }

    public void Shoot()
    {
        fireball fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity).GetComponent<fireball>();
        fireball.direction = aimDirection;
        castTimer = castCooldown;
    }
}
