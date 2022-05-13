using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Decoder
{
    // Start is called before the first frame update
    public static string Decode(string entry, int bit)
    {


        string dayPart1;
        string dayPart2;
        string dayPart3;

        //splitted aray of day strings
        string[] splittedDay = {"", "", ""};
        string[] decodedDay = {"", "", ""};

        //possible info
        string[] types = {"delivery", "build", "services"};
        string[] timings = {"on time", "due today", "late"};
        string[] data = {"", "", ""};

        //setting of int1
        dayPart1 = entry.Substring(0,2);
        splittedDay[0] = dayPart1;
        //Debug.Log(splittedDay[2]);

        //setting of int2
        dayPart2 = entry.Substring(2,2);
        splittedDay[1] = dayPart2;
        //Debug.Log(splittedDay[1]);
        
        //setting of int3
        dayPart3 = entry.Substring(4,2);
        splittedDay[2] = dayPart3;
        //Debug.Log(splittedDay[2]);


        //decodes numbers
        decodedDay[0] = types[int.Parse(dayPart1)];
        decodedDay[1] = data[int.Parse(dayPart2)];
        decodedDay[2] = timings[int.Parse(dayPart3)];



        if(bit == 1)
        {
            return decodedDay[0];
        }
        else if(bit == 2){
            return decodedDay[1];
        }
        else if(bit == 3){
            return decodedDay[2];
        }
        else{
            return "tf is this";
        }
    }

    public static string DecodeEmail(string entry, int part)
    {
        //splitted aray of email strings
        string[] splittedEmail = {"", "", "", "", ""};

        //splits into parts. Subject, sender, content, due date, cost
        splittedEmail = entry.Split('/');

        if(part == 1)
        {
            return splittedEmail[0];
        }
        else if(part == 2){
            return splittedEmail[1];
        }
        else if(part == 3){
            return splittedEmail[2];
        }
        else if(part == 4){
            return splittedEmail[3];
        }
        else if(part == 5){
            return splittedEmail[4];
        }
        else{
            return "tf is this";
        }
    }

    public static string DecodeComponent(string entry, int part)
    {
        //splitted aray of component strings
        string[] splittedComponent = {"", "", ""};

        //splits into parts. Type, Item
        splittedComponent = entry.Split('@');

        if(part == 1)
        {
            return splittedComponent[0];
        }
        else if(part == 2){
            return splittedComponent[1];
        }
        else if(part == 3){
            return splittedComponent[2];
        }
        else{
            return "tf is this";
        }
    }
}

