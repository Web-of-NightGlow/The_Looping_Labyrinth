using UnityEngine;

public class fireball: MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 direction = Vector2.right;
    public LayerMask enemyLayer;
    public LayerMask obstacleLayer;
    public SpriteRenderer sr;
    public Sprite buriedSprite;
    public StatsUI statsUI;
    public float lifeSpan = 2;
    public float speed;
    public float damageMultiplier = 2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = direction * speed;
        RotateFireball();
        Destroy(gameObject, lifeSpan);
    }

    private void RotateFireball()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((enemyLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            collision.gameObject.GetComponent<EnemyHealth>()?.ChangeHealth(-(int)(StatsManager.Instance.damage * damageMultiplier));
        }
        else if ((obstacleLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            AttachToTarget(collision.gameObject.transform);
        }
    }

    private void AttachToTarget(Transform target)
    {
        sr.sprite = buriedSprite;
        rb.linearVelocity = Vector2.zero;
        transform.SetParent(target);
    }
}
