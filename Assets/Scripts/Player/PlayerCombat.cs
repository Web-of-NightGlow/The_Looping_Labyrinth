using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public float cooldown = 1f;
    
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


    public void FinishAttack()
    {
        anim.SetBool("isAttacking", false);
    }
}
