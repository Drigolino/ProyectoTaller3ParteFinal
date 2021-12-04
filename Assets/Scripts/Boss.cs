using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    Gun[] guns;

    [SerializeField]
    int health = 100;
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
    //bool StayFollow = false;
    public GameObject firePoint1;
    public GameObject firePoint2;
    public GameObject firePoint3;
    public int timeShoot = 0;
    [SerializeField]
    float velocidad = 0;

    Vector2 dir_x = Vector2.right;
    Vector2 dir_y = Vector2.up;
    [SerializeField]
    //bool movimiento_x = false, movimiento_y = false;

    SpriteRenderer flip;
    [SerializeField]
    Transform[] posiciones;
    int index;
    [SerializeField]
    float minDistance;
    Quaternion rot;
    bool disparoArea = true;
    public Animator transitionAnim;
    public string sceneName;
    public VidaEnemyUno _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = starTimeBtwShots;
        guns = transform.GetComponentsInChildren<Gun>();

        if (_uiManager != null)
        {
            _uiManager.UpdateLivesBossUno(health);
        }
    }
    void Update()
    {
        if (_uiManager != null)
        {
            _uiManager.UpdateLivesBossUno(health);
        }
        if (Vector3.Distance(player.position, transform.position) <= range)
        {
            FollowPlayer();
        }
        if (Vector3.Distance(player.position, transform.position) >= range)
        {
            Patrullaje();
            //disparoArea = false;
        }
        if (disparoArea == true)
        {
            timeShoot += 1;
            if (timeShoot == 1)
            {
                timeShoot -= 300;
                foreach (Gun gun in guns)
                {
                    gun.Shoot();
                }
            }
        }


    }
    public void TakeDamage(int damage)
    {
        health -= 2;

        //Animacion de Muerte        
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

        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        if (timeBtwShots <= 0)
        {
            Instantiate(proyectile, firePoint1.transform.position, Quaternion.identity);
            Instantiate(proyectile, firePoint2.transform.position, Quaternion.identity);
            Instantiate(proyectile, firePoint3.transform.position, Quaternion.identity);

            timeBtwShots = starTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
    public void Patrullaje()
    {
        transform.position = Vector3.MoveTowards(transform.position, posiciones[index].position, velocidad * Time.deltaTime);
        if (Vector2.Distance(transform.position, posiciones[index].position) < minDistance)
        {
            index++;
            if (index == posiciones.Length)
            {
                index = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            health -= 50;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                SceneManager.LoadScene(sceneName);
                StartCoroutine(LoadScene());
            }
        }
    }
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
