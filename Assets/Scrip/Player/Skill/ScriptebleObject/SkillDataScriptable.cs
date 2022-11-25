using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "SkillData")]
public class SkillDataScriptable : ScriptableObject
{
    public List<GameObject> Skill_Effect_List;
    public Sprite Skill_Icon;
}
