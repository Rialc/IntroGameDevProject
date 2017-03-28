using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    // Use this for initialization
    public bool win = false;
    public bool lost = false;
    bool canLose = true;

    private Animator animator;
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = new Quaternion();

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, .075f, 0);
            if (!animator.GetBool("up")) { 
            animator.SetBool("up", true);
            animator.SetBool("down", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
        }

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0, .075f, 0);
            if (!animator.GetBool("down"))
            {
                animator.SetBool("up", false);
                animator.SetBool("down", true);
                animator.SetBool("left", false);
                animator.SetBool("right", false);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(.075f, 0, 0);
            if (!animator.GetBool("left"))
            {
                animator.SetBool("up", false);
                animator.SetBool("down", false);
                animator.SetBool("left", true);
                animator.SetBool("right", false);
            }

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(.075f, 0, 0);
            if (!animator.GetBool("right"))
            {
                animator.SetBool("up", false);
                animator.SetBool("down", false);
                animator.SetBool("left", false);
                animator.SetBool("right", true);
            }

        }
        if (Input.GetKey(KeyCode.R))
        {
            canLose = !canLose;
        }

        if(!Input.GetKey(KeyCode.RightArrow)&& !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("up", false);
            animator.SetBool("down", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);

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
