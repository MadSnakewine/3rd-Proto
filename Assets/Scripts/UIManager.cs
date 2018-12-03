using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    void Start()
    {
        CategoryText.text = AcherSkillCa.ToString();
        GenerateSkillIcons(AcherSkillCa);
    }
    void Awake()
    {
        Instance = this;
    }
    public Text CategoryText;
    public void CategoryBtnPressed(bool LeftBtn)
    {
        Debug.Log("왼쪽버튼"+LeftBtn);
        ChangeCategoryUI(LeftBtn);
    }
    public AcherSkillCategory AcherSkillCa;
    public int CategoryPos;
    public void ChangeCategoryUI(bool toLeft)
    {
        if (toLeft)
            CategoryPos--;
        else
            CategoryPos++;
        if (CategoryPos == -1)
            CategoryPos = 2;
        if (CategoryPos == 3)
            CategoryPos = 0;
        AcherSkillCa = (AcherSkillCategory)CategoryPos;
        CategoryText.text = AcherSkillCa.ToString();
        GenerateSkillIcons(AcherSkillCa);
    }
    public GameObject SkillIconObj;
    public Transform SkillScroll;
    public void GenerateSkillIcons(AcherSkillCategory category)
    {
        for(int i = SkillScroll.childCount - 1; i>=0; i--)
        {
            Destroy(SkillScroll.GetChild(i).gameObject);
        }
        foreach(AcherActiveSkill skill in SkillManager.Instance.AcherActSkills)
        {
            if(skill.Category == category)
            {
                GameObject go = Instantiate(SkillIconObj);
                go.transform.SetParent(SkillScroll);
                go.GetComponent<Image>().sprite = skill.SkillIcon;
                go.GetComponentInChildren<Text>().text = skill.Name;
            }
        }
    }
    public void SkillBtnPressed(Button btn)
    {
        Debug.Log("Skill " + btn.GetComponentInChildren<Text>().text + "이 눌림");
    }
}
