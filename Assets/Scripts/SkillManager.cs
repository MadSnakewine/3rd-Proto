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
    public Deffence Deffence;

    public Sword Sword;
    public Spear Spear;

    public List<Skill> AllSkills = new List<Skill>();
    public List<PlayerActiveSkill> PlayerActSkills = new List<PlayerActiveSkill>();

    void Start()
    {
        //Setting();
    }
    public void Setting()
    {
        AllSkills.Add(Smash);   AllSkills.Add(Bash);    AllSkills.Add(Charge);  AllSkills.Add(Deffence); AllSkills.Add(Sword); AllSkills.Add(Spear);

        foreach(Skill sk in AllSkills)
        {
            if(sk is PlayerActiveSkill)
            {
                PlayerActiveSkill thisSkill = sk as PlayerActiveSkill;
                thisSkill.mono = this;
                thisSkill.BelongToWho = Characters.Player;
                PlayerActSkills.Add(thisSkill);
            }
        }
    }
}