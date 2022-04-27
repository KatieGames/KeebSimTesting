using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;


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

        GenerateEmails();
        ReadEmails();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateEmails()
    {
        Player playerData = player.GetComponent<Player>();
        miscEmails = playerData.inboxMisc;

        //gets a random email
        int RandNum = Random.Range(1, 10);
        int EmailsAmnt = miscEmails.Length;

        //generates however many emails chosen by RandNum
        for(int i = 0; i < RandNum; i++)
        {
            //generates random email
            int RandEmail = Random.Range(0, possibleEmails.Length);
            miscEmails = miscEmails.Append(possibleEmails[RandEmail]).ToArray();
            //miscEmails[EmailsAmnt += 1] = possibleEmails[RandEmail];
        }

        playerData.inboxMisc = miscEmails;
    }

    void ReadEmails()
    {
        Player playerData = player.GetComponent<Player>();

        int EmailsAmnt = playerData.inboxMisc.Length;
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
            tButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Decoder.DecodeEmail(miscEmails[i], 1);
            //sets its buttonNumber int accordingly
            tButton.GetComponent<emailButtons>().buttonNumber = i;
        }
    }

    public static void DisplayEmail(int buttonNumber)
    {
        //for the email content section
        GameObject subjectContent = GameObject.Find("SubjectContent");
        GameObject senderContent = GameObject.Find("SenderContent");
        GameObject bodyContent = GameObject.Find("BodyContent");

        Player playerData = GameObject.Find("GameManagement").GetComponent<Player>();

        string email = playerData.inboxMisc[buttonNumber];

        //not yet implemented
        //GameObject dueDate = GameObject.Find("DueContent");
        //GameObject cost = GameObject.Find("CostContent");
        subjectContent.GetComponent<TMPro.TextMeshProUGUI>().text = Decoder.DecodeEmail(email, 1);
        senderContent.GetComponent<TMPro.TextMeshProUGUI>().text = Decoder.DecodeEmail(email, 2);
        bodyContent.GetComponent<TMPro.TextMeshProUGUI>().text = Decoder.DecodeEmail(email, 3);

        // subjectContent.GetComponent<TMPro.TextMeshProUGUI>().text = Decoder.DecodeEmail(email, 1);
        // subjectContent.GetComponent<TMPro.TextMeshProUGUI>().text = Decoder.DecodeEmail(email, 1);

    }

    public void DeleteEmail(int buttonNumber)
    {
        //for the email content section
        GameObject subjectContent = GameObject.Find("SubjectContent");
        GameObject senderContent = GameObject.Find("SenderContent");
        GameObject bodyContent = GameObject.Find("BodyContent");

        Player playerData = GameObject.Find("GameManagement").GetComponent<Player>();

        //not yet implemented
        //GameObject dueDate = GameObject.Find("DueContent");
        //GameObject cost = GameObject.Find("CostContent");
        subjectContent.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        senderContent.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        bodyContent.GetComponent<TMPro.TextMeshProUGUI>().text = "";

        playerData.inboxMisc[playerData.currentEmail] = "";


        // subjectContent.GetComponent<TMPro.TextMeshProUGUI>().text = Decoder.DecodeEmail(email, 1);
        // subjectContent.GetComponent<TMPro.TextMeshProUGUI>().text = Decoder.DecodeEmail(email, 1);

        UpdateEmails();

    }
    
    void UpdateEmails()
    {
        Player playerData = player.GetComponent<Player>();
        possibleEmails = playerData.potentialEmails;
        miscEmails = playerData.inboxMisc;
        ongoingEmails = playerData.inboxOngoing;

        string[] tempEmails = new string[] {};

        int EmailsAmnt = miscEmails.Length;

        for(int i = 0; i < EmailsAmnt; i++)
        {
            if(miscEmails[i] != "")
            {
                List<string> tempList = tempEmails.ToList();
                tempList.Add(miscEmails[i]);
                tempEmails = tempList.ToArray();
            }
        }

        // foreach (string value in tempEmails)
        // {
        //     Debug.Log(value);
        // }
        playerData.inboxMisc = tempEmails;
        miscEmails = playerData.inboxMisc;

        ResetButtons();
    }

    void ResetButtons()
    {
        foreach(Transform child in buttonsList.transform)
        {
            Destroy(child.gameObject);
        }
        ReadEmails();
    }


}
