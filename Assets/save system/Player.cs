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
    public int[] components; //def value for no comps is 1
    public int[] buildsProgress; //3 can be saved
    public int[] inboxMisc; //every email is in a list, if its 3 in here that means the email 3 will be shown
    public int[] inboxOngoing; //every email is in a list, if its 3 in here that means the email 3 will be shown

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
        // inboxMisc = data.inboxMisc; //not yet implemented
        // inboxOngoing = data.inboxOngoing;
    }
}
