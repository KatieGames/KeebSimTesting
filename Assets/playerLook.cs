using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLook : MonoBehaviour
{
    // Start is called before the first frame update

    public LayerMask selectionPointLayer;
    RaycastHit hit;
    bool temp = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(temp)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100f, Color.green);
        }

        if(!temp)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
        }

        if(Input.GetKeyDown("e"))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f, selectionPointLayer))
            {
                temp = false;
                Debug.Log("Did Hit");
                Invoke("ColourReset", 1f);
            }
        }
    }

    void ColourReset(){
        temp = true;
    }
}
