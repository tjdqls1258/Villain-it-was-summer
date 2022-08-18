using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Inventory : MonoBehaviour
{
    public Dictionary<Skill_Type, List<Skill>> Skill_List;

    public void Add_Skill(Skill _skill)
    {
        if(_skill.skill_Type <= Skill_Type.Start || _skill.skill_Type >= Skill_Type.End)
        {
            return;
        }
        Skill_List[_skill.skill_Type].Add(_skill);
    }
}
