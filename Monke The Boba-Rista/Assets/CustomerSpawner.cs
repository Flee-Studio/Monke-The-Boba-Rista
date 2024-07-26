using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject customerPrefab;

    [SerializeField]
    private float minSpawnTime;

    [SerializeField]
    private float maxSpawnTime;

    [SerializeField]
    private float timeUntilSpawn;

    [SerializeField]
    private float customerCount;
    private SpriteRenderer spriteRen;
    private Sprite[] sprites;

    
   

    void Awake()
    {
        //minSpawnTime = 0;
        //maxSpawnTime = 20;
        timeUntilSpawn = maxSpawnTime;
    }
   
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            //Spawn Customers
           

            if (customerCount == 1)
            {
                Instantiate(customerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            }
            else if(customerCount == 2)
            {
                Instantiate(customerPrefab, new Vector3(-1.0f, 1.0f, 0), Quaternion.identity);
                Instantiate(customerPrefab, new Vector3(0, 0, 0), Quaternion.identity);


            }
            else if (customerCount == 3)
            {
                Instantiate(customerPrefab, new Vector3(-1.0f, 1.0f, 0), Quaternion.identity);
                Instantiate(customerPrefab, new Vector3(0, 1.0f, 0), Quaternion.identity);
                Instantiate(customerPrefab, new Vector3(0, 0, 0), Quaternion.identity);



            }
            else if (customerCount == 4)
            {
               

                Instantiate(customerPrefab, new Vector3(-1.0f, 1.0f, 0), Quaternion.identity);
                Instantiate(customerPrefab, new Vector3(0, 1.0f, 0), Quaternion.identity);
                Instantiate(customerPrefab, new Vector3(-1.0f, 0f, 0), Quaternion.identity);
                Instantiate(customerPrefab, new Vector3(0, 0, 0), Quaternion.identity);


            }


            timeUntilSpawn = maxSpawnTime;

        }
       

    }

}
