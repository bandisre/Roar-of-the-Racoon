using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickupCrowbar : MonoBehaviour
{
    public Transform theDest;

    void setup() {
        if (Input.GetKeyDown("space")) 
        {
            Debug.Log("Pick up crowbar");
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = theDest.position;
            this.transform.parent = GameObject.Find("Destination").transform;
        }
    }
   /* void onMouseUp() 
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }*/
}
