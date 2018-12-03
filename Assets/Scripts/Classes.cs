using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Classes : MonoBehaviour
{
}
public interface Skill
{
}
[System.Serializable]
public abstract class SkillBase : Skill
{
    public string Name;
    public Characters BelongToWho;    
    public Sprite SkillIcon;
    public string Description;
}
public enum Characters
{
    Warrior, Acher, Magician
}

[System.Serializable]
public abstract class ActiveSkill : SkillBase
{    
    public float UseCost;
    public float CoolTime;
}

[System.Serializable]
public abstract class AcherActiveSkill : ActiveSkill
{
    public AcherSkillCategory Category;
    public AcherResource RequireResource;
}
public enum AcherResource
{
    Mp, St
}
public enum AcherSkillCategory
{
    Act1, Act2, Act3
}



[System.Serializable]
public class Smash : AcherActiveSkill
{

}
[System.Serializable]
public class Bash : AcherActiveSkill
{

}
[System.Serializable]
public class Charge : AcherActiveSkill
{

}