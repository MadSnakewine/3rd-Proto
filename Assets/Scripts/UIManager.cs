using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    public Canvas canvas; //DontDestroyOnLoad


    void Start()
    {
        CategoryText.text = PlayerSkillCa.ToString();
        GenerateSkillIcons(PlayerSkillCa);   
    }
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(canvas);
    }
    public Text CategoryText;
    public void CategoryBtnPressed(bool LeftBtn)
    {
        Debug.Log("왼쪽버튼"+LeftBtn);
        ChangeCategoryUI(LeftBtn);
    }
    public PlayerSkillCategory PlayerSkillCa;
    public int CategoryPos;
    public void ChangeCategoryUI(bool toLeft)
    {
        if (toLeft)
            CategoryPos--;
        else
            CategoryPos++;
        if (CategoryPos == -1)
            CategoryPos = 1;
        if (CategoryPos == 2)
            CategoryPos = 0;
        PlayerSkillCa = (PlayerSkillCategory)CategoryPos;
        CategoryText.text = PlayerSkillCa.ToString();
        GenerateSkillIcons(PlayerSkillCa);
    }
    public GameObject SkillIconObj;
    public Transform SkillScroll;

   // public Transform ItemScroll;

    public void GenerateSkillIcons(PlayerSkillCategory category)
    {
        for(int i = SkillScroll.childCount - 1; i>=0; i--)
        {
            Destroy(SkillScroll.GetChild(i).gameObject);
        }

        //for(int j = ItemScroll.childCount-1; j >= 0; j--)
        //{
        //    Destroy(ItemScroll.GetChild(j).gameObject);
        //}

        foreach(PlayerActiveSkill skill in SkillManager.Instance.PlayerActSkills)
        { 
            if(skill.Category == category)
            {
                GameObject go = Instantiate(SkillIconObj);
                go.transform.SetParent(SkillScroll);

                //go.transform.SetParent(ItemScroll);

                go.GetComponent<Image>().sprite = skill.SkillIcon;
                go.GetComponentInChildren<Text>().text = skill.Name;
                go.GetComponent<Button>().onClick.AddListener(()=>SkillBtnPressed(go.GetComponent<Button>()));
            }
        }
    }
    
     int changePos = 1;

    public void SkillInven()
    {
        for (int i = 0; i < KeyUIs.Length; i++)
        {
            if(KeyUIs[i].name == EventSystem.current.currentSelectedGameObject.name) // KeyUIs 자식이랑  스킬창안에 있는 QWE 버튼 누른것이 같으면 
            {
                changePos = i; // KeyUIs 자식번호 대입
                break;
            }
        }
        
    }

    public void SkillChangeAccept()
    {
        ChangeSkillKey(changePos, currentSkill);
    }
    public GameObject[] KeyUIs;
    public void ChangeSkillKey(int where, PlayerActiveSkill skill)
    {
        for(int i = 0; i < KeyUIs.Length; i++)
        {
            if (KeyUIs[i].GetComponent<Image>().sprite == skill.SkillIcon) // KeyUIs자식에 같은 스프라이트 이미지가 있는지 확인
            {
                Debug.Log("중복");
                return;
            }
        }

        KeyUIs[where].GetComponent<Image>().sprite = skill.SkillIcon;
        KeyMap.Instance.SetKeyFunc(where, skill.SkillExecute);

        return;
    }
    public PlayerActiveSkill currentSkill;
    public void SkillBtnPressed(Button btn)
    {
        Debug.Log("Skill " + btn.GetComponentInChildren<Text>().text + "이 눌림");
        foreach(PlayerActiveSkill skill in SkillManager.Instance.PlayerActSkills)
        {
            if (skill.Name == btn.GetComponentInChildren<Text>().text)
            {
                currentSkill = skill;
            }
        }
    }
}
