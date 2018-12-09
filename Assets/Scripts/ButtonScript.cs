using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    public void GameStart()
    {
        SceneManager.LoadScene("Game");
        GameObject.Find("PlayerChar").transform.position = new Vector3(-7, 1.15f, -4); // 씬 이동 후 플레이어 위치 초기화

        GameObject.Find("Canvas").transform.Find("StageUI").gameObject.SetActive(false);
    }
}
