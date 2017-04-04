using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This version works perfectly, 1 second
/*public class Pong : MonoBehaviour {
    Rigidbody2D rb;
    bool rewind = false;//back using array
    bool fixing = false;//forward using array
    //ArrayList rewindPositions = new ArrayList();
    List<Vector3> rewindPositions = new List<Vector3>();
    Vector3 PreviousVel; //So we can reset to it.
    int posInArray=60;
	// Use this for initialization
	void Start () {
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(.3f, .3f), ForceMode2D.Impulse);
        rb = GetComponent<Rigidbody2D>();
       GetComponent<Rigidbody2D>().velocity = new Vector3(4f, 4f, 0);
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = new Quaternion();
        
        if (!rewind&&!fixing)
        {

            rewindPositions.Add(new Vector3(transform.position.x,transform.position.y,0));
             if(rewindPositions.Count > 60)
            {
                rewindPositions.RemoveAt(0);
            }

        }

        if (Input.GetKey(KeyCode.E) && rewindPositions.Count == 60&&!fixing&&!rewind)
        {
            rewind = true;
            PreviousVel = GetComponent<Rigidbody2D>().velocity;
            posInArray = rewindPositions.Count-1;
            //Debug.Log("REWINDING " + rewindPositions.Count);
        }

        if (rewind) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            transform.position = (Vector3)rewindPositions[posInArray];
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
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            transform.position = (Vector3)rewindPositions[0];
            rewindPositions.RemoveAt(0);
            if (rewindPositions.Count==0)
            {
                //rewind = false;
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
}*/



/*public class Pong : MonoBehaviour
{
Rigidbody2D rb;
public bool rewind = false;//back using array
bool fixing = false;//forward using array
//ArrayList rewindPositions = new ArrayList();
List<Vector3> rewindPositions = new List<Vector3>();
Vector3 PreviousVel; //So we can reset to it.
int posInArray = 120;
public float forceX = 4;
public float forceY= 4;
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

    if (!rewind && !fixing) //Intuitive
    {

        rewindPositions.Add(new Vector3(transform.position.x, transform.position.y, 0));//Add current pos to the list
        if (rewindPositions.Count > 120)//If there are more than 120/ 2 seconds worth
        {
            rewindPositions.RemoveAt(0);//remove the oldst
        }

    }

    if (Input.GetKeyDown(KeyCode.E) && rewindPositions.Count == 120 && !fixing && !rewind)// This line needs to be changed //When the e key is pressed and there are 120 positions in the list and otherwise normal
    {
        rewind = true;//Start rewinding
        PreviousVel = GetComponent<Rigidbody2D>().velocity;//store velocity
        posInArray = rewindPositions.Count - 1;//Start with the most recent item
        //Debug.Log("REWINDING " + rewindPositions.Count);
    }

    if (rewind)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0); //No velocity! No no!
        transform.position = (Vector3)rewindPositions[posInArray];// set the position!
        posInArray--;//go one frame back
        if (posInArray <= -1)//When there is nothing else
        {
            rewind = false;//Stop
            fixing = true;//Start going forwards
            posInArray = 0;//Set index to where we need it
        }
    }
    if (fixing)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        transform.position = (Vector3)rewindPositions[0];
        rewindPositions.RemoveAt(0);
        if (rewindPositions.Count == 0)
        {
            //rewind = false;
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
}*/
public class Pong : MonoBehaviour
{
    Rigidbody2D rb;
    public bool rewind = false;//back using array
    public bool fixing = false;//forward using array
   public  bool flexFixing = false;
                        //ArrayList rewindPositions = new ArrayList();
    public List<Vector3> rewindPositions = new List<Vector3>();
    Vector3 PreviousVel; //So we can reset to it.
    public int posInArray = 120;
    public float forceX = 4;
    public float forceY = 4;
    public Vector3 justInCase;
    // Use this for initialization
    void Start()
    {
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(.3f, .3f), ForceMode2D.Impulse);
        rb = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().velocity = new Vector3(forceX, forceY, 0);
        justInCase= new Vector3(forceX, forceY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion();//No rotate

        if (!rewind&&!fixing)
        {
            
            rewindPositions.Add(new Vector3(transform.position.x, transform.position.y, 0));//Add current pos to the list
            if (rewindPositions.Count > 120)//If there are more than 120/ 2 seconds worth
            {
                rewindPositions.RemoveAt(0);//remove the oldest
            }
            posInArray = rewindPositions.Count;
            if(GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0))
            {
                GetComponent<Rigidbody2D>().velocity = justInCase;

            }
        }
        if (Input.GetKeyDown(KeyCode.E)&&rewindPositions.Count>20&&!rewind)
        {
            rewind = true;
            PreviousVel = GetComponent<Rigidbody2D>().velocity;//store velocity
            posInArray = rewindPositions.Count-1;

        }
        else if (rewind && Input.GetKey(KeyCode.E))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0); //No velocity! No no!
            if (rewindPositions.Count > 0 && rewindPositions.Count - 1 > posInArray && posInArray >= 0)
            {
                transform.position = (Vector3)rewindPositions[posInArray];// set the position!
            }
            posInArray--;//go one frame back
            GetComponent<SpriteRenderer>().color = new Color(0,0,.5f);

        }
        if (rewind && (posInArray <= 0|| Input.GetKeyUp(KeyCode.E)))
        {
            rewind = false;
            GetComponent<SpriteRenderer>().color = Color.white;

            fixing = true;
            if (posInArray != 0)
            {
                rewindPositions.RemoveRange(0, posInArray);

            }
            posInArray = 0;

        }
        if (fixing)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0); //No velocity! No no!
            if (rewindPositions.Count > 0) { 
            transform.position = (Vector3)rewindPositions[0];// set the position!
                rewindPositions.RemoveAt(0);
            }
            else
            {

                fixing = false;
                GetComponent<Rigidbody2D>().velocity = PreviousVel;
                
            }
            
           

            

        }
        /*if (fixing)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0); //No velocity! No no!
            
                transform.position = (Vector3)rewindPositions[0];// set the position!
            rewindPositions.RemoveAt(0);
            if (rewindPositions.Count == 0)
            {
                fixing = false;
                GetComponent<Rigidbody2D>().velocity = PreviousVel;
                GetComponent<SpriteRenderer>().color = Color.red;

            }

        }*/

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.(name == "LeftWall")
        //{


        //}

    }
}