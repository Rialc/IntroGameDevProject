/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firewheelscript : MonoBehaviour {
    bool rewind = false;//back using array
    bool fixing = false;//forward using array
    List<Vector3> rewindRotation = new List<Vector3>();
    Vector3 PreviousVel; //So we can reset to it.
    int posInArray = 120;


    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (!rewind && !fixing)
        {
            transform.Rotate(new Vector3(0, 0, 1));
            rewindRotation.Add(new Vector3(transform.rotation.x, transform.rotation.y, 0));
            if (rewindRotation.Count > 120)
            {
                rewindRotation.RemoveAt(0);
            }

        }

        if (Input.GetKey(KeyCode.E) && rewindRotation.Count == 120 && !fixing && !rewind)
        {
            rewind = true;
            //PreviousVel = GetComponent<Rigidbody2D>().velocity;
            posInArray = rewindRotation.Count - 1;
            //Debug.Log("REWINDING " + rewindPositions.Count);
        }

        if (rewind)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            Vector3 temp = rewindRotation[posInArray];
            transform.rotation = Quaternion.Euler(temp.x, temp.y, temp.z);
            posInArray--;
            if (posInArray <= -1)
            {
                rewind = false;
                fixing = true;
                posInArray = 0;
            }
        }
        if (fixing)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            //transform.rotation= rewindRotation[0];
            rewindRotation.RemoveAt(0);
            if (rewindRotation.Count == 0)
            {
                //rewind = false;
                fixing = false;
                posInArray = 0;
                //GetComponent<Rigidbody2D>().velocity = PreviousVel;
            }

        }
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firewheelscript : MonoBehaviour
{
    bool rewind = false;//back using array
    bool fixing = false;//forward using array
    List<Quaternion> rewindRotation = new List<Quaternion>();
    Vector3 PreviousVel; //So we can reset to it.
    int posInArray = 120;
    public Vector3 rotation = new Vector3(0, 0, 1);

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = new Quaternion();//No rotate

        if (!rewind && !fixing)
        {
            transform.Rotate(rotation);

            rewindRotation.Add(transform.rotation);//Add current pos to the list
            if (rewindRotation.Count > 120)//If there are more than 120/ 2 seconds worth
            {
                rewindRotation.RemoveAt(0);//remove the oldst
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && rewindRotation.Count > 20 && !rewind)
        {
            rewind = true;
            posInArray = rewindRotation.Count - 1;

        }
        else if (rewind && Input.GetKey(KeyCode.E))
        {

            if (rewindRotation.Count >0&&rewindRotation.Count-1>posInArray&&posInArray>=0)
            {
                transform.rotation = (Quaternion)rewindRotation[posInArray];// set the position!
            }
            posInArray--;//go one frame back


        }
        if (rewind && (posInArray <= 0 || Input.GetKeyUp(KeyCode.E)))
        {
            rewind = false;
            fixing = true;
            if (posInArray != 0)
            {
                rewindRotation.RemoveRange(0, posInArray);

            }
            posInArray = 0;

        }
        if (fixing)
        {
            if (rewindRotation.Count > 0)
            {
                transform.rotation = rewindRotation[0];// set the position!
                rewindRotation.RemoveAt(0);
            }
           else { 
                fixing = false;

            }

        }

    }
}
