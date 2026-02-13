using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float cooldown = 1f;
    public float weaponRange = 1f;
    public LayerMask enemyLayer;
    public int damage = 1;
    
    private float timer;

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }


    public void Attack()
    {
        if(timer <= 0)
        {
            anim.SetBool("isAttacking", true);

            timer = cooldown;
        }
    }


    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);

        foreach (Collider2D enemy in enemies)
        {
            if(enemy.isTrigger)
            {continue;}
        }
    }


    public void FinishAttack()
    {
        anim.SetBool("isAttacking", false);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
}
