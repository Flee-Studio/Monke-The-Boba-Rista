using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab;
    public float spawnInterval = 2f;
    //public Transform[] spawnPoints;
    public int maxCustomers = 5;
    public Transform targetPoint;
    public List<Transform> queuePoints;
    private CustomerQueue _customerQueue;

    private float timeSinceLastSpawn;
    public int customerCount = 0;

    public CustomerSpawner()
	{
        _customerQueue = new CustomerQueue();
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval && customerCount < maxCustomers)
		{
            customerCount++;
            timeSinceLastSpawn = 0f;
            SpawnCustomer();
		}
    }

    void SpawnCustomer()
	{
        //int spawnIndex = Random.Range(0, spawnPoints.Length);
        //Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject customerObject = Instantiate(customerPrefab, transform.position, transform.rotation);

        Customer customer = new Customer(customerObject, customerCount, _customerQueue);
        _customerQueue.customerQueue.Add(customer);

        CustomerMovement movement = customerObject.GetComponent<CustomerMovement>();
        if(movement != null)
		{
            //movement.targetPosition = targetPoint.position;
            movement.targetPosition = queuePoints[customerCount-1].position;
		}
	}
}
