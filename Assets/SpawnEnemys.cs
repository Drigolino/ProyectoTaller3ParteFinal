using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    public GameObject Prefab;
    public float timeSpawn;
    public float curretTimeSpawn;
    private int countEnemys;
    public int maxEnemys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countEnemys<maxEnemys)
        {
            if (curretTimeSpawn > 0)
            {
                curretTimeSpawn -= Time.deltaTime;
            }
            else
            {
                Spawn();
                curretTimeSpawn = timeSpawn;
                countEnemys += 1;
            }
        }
       
        
        
        
    }
    void Spawn()
    {

        Instantiate(Prefab, transform.position, Quaternion.identity);
    }
}
