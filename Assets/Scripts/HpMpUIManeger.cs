using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpMpUIManeger : MonoBehaviour {

    public Slider HpUI;
    public Slider MpUI;

    private Player player;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Player>();
        HpUI.maxValue = player.maxHp;
        HpUI.value = HpUI.maxValue;
        MpUI.maxValue = player.maxMp;
        MpUI.value = MpUI.maxValue;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.C))
        {
            player.maxHp -= 10;

            player.maxMp += 8;
        }
	}

    public void UpdateHp(int amount)
    {
        HpUI.value = amount;
    }
    public void UpdateMp(int amount)
    {
        MpUI.value = amount;
    }
}
