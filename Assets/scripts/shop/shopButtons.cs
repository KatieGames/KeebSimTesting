using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopButtons : MonoBehaviour
{
    public int buttonNumber;
    public GameObject shopComponent;
    shop shop;


    // Start is called before the first frame update
    void Start()
    {
        shopComponent = GameObject.Find("Shop");
        shop = shopComponent.GetComponent<shop>();
    }

    public void DisplayItems(int type)
    {
        shop.LoadItems();
        shop.CreateButtons(type);
    }

    public void BuyItem()
    {
        //shop.BuyItem();
    }
}
