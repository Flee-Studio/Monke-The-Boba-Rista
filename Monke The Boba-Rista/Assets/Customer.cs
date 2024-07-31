//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{

    private string groupName;
    private int groupCount;
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


    private string SetGroupName(int groupCount)
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
    private void SetBobaOrders(int groupCount)
    {
        //List<BobaOrder> bobaList = new List<BobaOrder>();
        for (int i = 0; i < groupCount; i++)
        {
            
            //GameObject order = Instantiate()
            BobaOrder order = gameObject.AddComponent<BobaOrder>();
            bobaList.Add(order);
        }

        //return bobaList;
    }
    

    
    public string displayCustomer()
    {
        string customer = "Group Count: " + groupCount + ", Name: " + groupName + ", Boba Orders: ";

                

        for (int i = 0; i < bobaList.Count; i++)
        {
            customer += bobaList[i].displayOrder() + ", ";
        }
                

        return customer;
    }
    */
    
}
