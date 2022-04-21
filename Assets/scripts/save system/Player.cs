using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //simple values
    public int level;
    public int money;
    public int experience;
    public int currentDay;

    //arrays
    public string[] components; //def value for no comps is 1
    public int[] buildsProgress; //3 can be saved
    public int[] inboxMisc; //every email is in a list, if its 3 in here that means the email 3 will be shown
    public int[] inboxOngoing; //every email is in a list, if its 3 in here that means the email 3 will be shown
    public string[] calendarDays; //every calendar day is an array entry

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

        components = data.components;
        buildsProgress = data.buildsProgress;
        calendarDays = data.calendarDays;
        // inboxMisc = data.inboxMisc; //not yet implemented
        // inboxOngoing = data.inboxOngoing;
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
}
