using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    //, , , , month, year, snap data, , item data, inventory, items moving,
    //https://youtu.be/XOjd_qU2Ido?t=308


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
    public string[] calendarDays; //every calendar day is an array entry

    //build save system
    //every component is stored as an int between 12 and 99, with 11 meaning no component
    //there will then be an array with 3 entrys, this is for each placed keyboard case in the scene, each case is considered a keyboard
    //there can be a max of 2 placed at both the final station and at a workstation, there can simeltaneously be 1 in storage
    //each one of these will be saved as a long number of the component ids, so 261143 could mean case 26, no plate, and pcb 43


    //OR DO EACH WORKSTATION AS AN ARRAY SAVING ITS PLACED ITEMS

    public PlayerData (Player player)
    {
        level = player.level;
        money = player.money;
        experience = player.experience;
        currentDay = player.currentDay;
        components = player.components;
        buildsProgress = player.buildsProgress;
        calendarDays = player.calendarDays;
    }
}
