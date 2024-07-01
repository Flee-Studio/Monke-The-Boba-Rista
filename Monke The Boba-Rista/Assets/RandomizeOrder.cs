using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeOrder : MonoBehaviour { 
    public float timer = 0.0f;
    public float waitTime = 2.0f;
    private CustomerGroup CustomerGroup;
    

    // Update is called once per frame
    public List<CustomerGroup> customers = new List<CustomerGroup>();
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //per second
        // int timerInSec = Mathf.FloorToInt(timeDisplayTimer % 60);
        //timerText.text = timerInSec.ToString();

        //creating order every 2 seconds
        if (timer > waitTime)
        {
            Debug.Log("2 seconds");

            CustomerGroup customerGroup = new CustomerGroup();
            Debug.Log(customerGroup.displayCustomer());
            customers.Add(customerGroup);

            for (int i = 0; i < customerGroup.groupCount; i++)
            {
                Instantiate(CustomerGroup.customerGroupPreFab, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
            }

            Debug.Log("Customer Count: " + customers.Count);



            //reset timer 
            timer = timer - waitTime;
        }



    }
}
