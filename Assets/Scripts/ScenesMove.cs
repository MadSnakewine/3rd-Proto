using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenesMove : MonoBehaviour {

    private void OnCollisionEnter(Collision col)
    {
        if (SceneManager.GetActiveScene().name != "Lobby")
            return;

        if (col.gameObject.tag== "StageEntrance")
        {
            Debug.Log("충돌");
            GameObject.Find("Canvas").transform.Find("StageUI").gameObject.SetActive(true);
        }
    }
}
