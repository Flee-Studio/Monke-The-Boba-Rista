using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CustomerRandomization;


public class CustomerRandomization : MonoBehaviour
{

    // randomizing customer groups

    //single(1 person/ drink)

    //couple(2 people/ 2 drinks)

    //Boba Fiends(4 people/4 drinks)

    private float timer = 0.0f;
    private float waitTime = 2.0f;
    public GameObject customerGroupPreFab;

    public class CustomerGroup
    {

        private int[] groupCountRand = { 1, 2, 4 };
        public int groupCount;
        private string groupName;
        private List<BobaOrder> bobaOrders;

        public CustomerGroup()
        {
            groupCount = setGroupCount();
            groupName = setGroupName(groupCount);
            bobaOrders = setBobaOrders(groupCount);
        }
        private int setGroupCount()
        {
            int count = Random.Range(0, groupCountRand.Length);
            int groupCount = groupCountRand[count];
            return groupCount;
        }

        private string setGroupName(int groupCount)
        {
            string name = "";
            if (groupCount == 1)
            {
                name = "Single Group";
            }
            else if (groupCount == 2)
            {
                name = "Couple Group";

            }
            else if (groupCount == 4)
            {
                name = "Boba Fiends Group";

            }

            return name;

        }
        
        private List<BobaOrder> setBobaOrders(int groupCount)
        {
            List<BobaOrder> bobaList = new List<BobaOrder>();
            for (int i = 0; i < groupCount; i++)
            {
                BobaOrder order = new BobaOrder();
                bobaList.Add(order);
            }

            return bobaList;
        }

        public string displayCustomer()
        {
            string customer = "Group Count: " + groupCount + ", Name: " + groupName + ", Boba Orders: ";
           
            for(int i = 0; i < bobaOrders.Count; i++)
            {
                customer += bobaOrders[i].displayOrder() + ", ";
            }

            return customer;
        }
    }

    
    public class BobaOrder
    {
        private string[] fruits = { "Mango", "Strawberry" };
        private string[] teaBase = { "Black", "Green", "Oolong" };
        private string[] milk = { "Tea", "Milk Tea" };

        public string fruitChoice;
        public string teaBaseChoice;
        public string milkChoice;

        public BobaOrder()
        {
            fruitChoice = generateFruitChoice();
            teaBaseChoice = generateTeaBaseChoice();
            milkChoice = generateMilkChoice();

        }

        private string generateFruitChoice()
        {
            //creating a correct order -- avoiding -1 for both fruits and teaBase
            int fruitsChoice = Random.Range(-1, fruits.Length);
            if (fruitsChoice != -1)
            {
                return fruits[fruitsChoice];
            }
            else
            {
                return "";
            }

        }
        private string generateTeaBaseChoice()
        {
            int teaBaseChoice = Random.Range(0, teaBase.Length);
            return teaBase[teaBaseChoice];

        }
        private string generateMilkChoice()
        {
            int milkChoice = Random.Range(0, milk.Length);
            return milk[milkChoice];
        }

        public string displayOrder()
        {
            return fruitChoice + " " + teaBaseChoice + " " + milkChoice;
        }


    }

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
                Instantiate(customerGroupPreFab, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
            }

            Debug.Log("Customer Count: " + customers.Count);



            //reset timer 
            timer = timer - waitTime;
        }

    }
}
