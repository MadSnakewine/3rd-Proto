using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour {

    float buttonWidth, buttonHeight;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonMouse()
    {
        buttonWidth = transform.gameObject.GetComponent<RectTransform>().rect.width;
        buttonHeight = transform.gameObject.GetComponent<RectTransform>().rect.height;
        //Debug.Log(buttonWidth);


        transform.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, buttonWidth += 50.0f);
        transform.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight += 10.0f);
    }

    public void ExitButtonMouse()
    {
        transform.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, buttonWidth -= 50.0f);
        transform.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight -= 10.0f);
    }

    public void ClickButton()
    {
        transform.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, buttonWidth = 216.4f);
        transform.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight = 47.1f);
    }
}
