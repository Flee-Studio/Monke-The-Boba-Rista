//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{

    private string groupName;
    private SpriteRenderer spriteRend;
    private Sprite[] sprites;
    private Sprite customerSprite;
    [SerializeField]
    private int sortNum;

   
    private void Awake()
    {
        //sortNum = 0;
    }
    void Start()
    {
        //Randomly Choose the Sprite
       
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Customer/Customers_asset");
        int customerNum = Random.Range(0, sprites.Length);
        Debug.Log("Customer SPrite: " + sprites.Length);
        
        spriteRend.sprite = sprites[customerNum];
    }


    private string setGroupName(int groupCount)
    {

        //change groupcount to ENUM
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
    /*
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
    */

    /*
            public string displayCustomer()
            {
                string customer = "Group Count: " + groupCount + ", Name: " + groupName + ", Boba Orders: ";

                /*

                for (int i = 0; i < bobaOrders.Count; i++)
                {
                    customer += bobaOrders[i].displayOrder() + ", ";
                }
                

                return customer;
            }
    */
}
