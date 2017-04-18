using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
        
	}
	
	// Update is called once per frame
	void Update () {
        //this.GetComponent<SpriteRenderer>().sortingOrder = -10;
    }
}
