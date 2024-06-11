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
    private float timer = 0.0f;
    private float timeDisplayTimer = 0.0f;

    private float waitTime = 2.0f;

    private string[] fruits = { "Mango", "Strawberry" };
    private string[] teaBase = { "Black", "Green", "Oolong" };
    private string[] creamer = { "Tea", "Milk Tea" };


    // Start is called before the first frame update

    /*
    void Start()
    {
        InvokeRepeating("GenerateBobaOrder", 5.0f, 2.0f);
    }
    */

    void Update()
    {
        
        timer += Time.deltaTime;
        timeDisplayTimer += Time.deltaTime;

        int timerInSec = Mathf.FloorToInt(timeDisplayTimer % 60);
        timerText.text = timerInSec.ToString();

        
        if (timer > waitTime)
        {
            //Debug.Log(timr);
            Debug.Log("2 seconds");


            //generate a new boba order
            string bobaOrder = GenerateBobaOrder();
            bobaOrderDisplay.text += "\n" + bobaOrder;
            timer = timer - waitTime;
        }
        


    }

    private string GenerateBobaOrder()
    {


        string finalOrder;
        string fruitText = "";
        string teaBaseText = "";
        string creamerText = "";

        //creating a correct order -- avoiding -1 for both fruits and teaBase
        int fruitsChoice = Random.Range(-1, fruits.Length);
        int teaBaseChoice = Random.Range(0, teaBase.Length);
        int creamerChoice = Random.Range(0, creamer.Length);

        if (fruitsChoice != -1)
        {
            fruitText = fruits[fruitsChoice];
        }

        teaBaseText = teaBase[teaBaseChoice];
        creamerText = creamer[creamerChoice];

        finalOrder = fruitText + " " + teaBaseText + " " + creamerText;
        //bobaOrderDisplay.text += "\n" + finalOrder;
        return finalOrder;
    }

}
