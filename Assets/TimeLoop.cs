using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimeLoop : MonoBehaviour
{
    Rigidbody2D rb;
    public bool rewind = false;//back using array
    bool fixing = false;//forward using array
    public bool flexFixing = false;
    //ArrayList rewindPositions = new ArrayList();
    List<Vector3> rewindPositions = new List<Vector3>();
    Vector3 PreviousVel; //So we can reset to it.
    int posInArray = 120;
    public float forceX = 4;
    public float forceY = 4;
    // Use this for initialization
    void Start()
    {
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(.3f, .3f), ForceMode2D.Impulse);
        rb = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().velocity = new Vector3(forceX, forceY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion();//No rotate

        if (!rewind && !fixing) //Intuitive //THIS IS IT THIS IS WHY WE LOOP CAUSE ONCE WE ENTER FLEX FIXING WE KEEP ADDING NEW ITEMS THAT ARE COPIES OF THE OLD ONES
        {

            rewindPositions.Add(new Vector3(transform.position.x, transform.position.y, 0));//Add current pos to the list
            if (rewindPositions.Count > 120)//If there are more than 120/ 2 seconds worth
            {
                rewindPositions.RemoveAt(0);//remove the oldst
            }

        }

        if (Input.GetKeyDown(KeyCode.E) && rewindPositions.Count >= 60 && !fixing && !rewind&&!flexFixing)// This line needs to be changed //When the e key is pressed and there are 120 positions in the list and otherwise normal
        {
            rewind = true;//Start rewinding
            PreviousVel = GetComponent<Rigidbody2D>().velocity;//store velocity
            posInArray = rewindPositions.Count - 1;//Start with the most recent item
            //Debug.Log("REWINDING " + rewindPositions.Count);
        }

        if (rewind && Input.GetKey(KeyCode.E))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0); //No velocity! No no!
            transform.position = (Vector3)rewindPositions[posInArray];// set the position!
            posInArray--;//go one frame back
            GetComponent<SpriteRenderer>().color = Color.blue;
            if (posInArray <= -1)//When there is nothing else
            {
                rewind = false;//Stop
                flexFixing = true;//Start going forwards
                posInArray = 0;//Set index to where we need it
            }
        }
        else if (rewind && !Input.GetKey(KeyCode.E))
        {
            rewind = false;//Stop
            flexFixing = true;//Start going forwards
            //posInArray = 0;//Set index to where we need it

        }
       /* if (fixing)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            transform.position = (Vector3)rewindPositions[0];
            rewindPositions.RemoveAt(0);
            GetComponent<SpriteRenderer>().color = Color.red;
            if (rewindPositions.Count == 0)
            {
                //rewind = false;
                fixing = false;
                posInArray = 0;
                GetComponent<Rigidbody2D>().velocity = PreviousVel;
            }

        }*/

        if (flexFixing)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            transform.position = (Vector3)rewindPositions[posInArray];
            rewindPositions.RemoveAt(0);
            GetComponent<SpriteRenderer>().color = Color.red;
            if (rewindPositions.Count == 0)
            //if (posInArray> rewindPositions.Count)
            {
                //rewind = false;
                flexFixing = false;
                fixing = false;
                posInArray = 0;
                GetComponent<Rigidbody2D>().velocity = PreviousVel;
            }

        }

        //Debug.Log(rewindPositions.Count);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.name == "LeftWall")
        //{


        //}

    }
}
