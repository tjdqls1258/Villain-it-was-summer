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
        Debug.Log("��ų 1 �ߵ�");
    }

    public override void Cancel_Skill()
    {
        Debug.Log("��ų �� �ߵ�");
    }
}
