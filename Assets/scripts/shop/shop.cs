using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    //player object
    public GameObject gameManagement;

    //category object
    public GameObject itemGrid;

    //local sorted arrays
    string[] cases;
    string[] plates;
    string[] pcbs;
    string[] switches;
    string[] keycaps;

    //from playerdata
    string[] components;
    string[] shopItems;

    // Start is called before the first frame update
    void Start()
    {
        //loads required player data
        Player playerData = gameManagement.GetComponent<Player>();
        components = playerData.components;
        shopItems = playerData.shopItems;

        LoadItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadItems()
    {
        //splits into type arrays
        foreach(string value in shopItems)
        {
            //seperates the value and checks its type
            string tdecoded;
            tdecoded = Decoder.DecodeComponent(value, 1);

            //sorts the values into the required arrays based on tdecoded
            if(tdecoded == "01")
            {
                cases = cases.Append(value).ToArray();
            }
            else if(tdecoded == "02")
            {
                pcbs = pcbs.Append(value).ToArray();
            }
            else if(tdecoded == "03")
            {
                switches = switches.Append(value).ToArray();
            }
            else if(tdecoded == "04")
            {
                keycaps = keycaps.Append(value).ToArray();
            }
        }
    }

    //parse in the type, if its cases it will instantiate the case ones etc, parse as number
    void CreateButtons(int type)
    {
        foreach(string entry in )
        //makes enough buttons for all items in array
        GameObject tButton;
        tButton = Instantiate(buttonPrefab);
        //sets parent to the button list for scrolling
        tButton.transform.SetParent(buttonsList.transform);
        //sets the scale of the button to 1 because this was an issue for whatever reason
        tButton.transform.localScale = new Vector3(1f,1f,1f);

        //changes text to placeholder text
        tButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Decoder.DecodeEmail(miscEmails[i], 1);
        //sets its buttonNumber int accordingly
        tButton.GetComponent<emailButtons>().buttonNumber = i;
    }
}
