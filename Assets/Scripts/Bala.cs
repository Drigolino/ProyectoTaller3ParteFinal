using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public int speed = 20;    
    public Rigidbody2D rb;
    public int tiempo=3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TiempoFlecha");
    }
    void Update()
    {
        rb.velocity = transform.right * speed;        
    }
    IEnumerator TiempoFlecha()
    {
        yield return new WaitForSeconds(tiempo);
        Destroy(gameObject);
    }
    

}
