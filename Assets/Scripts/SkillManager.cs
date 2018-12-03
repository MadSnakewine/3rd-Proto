using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {
    public static SkillManager Instance;

    void Awake()
    {
        Instance = this;
        Setting();
    }
    public Smash Smash;
    public Bash Bash;
    public Charge Charge;    

    public List<Skill> AllSkills = new List<Skill>();
    public List<AcherActiveSkill> AcherActSkills = new List<AcherActiveSkill>();

    void Start()
    {
        //Setting();
    }
    public void Setting()
    {
        AllSkills.Add(Smash);   AllSkills.Add(Bash);    AllSkills.Add(Charge);

        foreach(Skill sk in AllSkills)
        {
            if(sk is AcherActiveSkill)
            {
                AcherActiveSkill thisSkill = sk as AcherActiveSkill;
                thisSkill.BelongToWho = Characters.Acher;
                AcherActSkills.Add(thisSkill);
            }
        }
    }
}