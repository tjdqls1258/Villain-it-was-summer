using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : Skill
{
    public override void Skill_Ative()
    {
        Debug.Log("��ų 1 �ߵ�");
    }
    public override void Passive_Ative()
    {
        Debug.Log("�нú�");
    }
    public override void Cancel_Skill()
    {
        Debug.Log("��ų �� �ߵ�");
    }
}
