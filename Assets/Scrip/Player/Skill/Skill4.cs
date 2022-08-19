using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4 : Skill
{
    private void Awake()
    {
        this.skill_data.SkillName = GetType().ToString();
    }
    public override void Skill_Ative()
    {
        Debug.Log("스킬 1 발동");
    }

    public override void Cancel_Skill()
    {
        Debug.Log("스킬 끝 발동");
    }
}
