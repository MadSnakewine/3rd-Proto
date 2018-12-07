using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillInfo : MonoBehaviour
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
    public MonoBehaviour mono;

    public virtual void SkillExecute()
    {
        Debug.Log("이건 " + Name + "의 스킬 실행 기본 펑션");
    }
}
[System.Serializable]
public enum Characters
{
    Player
}


[System.Serializable]
public abstract class ActiveSkill : SkillBase
{    
    public float UseCost;
    public float CoolTime;
}

[System.Serializable]
public abstract class PlayerActiveSkill : ActiveSkill
{
    public PlayerSkillCategory Category;
    public PlayerResource RequireResource;
}
public enum PlayerResource
{
    Mp, St
}
public enum PlayerSkillCategory
{
    Skill,Equipment
}

[System.Serializable]
public class Smash : PlayerActiveSkill
{

}
[System.Serializable]
public class Bash : PlayerActiveSkill
{
    public override void SkillExecute()
    {
        
        Debug.Log("이건 강타 스킬 override 펑션");
        mono.StartCoroutine(BashCoroutine());        
    }
    IEnumerator BashCoroutine()
    {
        Debug.Log("강타 코루틴 첫번째");
        yield return new WaitForSeconds(2);
        Debug.Log("강타 코루틴 끝");
    }
}
[System.Serializable]
public class Charge : PlayerActiveSkill
{

}
[System.Serializable]
public class Deffence : PlayerActiveSkill
{

}
[System.Serializable]
public class Sword : PlayerActiveSkill
{

}
[System.Serializable]
public class Spear : PlayerActiveSkill
{

}