using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImgDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 defaultposition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultposition = this.transform.position;

        Debug.Log(gameObject.GetComponentInChildren<Text>().text);

        foreach (PlayerActiveSkill skill in SkillManager.Instance.PlayerActSkills)
        {
            if (skill.Name == gameObject.GetComponentInChildren<Text>().text)
            {
                UIManager.Instance.currentSkill = skill;
            }
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = Input.mousePosition;
        this.transform.position = currentPos;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = defaultposition;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < UIManager.Instance.KeyUIs.Length; i++)
        {
            if (UIManager.Instance.KeyUIs[i].name == collision.gameObject.name) // KeyUIs 자식이랑  스킬창안에 있는 QWE 버튼 누른것이 같으면 
            {
                Debug.Log(collision.gameObject.ToString());
                UIManager.Instance.changePos = i; // KeyUIs 자식번호 대입
                break;
            }
        }

        Debug.Log(UIManager.Instance.changePos);
    }

}
