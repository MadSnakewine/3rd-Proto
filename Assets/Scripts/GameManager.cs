using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
        
    }
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1))
        {
            GameObject.Find("Canvas").transform.Find("SkillWindow").gameObject.SetActive(true);
            
        }
        
	}
}
