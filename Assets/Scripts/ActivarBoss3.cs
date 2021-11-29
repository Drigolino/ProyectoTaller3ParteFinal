using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarBoss3 : MonoBehaviour
{
    public GameObject boss3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            boss3.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            boss3.SetActive(true);
        }
        
    }
}
