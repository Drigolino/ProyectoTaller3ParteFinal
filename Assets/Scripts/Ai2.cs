using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Accessibility;


public class Ai2 : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    private Transform target;
    [SerializeField]
    public float stopingDistance;
    [SerializeField]
    private float range;
    bool StayFollow = true;
    [SerializeField]
    int health = 2;
    float enemyX = 1.0F;
    float enemyY = 1.0F;
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
    public void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, target.position) > stopingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);           
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Bala")
        {
            health -= 1;
            Destroy(collision.gameObject);
            if(health<=0)
            {
                Score.score += 1;
                Destroy(gameObject);
            }
        }
       
    }
    public void TakeDamage(int damage)
    {


        {
            Score.score += 1;
            Destroy(gameObject);

        }
        //Animacion de Muerte



    }

}
