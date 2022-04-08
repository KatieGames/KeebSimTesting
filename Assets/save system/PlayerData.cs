using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    //level, exp, money, day, month, year, snap data, build data, item data, inventory, items moving, emails ongoing, emails other
    //https://youtu.be/XOjd_qU2Ido?t=308


    //simple values
    public int level;
    public int money;
    public int experience;
    public int currentDay;

    //arrays
    public int[] builds;
    public int[] inboxMisc;
    public int[] inboxOngoing;
}
