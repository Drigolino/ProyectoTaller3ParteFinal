using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Boss2 : MonoBehaviour
{
    Gun[] guns;
    public Transform attackPoint;
    public float attackRange = 2.5f;
    public LayerMask PlayerLayers;



    [SerializeField]
    int health = 100;
    int attackDamage = 2;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform player;
    private float timeBtwShots;
    public float starTimeBtwShots;
    public GameObject proyectile;
    [SerializeField]
    private float range;
    //bool StayFollow = false;
    public bool shieldsActive=false;
    [SerializeField]
    private GameObject shieldGameobject;
    
    public int timeShoot = 0;
    [SerializeField]
   // float velocidad = 0;

    Vector2 dir_x = Vector2.right;
    Vector2 dir_y = Vector2.up;
    //[SerializeField]
    //bool movimiento_x = false, movimiento_y = false;

    SpriteRenderer flip;
    [SerializeField]
    Transform[] posiciones;
    int index;
    [SerializeField]
    float minDistance;
    Quaternion rot;
    public Animator transitionAnim;
    public string sceneName;
    public VidaEnemy _uiManager;

    //bool StayFollow = false;
    public float time = 0.2f;
    float timeAux = 0.2f;
    bool cambiarEscena = false;

    void Start()
    {
        //currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = starTimeBtwShots;
        guns = transform.GetComponentsInChildren<Gun>();

        if (_uiManager != null)
        {
            _uiManager.UpdateLivesBoss(health);
        }
        timeAux = time;
    }
    void Update()
    {
        if (_uiManager != null)
        {
            _uiManager.UpdateLivesBoss(health);
        }

        if (Vector3.Distance(player.position, transform.position) > range)
        {           
            if (timeBtwShots <= 0)
            {
                Instantiate(proyectile, transform.position, Quaternion.identity);               
                //StayFollow = true;
                timeBtwShots = starTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;                
            }
        } 
        if (Vector3.Distance(player.position, transform.position) < range)
        {          
            
                FollowPlayer();
            if(Vector3.Distance(player.position, transform.position) < stoppingDistance)
            {
                time -= Time.deltaTime;
                if(time<=0)
                {
                    attackPlayer();
                    time = timeAux;
                }
                
            }
                

        }

        //if (health <= 10)
        //{
        //    Die();
        //}

        //if (Vector3.Distance(player.position, transform.position) <= range)
        //{
        //    StayFollow = true;
        //}
       



    }
    public void TakeDamage(int damage)
    {
        if (health<=50 )
        {
            shieldsActive = true;
        }
        if (shieldsActive == true)
        {
            shieldGameobject.SetActive(true);

            StartCoroutine(TimeShield());
        }

        if (health > 0 && shieldsActive == false)
        {
            health -= damage;
        }
        //Animacion de Muerte



    }
    IEnumerator TimeShield()
    {
        yield return new WaitForSeconds(1.0f);

        shieldsActive = false;
        shieldGameobject.SetActive(false);

    }
    void Die()
    {
        Destroy(gameObject);

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
       

    }
    public void attackPlayer() 
    {
        Debug.Log("PlayerA");
        //AnimacionAtaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, PlayerLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.CompareTag("Player"))
            {
                //  Boss.TakeDamage(attackDamage);               
                enemy.gameObject.GetComponent<PlayerMovement>().TakeDamage(attackDamage);

            }

           

        }
    }
    //public void Patrullaje()
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, posiciones[index].position, velocidad * Time.deltaTime);
    //    if (Vector2.Distance(transform.position, posiciones[index].position) < minDistance)
    //    {
    //        index++;
    //        if (index == posiciones.Length)
    //        {
    //            index = 0;
    //        }
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            health -= 1;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(collision.gameObject);
                cambiarEscena = true;
                if(cambiarEscena==true)
                {
                    SceneManager.LoadScene(sceneName);
                    StartCoroutine(LoadScene());
                }
                
                
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
