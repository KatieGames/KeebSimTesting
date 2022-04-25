using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emailButtons : MonoBehaviour
{
    public int buttonNumber;
    // Start is called before the first frame update
    public void OnClick()
    {
        emails.DisplayEmail(buttonNumber);
    }
}
