using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emailButtons : MonoBehaviour
{
    public int buttonNumber;
    public int currentEmail;
    public GameObject management;


    emails email;
    // Start is called before the first frame update
    void Start()
    {
        management = GameObject.Find("GameManagement");
        email = management.GetComponent<emails>();
    }
    public void DisplayEmail()
    {
        Player playerData = management.GetComponent<Player>();

        emails.DisplayEmail(buttonNumber);
        currentEmail = buttonNumber;
        playerData.currentEmail = currentEmail;
    }

    public void DeleteEmail()
    {
        email.DeleteEmail(currentEmail);
    }

    public void AcceptEmail()
    {

    }
}
