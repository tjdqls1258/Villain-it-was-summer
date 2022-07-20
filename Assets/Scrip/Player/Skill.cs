using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public enum Skill_Type { PASSIVE, ACTIVE }
    public Skill_Type skill_Type = Skill_Type.ACTIVE;
    public string Skill_Tag = "None";
    public float Skill_CoolTime = 10f;
    public abstract void Skill_Ative();
    public abstract void Passive_Ative();
    public abstract void Cancel_Skill();
}
