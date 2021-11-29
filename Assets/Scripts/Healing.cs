using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healing : MonoBehaviour
{
    public float cantidad;
    public float damageTime;
    float currenteDamageTime;
    [SerializeField]
    PlayerMovement vida;
    void Start()
    {
        vida = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    
    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.tag=="Player")
        {
            currenteDamageTime += Time.deltaTime;
            if (currenteDamageTime>damageTime)
            {
                if (vida.health < 100)
                {
                    vida.health += cantidad;
                }
                collision.GetComponent<VidaPlayer>().lives+=cantidad;
                currenteDamageTime = 0.0f;
                StartCoroutine(Destrucobject());
            }
        }
    }
    IEnumerator Destrucobject()
    {
        Destroy(gameObject);

        yield return new WaitForSeconds(0.01f);
        
    }
}
