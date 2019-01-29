using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public GameObject Player;

    void Awake()
    {
        //Character = GameObject.Find("PlayerChar");
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(Player);
    }
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("i"))
        {
            if (SceneManager.GetActiveScene().name != "Lobby")
                return;

            GameObject.Find("Canvas").transform.Find("SkillWindow").gameObject.SetActive(true);
        }

        if(GameObject.Find("Canvas").transform.Find("SkillWindow").gameObject.active == true)
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                GameObject.Find("Canvas").transform.Find("SkillWindow").gameObject.SetActive(false);
            }
               
        }
        
	}
}
