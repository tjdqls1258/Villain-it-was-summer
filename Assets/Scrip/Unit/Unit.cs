using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum State { IDLE, MOVE, ATK, HIT, DIE }
    public State state = State.IDLE;
    public float fDistance = 2f;
    public float fMove_Spd = 1f;
    public float fAttack_Delay = 3f;
    public float MaxHp = 100;
    public float fHP = 100;
    public float fDash_Power = 5.0f;
    public int iMP = 0;
    public int iAD = 10;
    public int iAP = 10;
    public int iDEF = 5;
    public int iMDEF = 5;

    public List<Skill> skill_list;

    private void OnEnable()
    {
        fHP = MaxHp;
    }

    public void Change_State(Unit.State state)
    {
        this.state = state;
    }

    public Skill Find_Skill_With_Tag(string _tag)
    {
        int index = skill_list.FindIndex(index => index.skill_data.Skill_Tag == _tag);
        return skill_list[index];
    }

    public Skill[] Find_Skills_With_Tag(string _tag)
    {
        List<Skill> skills = new List<Skill>();
        skills = skill_list.FindAll(index => index.skill_data.Skill_Tag == _tag);
        return skills.ToArray();
    }
}
