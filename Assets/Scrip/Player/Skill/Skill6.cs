using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill6 : Skill
{
    private void Awake()
    {
        skill_data.SkillName = GetType().ToString();
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
