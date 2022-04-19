using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calendar : MonoBehaviour
{
    public GameObject player;
    private string[] calendarDays;
    private int valuesAmnt;
    private int currentDay;
    private int dayElements;
    public string[] events;
    // Start is called before the first frame update
    void Start()
    {
        //lets me use the playerData variable with ease
        Player playerData = player.GetComponent<Player>();
        //sets a local array to calendarDays for initial sync
        calendarDays = playerData.calendarDays;
        //sets a local int to current day for initial sync
        currentDay = playerData.currentDay;


        CheckToday();
        CheckPast();
        CheckFuture();
    }

    void CheckToday()
    {
        if(calendarDays[currentDay] != "")
        {
            Debug.Log("Entry found for today");

            //counter for what character the divider starts at
            int c = 0;

            //temp string for the days value
            string stringDay;

            //splitted aray of day strings
            string[] splittedDay = {"", "", ""};

            //temp strings for splitting
            string dayPart1;
            string dayPart2;
            string dayPart3;

            //sets the current day to a local variable
            stringDay = calendarDays[currentDay];

            //splits the stringDay on each @ sign
            events = stringDay.Split('@');


            for(int i = 0; i <= calendarDays[currentDay].Length;){

                //debug logging the position it will split
                //Debug.Log(i);
                //Debug.Log(c);

                //seperates it by the right amount
                i += 7;

                //breaks it down into 3 sections
                dayPart1 = events[c].Substring(0,2);
                splittedDay[0] = dayPart1;
                //Debug.Log(splittedDay[0]);
                
                //setting of int2
                dayPart2 = events[c].Substring(2,2);
                splittedDay[1] = dayPart2;
                //Debug.Log(splittedDay[1]);
                
                //setting of int3
                dayPart3 = events[c].Substring(4,2);
                splittedDay[2] = dayPart3;
                //Debug.Log(splittedDay[2]);

                //any edits and data reading to be done here

                //setting the last bit to 02 meaning due today
                dayPart3 = "02";

                //combining string and setting the last bit
                stringDay = dayPart1 + dayPart2 + dayPart3;

                //Debug.Log("STRINGDAY: " + stringDay);

                //reassignment in the events array
                events[c] = stringDay;

                //sets c to the next item in events list
                c++;
            }

            //debug logs all the events found from the splitted list
            // foreach (string value in events)
            // {
            //     Debug.Log(value);
            // }

            Player playerData = player.GetComponent<Player>();
            playerData.calendarDays[currentDay] = string.Join("@", events);

            //HUGE REVELATION!! alright so ima use strings instead of ints with a dividing character its so so so much easier
            //there is 1 major issue as of now, currently I can only have 1 thing happen per day. It will need to be changed to a two dimensional array to allow for multiple events per day
        }
        else
        {
            Debug.Log("No entries found for today");
        }
    }
    
    void CheckFuture()
    {
        //basic counter for loop
        for(int i = 30; i > currentDay;)
        {
            //if the day isnt empty
            if(calendarDays[i] != "")
            {
                //temp string for the days value
                string stringDay;

                //counter for what character the divider starts at
                int c = 0;

                //splitted aray of day strings
                string[] splittedDay = {"", "", ""};

                //temp strings for splitting
                string dayPart1;
                string dayPart2;
                string dayPart3;

                //sets the current selected day to a local variable
                stringDay = calendarDays[i];

                //splits the stringDay on each @ sign
                events = stringDay.Split('@');


                for(int e = 0; e <= calendarDays[i].Length;)
                {
                    //seperates it by the right amount
                    e += 7;

                    //breaks it down into 3 sections
                    dayPart1 = events[c].Substring(0,2);
                    splittedDay[0] = dayPart1;
                    //Debug.Log(splittedDay[0]);
                    
                    //setting of int2
                    dayPart2 = events[c].Substring(2,2);
                    splittedDay[1] = dayPart2;
                    //Debug.Log(splittedDay[1]);
                    
                    //setting of int3
                    dayPart3 = events[c].Substring(4,2);
                    splittedDay[2] = dayPart3;
                    //Debug.Log(splittedDay[2]);

                    //any edits and data reading to be done here

                    //setting the last bit to 01 meaning on time
                    dayPart3 = "01";

                    //combining string and setting the last bit
                    stringDay = dayPart1 + dayPart2 + dayPart3;
                    
                    //reassignment in the events array
                    events[c] = stringDay;
                    //Debug.Log(stringDay);

                    //sets c to the next item in events list
                    c++;
                }

                // foreach (string value in events)
                // {
                //     Debug.Log(value);
                // }

                Player playerData = player.GetComponent<Player>();
                playerData.calendarDays[i] = string.Join("@", events);
            }
            else
            {
                //Debug.Log("No entries found for future");
            }
            i--;
        }
    }

    void CheckPast()
    {
        //basic counter for loop
        for(int i = 0; i < currentDay;)
        {
            //if the day isnt empty
            if(calendarDays[i] != "")
            {
                //temp string for the days value
                string stringDay;

                //counter for what character the divider starts at
                int c = 0;

                //splitted aray of day strings
                string[] splittedDay = {"", "", ""};

                //temp strings for splitting
                string dayPart1;
                string dayPart2;
                string dayPart3;

                //sets the current selected day to a local variable
                stringDay = calendarDays[i];

                //splits the stringDay on each @ sign
                events = stringDay.Split('@');


                for(int e = 0; e <= calendarDays[i].Length;)
                {
                    //seperates it by the right amount
                    e += 7;

                    //breaks it down into 3 sections
                    dayPart1 = events[c].Substring(0,2);
                    splittedDay[0] = dayPart1;
                    //Debug.Log(splittedDay[0]);
                    
                    //setting of int2
                    dayPart2 = events[c].Substring(2,2);
                    splittedDay[1] = dayPart2;
                    //Debug.Log(splittedDay[1]);
                    
                    //setting of int3
                    dayPart3 = events[c].Substring(4,2);
                    splittedDay[2] = dayPart3;
                    //Debug.Log(splittedDay[2]);

                    //any edits and data reading to be done here

                    //setting the last bit to 02 meaning late
                    dayPart3 = "03";

                    //combining string and setting the last bit
                    stringDay = dayPart1 + dayPart2 + dayPart3;
                    
                    //reassignment in the events array
                    events[c] = stringDay;
                    //Debug.Log(stringDay);

                    //sets c to the next item in events list
                    c++;
                }

                // foreach (string value in events)
                // {
                //     Debug.Log(value);
                // }

                Player playerData = player.GetComponent<Player>();
                playerData.calendarDays[i] = string.Join("@", events);
            }
            else
            {
                //Debug.Log("No entries found for past");
            }
            i++;
        }
    }
}
