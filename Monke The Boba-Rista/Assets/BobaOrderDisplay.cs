using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BobaOrderDisplay : MonoBehaviour
{

    public TextMeshProUGUI bobaOrderDisplay;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI bobaCountText;
    private float timer = 0.0f;
    private float timeDisplayTimer = 0.0f;
    private float waitTime = 2.0f;

    // Start is called before the first frame update

    /*
    void Start()
    {
        InvokeRepeating("GenerateBobaOrder", 5.0f, 2.0f);
    }
    */
    private void Start()
    {
        
    }
    /*

    public List<BobaOrder> bobaOrders = new List<BobaOrder>();
    
    void Update()
    {
        //updating time
        timer += Time.deltaTime;
        timeDisplayTimer += Time.deltaTime;

        //per second
        int timerInSec = Mathf.FloorToInt(timeDisplayTimer % 60);
        timerText.text = timerInSec.ToString();

        //creating order every 2 seconds
        if (timer > waitTime)
        {
            Debug.Log("2 seconds");

            //generate a new boba order
            BobaOrder newOrder = new BobaOrder();
            bobaOrders.Add(newOrder);

            //boba counter and boba UI display updated
            bobaCountText.text = "BobaCount: " + bobaOrders.Count.ToString();
            bobaOrderDisplay.text += "\n" + newOrder.displayOrder();

            //reset timer 
            timer = timer - waitTime;
        }
        

    }
    */
   
}
