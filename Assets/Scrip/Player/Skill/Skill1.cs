using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : Skill
{
    private void OnEnable()
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
