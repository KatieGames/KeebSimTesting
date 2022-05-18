using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;
using System;

public class shop : MonoBehaviour
{
    //player object
    public GameObject gameManagement;

    //category object
    public GameObject itemGrid;

    //button prefab
    public GameObject buttonPrefab;

    //local sorted arrays
    public string[] cases;
    public string[] plates;
    public string[] pcbs;
    public string[] switches;
    public string[] keycaps;

    //from playerdata
    public string[] components;
    public string[] shopItems;
    public string[] inventory;
    public int balance;

    // Start is called before the first frame update
    void Start()
    {
        //loads required player data
        Player playerData = gameManagement.GetComponent<Player>();
        components = playerData.components;
        shopItems = playerData.shopItems;
        balance = playerData.money;
        inventory = playerData.inventory;

        LoadItems();
        UpdateBalance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadItems()
    {
        //splits into type arrays
        foreach(string value in shopItems)
        {
            //seperates the value and checks its type
            string tdecoded;
            tdecoded = Decoder.DecodeComponent(value, 1);

            Debug.Log(tdecoded);

            //sorts the values into the required arrays based on tdecoded
            if(tdecoded == "01")
            {
                cases = cases.Append(value).ToArray();
            }
            else if(tdecoded == "02")
            {
                plates = plates.Append(value).ToArray();
            }
            else if(tdecoded == "03")
            {
                pcbs = pcbs.Append(value).ToArray();
            }
            else if(tdecoded == "04")
            {
                switches = switches.Append(value).ToArray();
            }
            else if(tdecoded == "05")
            {
                keycaps = keycaps.Append(value).ToArray();
            }
            else
            {
                Debug.Log(tdecoded);
                Debug.Log("Null entry");
            }
        }
    }

    //parse in the type, if its cases it will instantiate the case ones etc, parse as number
    public void CreateButtons(int type)
    {
        //clears buttons
        ResetButtons();

        //creates buttons
        //cases
        if(type == 0)
        {
            int buttonsAmnt = cases.Length;
            for(int i = 0; i < buttonsAmnt; i++)
            {
                //makes enough buttons for all cases in list
                GameObject tButton;
                tButton = Instantiate(buttonPrefab);
                //sets parent to the button list for scrolling
                tButton.transform.SetParent(itemGrid.transform);
                //sets the scale of the button to 1 because this was an issue for whatever reason that broke all the scaling of the list
                tButton.transform.localScale = new Vector3(1f,1f,1f);

                //changes text to placeholder text
                tButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = GenerateText(cases[i]);
                //sets its buttonNumber int accordingly
                tButton.GetComponent<shopButtons>().buttonNumber = i;
            }
        }
        //plates
        if(type == 1)
        {
            int buttonsAmnt = plates.Length;
            for(int i = 0; i < buttonsAmnt; i++)
            {
                //makes enough buttons for all cases in list
                GameObject tButton;
                tButton = Instantiate(buttonPrefab);
                //sets parent to the button list for scrolling
                tButton.transform.SetParent(itemGrid.transform);
                //sets the scale of the button to 1 because this was an issue for whatever reason that broke all the scaling of the list
                tButton.transform.localScale = new Vector3(1f,1f,1f);

                //changes text to placeholder text
                tButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = GenerateText(plates[i]);
                //sets its buttonNumber int accordingly
                tButton.GetComponent<shopButtons>().buttonNumber = i;
            }
        }
        //pcbs
        if(type == 2)
        {
            int buttonsAmnt = pcbs.Length;
            for(int i = 0; i < buttonsAmnt; i++)
            {
                //makes enough buttons for all cases in list
                GameObject tButton;
                tButton = Instantiate(buttonPrefab);
                //sets parent to the button list for scrolling
                tButton.transform.SetParent(itemGrid.transform);
                //sets the scale of the button to 1 because this was an issue for whatever reason that broke all the scaling of the list
                tButton.transform.localScale = new Vector3(1f,1f,1f);

                //changes text to placeholder text
                tButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = GenerateText(pcbs[i]);
                //sets its buttonNumber int accordingly
                tButton.GetComponent<shopButtons>().buttonNumber = i;
            }
        }
        //switches
        if(type == 3)
        {
            int buttonsAmnt = switches.Length;
            for(int i = 0; i < buttonsAmnt; i++)
            {
                //makes enough buttons for all cases in list
                GameObject tButton;
                tButton = Instantiate(buttonPrefab);
                //sets parent to the button list for scrolling
                tButton.transform.SetParent(itemGrid.transform);
                //sets the scale of the button to 1 because this was an issue for whatever reason that broke all the scaling of the list
                tButton.transform.localScale = new Vector3(1f,1f,1f);

                //changes text to placeholder text
                tButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = GenerateText(switches[i]);
                //sets its buttonNumber int accordingly
                tButton.GetComponent<shopButtons>().buttonNumber = i;
            }
        }
        //keycaps
        if(type == 4)
        {
            int buttonsAmnt = keycaps.Length;
            for(int i = 0; i < buttonsAmnt; i++)
            {
                //makes enough buttons for all cases in list
                GameObject tButton;
                tButton = Instantiate(buttonPrefab);
                //sets parent to the button list for scrolling
                tButton.transform.SetParent(itemGrid.transform);
                //sets the scale of the button to 1 because this was an issue for whatever reason that broke all the scaling of the list
                tButton.transform.localScale = new Vector3(1f,1f,1f);

                //changes text to placeholder text
                tButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = GenerateText(keycaps[i]);
                //sets its buttonNumber int accordingly
                tButton.GetComponent<shopButtons>().buttonNumber = i;
            }
        }
    }

    string GenerateText(string entry)
    {
        //splitted aray of component strings
        string[] splittedComponent = {"", ""};

        //splits into parts. Type, Item
        splittedComponent = entry.Split('@');

        //sets it to an int
        int itemIndex = int.Parse(splittedComponent[1]);

        //returns item name from components array
        return components[itemIndex];
    }

    void ResetButtons()
    {
        foreach(Transform child in itemGrid.transform)
        {
            Destroy(child.gameObject);                                 
        }

        //resets and reinitialises arrays
        Array.Clear(cases, 0, cases.Length);
        cases = new string[0];
        Array.Clear(plates, 0, plates.Length);
        plates = new string[0];            
        Array.Clear(pcbs, 0, pcbs.Length);
        pcbs = new string[0];
        Array.Clear(switches, 0, switches.Length);
        switches = new string[0];
        Array.Clear(keycaps, 0, keycaps.Length);
        keycaps = new string[0];

        //calls load
        LoadItems();
    }

    public void BuyItem(int buttonNumber, int type)
    {
        string currentItem = "";
        //works out the current item
        if(type == 0)
        {
            currentItem = cases[buttonNumber];
        }
        else if(type == 1)
        {
            currentItem = plates[buttonNumber];
        }
        else if(type == 2)
        {
            currentItem = pcbs[buttonNumber];
        }
        else if(type == 3)
        {
            currentItem = switches[buttonNumber];
        }
        else if(type == 4)
        {
            currentItem = keycaps[buttonNumber];
        }
        else
        {
            Debug.Log("Null entry");
        }

        //subtracts money from balance
        if((balance - int.Parse(Decoder.DecodeComponent(currentItem, 3))) >= 0)
        {
            balance -= int.Parse(Decoder.DecodeComponent(currentItem, 3));
            //gives you the item into your inventory
            Debug.Log(currentItem);
            List<string> tempList = inventory.ToList();
            tempList.Add(currentItem);
            inventory = tempList.ToArray();
            Player playerData = gameManagement.GetComponent<Player>();
            playerData.inventory = inventory;
            playerData.money = balance;
        }

        UpdateBalance();
    }

    void UpdateBalance()
    {
        Player playerData = gameManagement.GetComponent<Player>();
        GameObject.Find("Balance").GetComponent<TMPro.TextMeshProUGUI>().text = playerData.money.ToString();
    }
}
