using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float _speed = 1.0f;
    [SerializeField]
    GameObject _Player;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        Movement();
        //if (Input.GetButtonDown(0))
        //{
        //    Vector3 mousePos = Input.mousePosition;
        //    {
        //        Debug.Log(mousePos.x);
        //        Debug.Log(mousePos.y);
        //    }
        //}
    }
    private void Movement()
    {
        if(Input.GetKey("a"))
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
            spriteRenderer.flipX = true;
            animator.SetBool("Walk", true);            
        }
        if (Input.GetKey("d"))
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
            spriteRenderer.flipX = false;
            animator.SetBool("Walk", true);
        }
        if (Input.GetKey("s"))
        {
            transform.position += Vector3.down * _speed * Time.deltaTime;
            animator.SetBool("Walk", true);
        }
        if (Input.GetKey("w"))
        {
            transform.position += Vector3.up * _speed * Time.deltaTime;
            animator.SetBool("Walk", true);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animator.SetBool("Walk", false);
        }

    }
}
