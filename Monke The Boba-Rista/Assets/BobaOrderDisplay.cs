using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


    public class BobaOrder : MonoBehaviour
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
