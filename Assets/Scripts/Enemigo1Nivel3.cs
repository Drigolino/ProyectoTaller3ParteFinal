using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1Nivel3 : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    private Transform target;
    [SerializeField]
    public float stopingDistance;
    [SerializeField]
    private float range;
    bool StayFollow = false;
    [SerializeField]
    int health = 2;
    float enemyX = 7.0F;
    float enemyY = 7.0F;
    public Animator animator;
    //SpriteRenderer spriteRender;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= range)
        {
            StayFollow = true;
        }
        if (StayFollow == true)
        {
            animator.SetBool("Enemigo1Nivel3", true);
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
    public void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, target.position) > stopingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            Debug.Log("dañoPlayer");
            health -= 1;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Score.score += 1;
                Destroy(gameObject);
            }
        }

    }
    public void TakeDamage(int damage)
    {


        //if (health > 0)
        {
            Score.score += 1;
            Destroy(gameObject);

        }
        //Animacion de Muerte



    }
}
