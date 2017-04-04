using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {
    public GameObject LinkedDoor;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {

            LinkedDoor.GetComponent<firewheelscript>().rotation = new Vector3(0,0,-1);
            GetComponent<SpriteRenderer>().color = Color.grey;


        }

    }
}
