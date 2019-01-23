using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnColl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.ToString());

        
    }
}
