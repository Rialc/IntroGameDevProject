using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    // Use this for initialization
    public bool win = false;
    public bool lost = false;
    bool canLose = true;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = new Quaternion();
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, .075f, 0);


        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0, .075f, 0);


        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(.075f, 0, 0);


        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(.075f, 0, 0);


        }
        if (Input.GetKey(KeyCode.R))
        {
            canLose = !canLose;


        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "goal")
        {
            win = true;
            Debug.Log("Win = " + win);
        }else if (canLose&&col.gameObject.CompareTag("Rewindable")&&!win) { lost = true; }

        //if(col.gameObject.tag)

    }
}
