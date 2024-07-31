using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject customerPrefab;

    [SerializeField]
    private GameObject bobaOrderUI;

    [SerializeField]
    private float minSpawnTime;

    [SerializeField]
    private float maxSpawnTime;

    [SerializeField]
    private float timeUntilSpawn;
    private int customerCount;

    [SerializeField]
    private int minCustomers;
    [SerializeField]
    private int maxCustomers;

    private SpriteRenderer spriteRen;
    private Sprite[] sprites;
    //private Vector3[] customerPositions = {new Vector3(0f,0f,0f),  };

    //Boba Spawner
    [SerializeField]
    private BobaOrderSpawner bobaOrderSpawner;

    private Vector3[] customerSpawnPoints = { new Vector3(-1.0f, 0f, 0), new Vector3(0, 0, 0), new Vector3(0, 1.0f, 0), new Vector3(-1.0f, 1.0f, 0), };



void Awake()
    {
        //minSpawnTime = 0;
        //maxSpawnTime = 20;
        minCustomers = 1;
        maxCustomers = 4;
        customerCount = Random.Range(minCustomers, maxCustomers);
        timeUntilSpawn = maxSpawnTime;
    }

    private void Start()
    {
        
    }

    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0)
        {
            //Spawn Customers
            if (customerCount > 0)
            {
                for (int i = 0; i < customerCount; i++)
                {
                    Instantiate(customerPrefab, transform.position + customerSpawnPoints[i], Quaternion.identity, GameObject.FindGameObjectWithTag("customer_spawner").transform);
                }

                bobaOrderSpawner.SpawnBobaOrder(customerCount);
                //Randomize Customer Count
                customerCount = Random.Range(minCustomers, maxCustomers);
                timeUntilSpawn = maxSpawnTime;
            }
            else
            {
                Debug.LogError("Customer Count must be between 1-4. Please Try Again.");
            }
        }
        


    }

}
