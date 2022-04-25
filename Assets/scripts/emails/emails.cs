using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class emails : MonoBehaviour
{
    public GameObject player;
    private string[] possibleEmails; //all possible emails
    private string[] miscEmails; //all mail in inbox
    private string[] ongoingEmails; //all accepted job emails
    public GameObject buttonsList; //gameobject contianing buttons
    public GameObject buttonPrefab; //button prefab for email ui


    // Start is called before the first frame update
    void Start()
    {
        Player playerData = player.GetComponent<Player>();
        possibleEmails = playerData.potentialEmails;
        miscEmails = playerData.inboxMisc;
        ongoingEmails = playerData.inboxOngoing;

        ReadEmails();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateEmails()
    {
        //gets a random email
        int RandNum = Random.Range(0, 10);
        int EmailsAmnt = miscEmails.Length;

        //generates however many emails chosen by RandNum
        for(int i = 0; i < RandNum; i++)
        {
            //generates random email
            int RandEmail = Random.Range(0, possibleEmails.Length);
            miscEmails[EmailsAmnt += 1] = possibleEmails[RandEmail];
        }
    }

    void ReadEmails()
    {

        int EmailsAmnt = miscEmails.Length;
        for(int i = 0; i < EmailsAmnt; i++)
        {

            //makes enough buttons for all emails in inbox
            GameObject tButton;
            tButton = Instantiate(buttonPrefab);
            //sets parent to the button list for scrolling
            tButton.transform.SetParent(buttonsList.transform);
            //sets the scale of the button to 1 because this was an issue for whatever reason
            tButton.transform.localScale = new Vector3(1f,1f,1f);

            //changes text to placeholder text
            tButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "lorem  ipsum";
        }

        // foreach (Transform child in buttonsList.transform)
        // {
        //     if(child.name == "Button")
        //     {
        //         child.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "lorem  ipsum";
        //     }
        // }
    }
}
