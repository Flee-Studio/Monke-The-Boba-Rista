using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    private GameObject _customerObject;
    int queuePosition;
    public int CustomerNumber;
    private CustomerQueue _customerQueue;
    public bool customerLeave = false;
    public Customer(GameObject customerObject, int customerNumber, CustomerQueue customerQueue)
	{
        _customerObject = customerObject;
        CustomerNumber = customerNumber;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateCustomerPositions()
	{
        //Still need to loop through all customers in the list to update their movementPosition
        //Need to write a way for customers to be deleted (remove from queue and destory their gameobject)
        CustomerMovement movement = _customerObject.GetComponent<CustomerMovement>();
        if (movement != null)
        {
            movement.targetPosition = _customerQueue.GetTargetPosition(this);
        }
    }



}
