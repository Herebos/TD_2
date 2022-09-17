using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject monsterPrefab;

    public float interval = 3;


    void FixedUpdate()
    {
        if (Input.GetKey("space")) 
        {
            LaunchWave();
        }
    }
    /*
    void Start()
    {
            LaunchWave();
    }*/

    public void LaunchWave()
    {
        InvokeRepeating("SpawnNext", interval, interval);
    }

    void SpawnNext()
    {
        Instantiate(monsterPrefab, transform.position, Quaternion.Euler(0,-90,0));
    }
}
