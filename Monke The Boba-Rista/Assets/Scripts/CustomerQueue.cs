using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    public List<Customer> customerQueue = new List<Customer>();
    private GameObject _customerObject;
    public List<Transform> queuePoints;

    public CustomerQueue(/*GameObject customerObject*/)
	{
        //_customerObject = customerObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetTargetPosition(Customer customer)
	{
        CustomerMovement movement = _customerObject.GetComponent<CustomerMovement>();
        //customerQueue.Find(customer => customer.CustomerNumber == );
        int customerPosition = customerQueue.IndexOf(customer);
        return queuePoints[customerPosition].position;
    }

    void RemoveCustomerFromQueue(int queuePosition)
	{
        customerQueue.RemoveAt(queuePosition);
	}
}
