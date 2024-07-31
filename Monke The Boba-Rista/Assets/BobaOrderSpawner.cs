using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BobaOrderSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject bobaOrderUI;
    [SerializeField]
    private List<GameObject> bobaOrders;
    private float distanceApart;
    [SerializeField]
    private TMP_Text bobaCount;
    // Start is called before the first frame update

    private void Awake()
    {
        bobaOrders = new List<GameObject>();
        distanceApart = 80f;
    }

    public void SpawnBobaOrder(int customerCount)
    {

        for(int i = 0; i < customerCount; i++)
        {
            GameObject bobaOrder;
            if (bobaOrders.Count > 0)
            {
                GameObject lastBobaOrder = bobaOrders[bobaOrders.Count - 1];
                Vector3 lastPosition = lastBobaOrder.transform.position;
                Debug.Log("Last Position " + lastPosition);
                bobaOrder = Instantiate(bobaOrderUI, lastPosition + new Vector3(distanceApart, 0, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("canvas_boba").transform);
               
            }
            else
            {
                bobaOrder = Instantiate(bobaOrderUI, transform.position + new Vector3(i * distanceApart, 0, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("canvas_boba").transform);
                
            }
            
            bobaOrders.Add(bobaOrder);
            bobaOrder.name = "boba_order_" + (bobaOrders.Count - 1);
            bobaCount.text = "BobaCount: " + bobaOrders.Count;

        }


    }

}
