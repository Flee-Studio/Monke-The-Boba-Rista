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

    public delegate void ChildDestroyedHandler(GameObject child);
    public event ChildDestroyedHandler OnChildDestroyed;

    private float timeSinceLastSpawn;

    public CustomerSpawner()
	{
        _customerQueue = new CustomerQueue();
	}

    public void NotifyChildDestroyed(GameObject child)
	{
        if (OnChildDestroyed != null)
		{
            OnChildDestroyed(child);
		}
	}

    public void HandleChildDestroyed(GameObject childDestoryed)
    {
        int childFoundBeingDestroyed = 0;
        _customerQueue.customerQueue.RemoveAll(c => c._customerObject == childDestoryed);
        Debug.Log("Child moving to be destroyed: " + childDestoryed.name);

        for (int i = 0; i < _customerQueue.customerQueue.Count; i++)
		{
            Customer customer = _customerQueue.customerQueue[i];

            CustomerMovement movement = customer._customerObject.transform.GetComponent<CustomerMovement>();

            //Transform child = transform.GetChild(i);

           //CustomerMovement movement = child.GetComponent<CustomerMovement>();

            if (movement.waitingToDelete)
			{
                childFoundBeingDestroyed = 1;
            }
            else
			{
                if (movement != null)
                {
                    movement.targetPosition = queuePoints[i].position;
                }
            }
		}

    }

    // Start is called before the first frame update
    void Start()
    {
        OnChildDestroyed += HandleChildDestroyed;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval && transform.childCount < maxCustomers)
		{
            timeSinceLastSpawn = 0f;
            SpawnCustomer();
		}
    }

    void SpawnCustomer()
	{
        //int spawnIndex = Random.Range(0, spawnPoints.Length);
        //Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject customerObject = Instantiate(customerPrefab, gameObject.transform);

        customerObject.transform.localPosition = transform.position;
        customerObject.transform.localRotation = transform.rotation;

        Customer customer = new Customer(customerObject, transform.childCount, _customerQueue);
        _customerQueue.customerQueue.Add(customer);

        CustomerMovement movement = customerObject.GetComponent<CustomerMovement>();
        if (movement != null)
		{
            //movement.targetPosition = targetPoint.position;
            movement.targetPosition = queuePoints[_customerQueue.customerQueue.Count-1].position;
		}
	}

	void OnDestroy()
	{
        OnChildDestroyed -= HandleChildDestroyed;
	}
}
