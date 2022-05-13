using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopButtons : MonoBehaviour
{
    public int buttonNumber;
    public GameObject shopComponent;
    shop shop;
    Player playerData;


    // Start is called before the first frame update
    void Start()
    {
        shopComponent = GameObject.Find("Shop");
        shop = shopComponent.GetComponent<shop>();

        GameObject gameManagement = GameObject.Find("GameManagement");
        
        playerData = gameManagement.GetComponent<Player>();
    }

    public void DisplayItems(int type)
    {
        shop.LoadItems();
        shop.CreateButtons(type);

        playerData.type = type;
    }

    public void BuyItem()
    {
        shop.BuyItem(buttonNumber, playerData.type);
    }
}
