using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public StatsUI statsUI;
    
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

            timer = StatsManager.Instance.attackCooldown;
        }
    }


    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, StatsManager.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<EnemyHealth>().ChangeHealth(-(StatsManager.Instance.damage));
        }
    }


    public void FinishAttack()
    {
        anim.SetBool("isAttacking", false);
    }
}
