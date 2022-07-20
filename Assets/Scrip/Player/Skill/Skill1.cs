using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : Skill
{
    public override void Skill_Ative()
    {
        Debug.Log("스킬 1 발동");
    }
    public override void Passive_Ative()
    {
        Debug.Log("패시브");
    }
    public override void Cancel_Skill()
    {
        Debug.Log("스킬 끝 발동");
    }
}
