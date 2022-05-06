using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildButtons : MonoBehaviour
{
    public int buttonNumber;
    public int type;
    public GameObject buildComponent;
    building building;

    private GameObject gameManagement;


    // Start is called before the first frame update
    void Start()
    {
        buildComponent = GameObject.Find("BuildingUI");
        building = buildComponent.GetComponent<building>();
        gameManagement = GameObject.Find("GameManagement");
        Player playerData = gameManagement.GetComponent<Player>();
    }

    public void DisplayItems(int tempType)
    {
        Player playerData = gameManagement.GetComponent<Player>();
        playerData.type = tempType;
        building.LoadItems();
        building.CreateButtons(tempType);
        Debug.Log("A");
    }

    public void PlaceItem()
    {
        Player playerData = gameManagement.GetComponent<Player>();
        building.PlaceComponent(buttonNumber, playerData.type);
    }
}
