using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BobaOrderDisplay : MonoBehaviour
{

    public TextMeshProUGUI bobaOrderDisplay;

    protected string[] fruits = { "Mango", "Strawberry" };
    protected string[] teaBase = { "Black", "Green", "Oolong" };
    protected string[] creamer = { "Tea", "Milk Tea" };
    

    // Start is called before the first frame update
    void Start()
    {
        string test = GenerateBobaOrder();
        bobaOrderDisplay.text += "\n" + test;
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

        return finalOrder;
    }

    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */
}
