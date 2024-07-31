using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


    public class BobaOrder : MonoBehaviour
    {

    /*
        [SerializeField]
        private float minSpawnTime;
        [SerializeField]
        private float maxSpawnTime;
        [SerializeField]
        private float timeUntilSpawn;

        [SerializeField]
        private GameObject BobaOrderUI;
        void Awake()
        {
            timeUntilSpawn = maxSpawnTime;
        }

        void Update()
        {

            timeUntilSpawn -= Time.deltaTime;
            if (timeUntilSpawn <= 0)
            {
               Instantiate(BobaOrderUI, transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("canvas_boba").transform);
               //newOrder.transform.SetParent(GameObject.FindGameObjectWithTag("canvas_boba").transform, false);
                timeUntilSpawn = maxSpawnTime;
            }
        }
    
    */

    /** TURN THIS SCRIPT INTO SCRIPTABLE OBJECT??? ***/

    [SerializeField]
    private string[] fruits = { "Mango", "Strawberry" };
    private string[] teaBase = { "Black", "Green", "Oolong" };
    private string[] milk = { "Tea", "Milk Tea" };

    public string fruitChoice;
    public string teaBaseChoice;
    public string milkChoice;
    private Image[] bobaBase;
    private GameObject bobaTopping;

    private SpriteRenderer spriteRend;
    private Sprite[] sprites;

    //private Image[] bobaComponents;

    private void Awake()
    {
        fruitChoice = generateFruitChoice();
        teaBaseChoice = generateTeaBaseChoice();
        milkChoice = generateMilkChoice();

    }
    private void Start()
    {

        //index 3: oolong, index 4: green, index 5: black
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Boba/boba_asset_sheet");

        Debug.Log("SpriteBoba: " + sprites.Length);
        bobaBase = GetComponentsInChildren<Image>(); //accessing the Images from each game object within the group
        bobaTopping = GameObject.Find("topping");

        SetBaseImage();
        //SetToppingImage();

    }
    private void SetBaseImage()
    {
        Image baseImage = bobaBase[1].GetComponent<Image>(); //bobabase[1] = base
        Debug.Log("teabase choice: " + teaBaseChoice);
        if (teaBaseChoice == "Black")
        {
            baseImage.sprite = sprites[5];
        }
        else if (teaBaseChoice == "Green")
        {
            baseImage.sprite = sprites[4];
        }
        else if (teaBaseChoice == "Oolong")
        {
            baseImage.sprite = sprites[3];
        }
    }
    private void SetToppingImage()
    {
       // ** TO DO LATER **
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
