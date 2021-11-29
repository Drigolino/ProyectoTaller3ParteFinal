using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;
    public Boss2 Boss;
    public GameObject move;
    [SerializeField]
    private float _fireRate = 0.45f;
    private float _canFire = 0.0f;
    private void Start()
    {
        animator.GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }
    }
    void Attack()
    {
        
        if (Time.time > _canFire)
        {
            //Rango de ataque
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.gameObject.CompareTag("Boss"))//1
                {
                    //  Boss.TakeDamage(attackDamage);
                    enemy.gameObject.GetComponent<Boss2>().TakeDamage(attackDamage);

                }
                if (enemy.gameObject.CompareTag("Boss2"))//2
                {
                    //  Boss.TakeDamage(attackDamage);
                    enemy.gameObject.GetComponent<Boss2>().TakeDamage(attackDamage);

                }
                if (enemy.gameObject.CompareTag("Boss3"))//3
                {
                    //  Boss.TakeDamage(attackDamage);
                    enemy.gameObject.GetComponent<Boss2>().TakeDamage(attackDamage);

                }

                else if (enemy.gameObject.CompareTag("Enemy"))//minionsDamage

                {
                    //  Debug.Log("enemigo atacado");
                    enemy.gameObject.GetComponent<Enemy>().TakeDamage(attackDamage);
                }
                //  GetComponent<Boss2>().TakeDamage(attackDamage);

            }
            _canFire = Time.time + _fireRate;
            animator.SetTrigger("Attack");
        }
        


        //Daño enemigos
        //  Debug.Log(":"+hitEnemies.Length);
        

    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
