using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int health = 2;
    int currentHealth;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform player;
    private float timeBtwShots;
    public float starTimeBtwShots;
    public GameObject proyectile;
    [SerializeField]
    private float range;
    bool StayFollow = true;
    [SerializeField]
    private Transform target;
    float enemyX = 10.0F;
    float enemyY = 10.0F;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = starTimeBtwShots;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if(Vector3.Distance(player.position,transform.position)<=range)
        {
            StayFollow = true;                      
        }        
        if (StayFollow == true)
        {
            animator.SetBool("FollowPlayer", true);
            FollowPlayer();
        }
        //FLIP
        if (target.position.x > this.transform.position.x)
        {
            this.transform.localScale = new Vector2(-enemyX, enemyY);
        }
        else
        {
            this.transform.localScale = new Vector2(enemyX, enemyY);
        }


    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Animacion de Muerte

        if(currentHealth<=0)
        {
            Die();
        }

    }
    void Die()
    {
        Debug.Log("Murio el Enemigo");
    }
    public void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = this.transform.position;
        }
         if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        if (timeBtwShots <= 0)
        {
            Instantiate(proyectile, transform.position, Quaternion.identity);
            timeBtwShots = starTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            health -= 1;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Score.score += 1;
                Destroy(gameObject);
            }
        }
    }


}
