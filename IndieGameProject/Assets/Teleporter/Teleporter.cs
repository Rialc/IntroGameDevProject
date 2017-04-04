using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
    public GameObject LinkedTeleporter;
    bool noTeleporting = false;
    int count = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (count != 0)
        {
            count--;
        }else if (noTeleporting == true)
        {
            noTeleporting = false;
        }
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!noTeleporting&& col.gameObject.name=="Player")
        {

            LinkedTeleporter.GetComponent<Teleporter>().noTeleporting = true;
            LinkedTeleporter.GetComponent<Teleporter>().count = 4;
            col.gameObject.transform.position = LinkedTeleporter.transform.position;

        }

    }
    /*void onCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            noTeleporting = false;
        }

    }*/
}
