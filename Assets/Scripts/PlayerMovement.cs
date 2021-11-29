using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    SpriteRenderer spriteRender;
    Vector2 movement;
    [SerializeField]
    public float health = 100f;
    public GameObject attackPoint;
    public VidaPlayer _uiManager;
    public GameObject boss3;
    public GameObject boss2;
    public GameObject boss1;
    //bool damagePlayer = false;    

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        _uiManager = GameObject.Find("Player").GetComponent<VidaPlayer>();
        if (_uiManager != null)
        {
            _uiManager.UpdateLives(health);
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0)
        {
            attackPoint.transform.localPosition = new Vector3
           (movement.x < 0 ? -1.45f : 1.45f, attackPoint.transform.localPosition.y, attackPoint.transform.localPosition.z);
            spriteRender.flipX = movement.x <= 0;

        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position+movement*moveSpeed*Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletEnemy")
        {
            health -= 10;
            animator.SetTrigger("DamagePlayer");

            Destroy(collision.gameObject);
            if (health <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }

        }
        if (collision.gameObject.tag == "Trampa")
        {            
            health -= 10;
            Debug.Log("MenosVida");
            animator.SetTrigger("DamagePlayer");
        }
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 10;
            animator.SetTrigger("DamagePlayer");
            if (health <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        if (collision.gameObject.tag == "ActivaBoss3")
        {
            boss3.SetActive(true);
        }
        if (collision.gameObject.tag == "ActivaBoss2")
        {
            boss2.SetActive(true);
        }
        if (collision.gameObject.tag == "ActBoss1")
        {
            boss1.SetActive(true);
        }

        _uiManager.UpdateLives(health);       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Trampa")
        {
            health -= 10;
            
            

        }
        _uiManager.UpdateLives(health);
    }
    public void DesactivarDamage()
    {
        animator.ResetTrigger("DamagePlayer");
    }
    public void TakeDamage(int damage)
    {


        if (health > 0)
        {
            health -= damage;
        }
        //Animacion de Muerte



    }

}
