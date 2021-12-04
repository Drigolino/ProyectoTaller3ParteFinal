using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss3 : MonoBehaviour
{
    //Idle
    [Header("Idel")]
    [SerializeField] float idelMoveSpeed;
    [SerializeField] Vector2 idelMoveDirection;
    //Ataque Arriba Abajo
    [Header("Ataque Arriba Abajo")]
    [SerializeField] float attackMoveSpeed;
    [SerializeField] Vector2 attackMoveDirection;
    //Ataque Player
    [Header("Ataque a Player")]
    [SerializeField] float attackPlayerSpeed;
    [SerializeField] Transform player;
    private Vector2 playerPosition;
    private bool hasPlayerPosition;

    //Other
    [Header("Orher")]
    [SerializeField] Transform groundCheckUp;
    [SerializeField] Transform groundCheckDown;
    [SerializeField] Transform groundCheckWall;    
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;
    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingWall;   
    private bool goingUp = true;
    private bool facingLeft = true;
    private Rigidbody2D enemyRB;
    private Animator animator;
    public int health = 120;
    public string sceneName;
    public Animator transitionAnim;
    public EnemyTres _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        idelMoveDirection.Normalize();
        attackMoveDirection.Normalize();
        enemyRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (_uiManager != null)
        {
            _uiManager.UpdateLivesBossTres(health);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_uiManager != null)
        {
            _uiManager.UpdateLivesBossTres(health);
        }
        isTouchingUp = Physics2D.OverlapCircle(groundCheckUp.position, groundCheckRadius, groundLayer);
        isTouchingDown = Physics2D.OverlapCircle(groundCheckDown.position, groundCheckRadius, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(groundCheckWall.position, groundCheckRadius, groundLayer);               
    }
    void randomStatePicker()
    {
        int randomState = Random.Range(0, 3);
        if(randomState==0)
        {
            //AtaqueArribaAbajo
            animator.SetTrigger("AtaqueArribaAbajo");

        }
        else if(randomState==1)
        {
            //ataquePlayer
            animator.SetTrigger("AtaqueAPlayer");
        }
    }
    public void TakeDamage(int damage)
    {       

        
            health -= 2;
        
        //Animacion de Muerte



    }

    public void IdelState()
    {
        if(isTouchingUp&&goingUp)
        {
            ChangeDirection();
        }
        else if(isTouchingDown&&!goingUp)
        {
            ChangeDirection();
        }
        if(isTouchingWall)
        {
            if(facingLeft)
            {
                Flip();
            }
            else if(!facingLeft)
            {
                Flip();
            }
        }
        enemyRB.velocity = idelMoveSpeed * idelMoveDirection;
    }
    public void AttackUpDown()
    {
        if (isTouchingUp && goingUp)
        {
            ChangeDirection();
        }
        else if (isTouchingDown && !goingUp)
        {
            ChangeDirection();
        }
        if (isTouchingWall)
        {
            if (facingLeft)
            {
                Flip();
            }
            else if (!facingLeft)
            {
                Flip();
            }
        }
        enemyRB.velocity = attackMoveSpeed * attackMoveDirection;
    }

    public void AttackPlayer()
    {
        if(!hasPlayerPosition)
        {
            //Player Posicion
            playerPosition = player.position - transform.position;
            //normalize Player Position
            playerPosition.Normalize();
            hasPlayerPosition = true;           
        }
        if(hasPlayerPosition)
        {
            //Atacar posicion de Player
            enemyRB.velocity = playerPosition * attackPlayerSpeed;
        }
        if(isTouchingWall||isTouchingDown)
        {
            
            enemyRB.velocity = Vector2.zero;
            hasPlayerPosition = false;
            //AnimacionChoque
            animator.SetTrigger("ChoqueParedes");
            
        }
        
    }

    void FlipTowardsPlayer()
    {
        float playerDirection = player.position.x - transform.position.x;
        if(playerDirection>0&&facingLeft)
        {
            Flip();
        }
        else if(playerDirection<0&& !facingLeft)
        {
            Flip();
        }
    }


    void ChangeDirection()
    {
        goingUp = !goingUp;
        idelMoveDirection.y *= -1;
        attackMoveDirection.y *= -1;
    }
    void Flip()
    {
        facingLeft = !facingLeft;
        idelMoveDirection.x *= -1;
        attackMoveDirection.x *= -1;
        transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(groundCheckUp.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckDown.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckWall.position, groundCheckRadius);       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            health -= 1;
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
