using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player : MonoBehaviour
{
    //simple values
    public int level;
    public int money;
    public int experience;
    public int currentDay;
    public int currentEmail;
    public int type;

    //arrays
    public string[] components; //def value for no comps is 1
    public string[] shopItems; //items in shop stored as encoded ints
    public int[] buildsProgress; //3 can be saved
    public string[] inventory; //inventory
    public string[] potentialEmails; //every email
    public string[] inboxMisc; //every email is in a list, if its 3 in here that means the email 3 will be shown
    public string[] inboxOngoing; //every email is in a list, if its 3 in here that means the email 3 will be shown
    public string[] calendarDays; //every calendar day is an array entry

    //game objects
    public GameObject calendar;
    public GameObject emails;


    //if this is start a bunch of functions in calendar break due to the arrays not being initialized
    // private void Awake() 
    // {
    //     calendarDays = new string[31];
    // }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    { 
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        money = data.money;
        experience = data.experience;
        currentDay = data.currentDay;
        currentEmail = data.currentEmail;
        type = data.type;

        // components = data.components;
        // shopItems = data.shopItems;
        buildsProgress = data.buildsProgress;
        inventory = data.inventory;
        calendarDays = data.calendarDays;
        // inboxMisc = data.inboxMisc; //not yet implemented
        // inboxOngoing = data.inboxOngoing;

        if (inventory == null || inventory.Length == 0)
        {
            inventory = new string[1];
        }
    }

    public void SetMoney(int Tmoney)
    {
        money += Tmoney;
        Debug.Log(money);
    }

    public void AddExperience(int Texperience)
    {
        //each level is 1000exp
        experience += Texperience;
        Debug.Log(experience);

        //level calculation
        level = experience/1000;
        Debug.Log(level);
    }

    private void Start() 
    {
        FirstLoad();
        Sync();
    }

    public void TimeIncrease()
    {
        //progresses time
        currentDay += 1;
        //syncs calendar
        calendar.GetComponent<calendar>().Calendar();
        //generates emails
        emails.GetComponent<emails>().GenerateEmails();
        //saves
        SavePlayer();
    }

    void Sync()
    {
        LoadPlayer();
        //syncs calendar
        calendar.GetComponent<calendar>().Calendar();
        SavePlayer();
    }

    void FirstLoad()
    {
        string path = Application.persistentDataPath + "/player.ezeSave";
        if (File.Exists(path))
        {
            LoadPlayer();
        }
        else
        {
            SavePlayer();
        }
    }
}