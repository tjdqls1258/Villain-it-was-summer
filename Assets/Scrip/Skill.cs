using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Skill_Type { Start = -1,PASSIVE, ACTIVE, End }

[System.Serializable]
public class Skill_Data
{
    public string SkillName;
    public Skill_Type skill_Type = Skill_Type.ACTIVE;
    public string Skill_Tag = "None";
    public float Skill_CoolTime = 10f;
}

public abstract class Skill : MonoBehaviour
{
    public Skill_Data skill_data = new Skill_Data();
    public GameObject Skill_Effect_List;
    public Sprite Skill_Icon;
    public abstract void Skill_Ative();
    public abstract void Cancel_Skill();
}
