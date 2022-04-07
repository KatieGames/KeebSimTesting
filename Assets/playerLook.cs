using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLook : MonoBehaviour
{
    // Start is called before the first frame update

    public LayerMask selectionPointLayer;
    public GameObject itemSnap;
    RaycastHit hit;
    private bool temp = true;
    private bool holdingItem = false;
    private GameObject heldItem;

    // Update is called once per frame
    void Update()
    {
        //debug draw rays with their colours
        if(temp)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100f, Color.green);
        }

        if(!temp)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
        }



        //pickup item and raycast
        if(Input.GetKeyDown("e"))
        {
            if(!holdingItem)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f, selectionPointLayer))
                {

                    //colour debug
                    temp = false;
                    Debug.Log("Did Hit");
                    Invoke("ColourReset", 1f);

                    //picks up the item
                    if(hit.transform.tag == "Moveable")
                    {
                        heldItem = hit.transform.gameObject;
                        holdingItem = true;
                    }
                }
            }
            else
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f, selectionPointLayer))
                {
                    //colour debug
                    temp = false;
                    Debug.Log("Did Hit");
                    Invoke("ColourReset", 1f);
                    
                    //moves the item to the snap point
                    if(hit.transform.tag == "SnapPoint")
                    {
                        holdingItem = false;
                        heldItem.transform.position = hit.transform.position;
                    }
                }
            }
        }

        //move item to the players snap point
        if(holdingItem)
        {
            heldItem.transform.position = itemSnap.transform.position;
        }
    }

    //reset the debug colour
    void ColourReset(){
        temp = true;
    }
}
