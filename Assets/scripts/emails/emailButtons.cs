using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class emailButtons : MonoBehaviour
{
    public int buttonNumber;
    public int currentEmail;
    public GameObject management;

    private GameObject player;


    emails email;
    // Start is called before the first frame update
    void Start()
    {
        management = GameObject.Find("Mail");
        email = management.GetComponent<emails>();

        player = GameObject.Find("GameManagement");
    }
    public void DisplayEmail()
    {
        Player playerData = player.GetComponent<Player>();

        email.DisplayEmail(buttonNumber);
        currentEmail = buttonNumber;
        playerData.currentEmail = currentEmail;
    }

    public void DeleteEmail()
    {
        email.DeleteEmail(currentEmail);
    }

    public void AcceptEmail()
    {
        email.AcceptEmail();
    }

    public void SubmitBuild()
    {
        Player playerData = player.GetComponent<Player>();
        string[] components = Decoder.DecodeBuild(playerData.buildsProgress[0]);

        if(playerData.buildsProgress[0] == "01@03@69#02@01@24#03@02@35#04@00@57#05@04@12#"){
            foreach(string value in components)
            {
                List<string> tlist = playerData.inventory.ToList();
                tlist.Remove(value);
                playerData.inventory = tlist.ToArray();
            }

            List<string> tempList = playerData.inventory.ToList();
            tempList.Clear();
            playerData.buildsProgress = tempList.ToArray();


            //prevent uninitialisation of the arrays
            if(playerData.buildsProgress.Length < 1)
            {
                playerData.buildsProgress = new string[1];
            }

            if(playerData.inventory.Length < 1)
            {
                playerData.inventory = new string[1];
            }

            //removes physical objects
            GameObject casesPoint = GameObject.Find("Cases");
            GameObject pcbsPoint = GameObject.Find("Pcbs");
            GameObject platesPoint = GameObject.Find("Plates");
            GameObject switchesPoint = GameObject.Find("Switches");
            GameObject keycapsPoint = GameObject.Find("Keycaps");
            foreach(Transform child in casesPoint.transform)
            {
                Destroy(child.gameObject);                                 
            }   
            foreach(Transform child in platesPoint.transform)
            {
                Destroy(child.gameObject);                                 
            }   
            foreach(Transform child in pcbsPoint.transform)
            {
                Destroy(child.gameObject);                                 
            }   
            foreach(Transform child in switchesPoint.transform)
            {
                Destroy(child.gameObject);                                 
            }   
            foreach(Transform child in keycapsPoint.transform)
            {
                Destroy(child.gameObject);                                 
            }

            //pays the player
            string pay = Decoder.DecodeEmail(playerData.inboxMisc[buttonNumber],4);
            playerData.money += int.Parse(pay);
            playerData.SavePlayer();
        }
    }
}
