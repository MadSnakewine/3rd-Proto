using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void KeyFunc();
public class KeyMap : MonoBehaviour {
    public static KeyMap Instance;
    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
        KeyQFunc = () => Debug.Log("Q스킬");
        KeyWFunc = () => Debug.Log("W스킬");
        KeyEFunc = () => Debug.Log("E스킬");
    }
    public KeyFunc KeyQFunc;
    public KeyFunc KeyWFunc;
    public KeyFunc KeyEFunc;

    public void SetKeyFunc(int where,KeyFunc func)
    {
        switch(where)
        {
            case 1:
                KeyQFunc = func;
                break;
            case 2:
                KeyWFunc = func;
                break;
            case 3:
                KeyEFunc = func;
                break;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)&&KeyQFunc!=null)
        {
            KeyQFunc();
        }
        if (Input.GetKeyDown(KeyCode.W) && KeyWFunc != null)
        {
            KeyWFunc();
        }
        if (Input.GetKeyDown(KeyCode.E) && KeyEFunc != null)
        {
            KeyEFunc();
        }
    }
    public void KeyQBtn()
    {
        KeyQFunc();
    }
    public void KeyWBtn()
    {
        KeyWFunc();
    }
    public void KeyEBtn()
    {
        KeyEFunc();
    }
}
