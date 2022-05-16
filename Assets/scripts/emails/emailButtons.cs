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
        foreach(string value in components)
        {
            List<string> tlist = playerData.inventory.ToList();
            tlist.Remove(value);
            playerData.inventory = tlist.ToArray();
        }

        List<string> tempList = playerData.inventory.ToList();
        tempList.Clear();
        playerData.buildsProgress = tempList.ToArray();
    }
}
