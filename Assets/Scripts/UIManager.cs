using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


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

    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            if (SceneManager.GetActiveScene().name != "Lobby")
                return;

            GameObject.Find("Canvas").transform.Find("SkillWindow").gameObject.SetActive(true);
        }

        if (GameObject.Find("Canvas").transform.Find("SkillWindow").gameObject.active == true)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                GameObject.Find("Canvas").transform.Find("SkillWindow").gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown("t"))
        {
            if (SceneManager.GetActiveScene().name != "Lobby")
                return;

            GameObject.Find("Canvas").transform.Find("IllustratedBook").gameObject.SetActive(true);
        }

        if (GameObject.Find("Canvas").transform.Find("IllustratedBook").gameObject.active == true)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                GameObject.Find("Canvas").transform.Find("IllustratedBook").gameObject.SetActive(false);
            }
        }
    }

    public Text CategoryText;
    public void CategoryBtnPressed(bool LeftBtn)
    {
        Debug.Log("왼쪽버튼"+LeftBtn);
        ChangeCategoryUI(LeftBtn);

        if (CategoryText.text == "Equipment")
        {
            GameObject.Find("Canvas").transform.Find("SkillWindow").Find("Scroll View").Find("Viewport")
                .Find("SkillInven").Find("KeyQ").gameObject.SetActive(false);

            GameObject.Find("Canvas").transform.Find("SkillWindow").Find("Scroll View").Find("Viewport")
                .Find("SkillInven").Find("KeyW").gameObject.SetActive(false);

            GameObject.Find("Canvas").transform.Find("SkillWindow").Find("Scroll View").Find("Viewport")
                .Find("SkillInven").Find("KeyE").gameObject.SetActive(false);
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("SkillWindow").Find("Scroll View").Find("Viewport")
                .Find("SkillInven").Find("KeyQ").gameObject.SetActive(true);

            GameObject.Find("Canvas").transform.Find("SkillWindow").Find("Scroll View").Find("Viewport")
                .Find("SkillInven").Find("KeyW").gameObject.SetActive(true);

            GameObject.Find("Canvas").transform.Find("SkillWindow").Find("Scroll View").Find("Viewport")
                .Find("SkillInven").Find("KeyE").gameObject.SetActive(true);
        }
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

                if (CategoryText.text != "Equipment")
                    go.AddComponent<ImgDrag>();

                go.AddComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                go.AddComponent<BoxCollider2D>().size = new Vector2(40,40); 


                go.GetComponent<Button>().onClick.AddListener(()=>SkillBtnPressed(go.GetComponent<Button>()));
            }
        }
    }
    
    public int changePos;

    public void SkillInven()
    {
        //for (int i = 0; i < KeyUIs.Length; i++)
        //{
        //    if(KeyUIs[i].name == EventSystem.current.currentSelectedGameObject.name) // KeyUIs 자식이랑  스킬창안에 있는 QWE 버튼 누른것이 같으면 
        //    {
        //        changePos = i; // KeyUIs 자식번호 대입
        //        break;
        //    }
        //}

        //Debug.Log(changePos);
    }

    public void SkillChangeAccept()
    {
        if (CategoryText.text != "Equipment")
        {
            ChangeSkillKey(changePos, currentSkill);
        }
        else
        {
            ChangeWeapon(changePos, currentSkill);
        }
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

    public void ChangeWeapon(int where, PlayerActiveSkill skill)
    {
        GameObject.Find("Canvas").transform.Find("UICase").Find("Weapon").
            GetComponent<Image>().sprite = skill.SkillIcon;
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

    public void EquipsButton()
    {
        if (GameObject.Find("Canvas").transform.Find("IllustratedBook").gameObject.active == true)
        {
            GameObject.Find("Canvas").transform.Find("IllustratedBook").gameObject.SetActive(false);
        }

        GameObject.Find("Canvas").transform.Find("SkillWindow").gameObject.SetActive(true);
    }
}
