using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenesMove : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (SceneManager.GetActiveScene().name != "Lobby")
            return;

        if (other.tag == "StageEntrance")
        {
            Debug.Log("충돌");

            if (Input.GetKeyDown(KeyCode.Return))
            {
                GameObject.Find("Canvas").transform.Find("StageUI").gameObject.SetActive(true);
            }
        }

        if (GameObject.Find("Canvas").transform.Find("StageUI").gameObject.active == true)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                GameObject.Find("Canvas").transform.Find("StageUI").gameObject.SetActive(false);
            }

        }
    }

    private void OnCollisionStay(Collision col)
    {
       
    }
}
