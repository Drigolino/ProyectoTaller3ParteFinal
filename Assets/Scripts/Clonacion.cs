using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clonacion : MonoBehaviour
{
    [SerializeField]
    GameObject[] posicionesDeClonacion;//arreglo
    [SerializeField]
    GameObject enemy;
    public int tiempo = 3;
    // Start is called before the first frame update
    void Start()
    {
        
        ClonarEnemigos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClonarEnemigos()
    {
        for (int i = 0; i < posicionesDeClonacion.Length; i++)
        {
            Instantiate(enemy, posicionesDeClonacion[i].transform.position, posicionesDeClonacion[i].transform.rotation);
        }
    }  
}
