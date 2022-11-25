using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //모든 유닛의 기본 데이터 (플레이어, 몬스터 등)
    public enum State { IDLE, MOVE, ATK, HIT, Skill, DIE }
    public State state = State.IDLE;
    public float fDistance = 2f;
    public float fMove_Spd = 1f;
    public float fAttack_Delay = 3f;
    public float MaxHp = 100;
    public float fHP = 100;
    public float fDash_Power = 5.0f;
    public int iAD = 10;

    public List<Skill> skill_list;

    private void OnEnable()
    {
        fHP = MaxHp;
    }

    //상태 바꾸는 함수.
    public void Change_State(Unit.State state)
    {
        this.state = state;
    }
    //스킬별 태그가 있는데 스킬리스트 내에서 해당 태그를 통해 해당 스킬을 찾음.
    public Skill Find_Skill_With_Tag(string _tag)
    {
        int index = skill_list.FindIndex(index => index.skill_data.Skill_Tag == _tag);
        //못찾으면 -1 반환
        if(index < 0)
        {
            return null;
        }
        return skill_list[index];
    }

    //해당 태그를 가진 모든 스킬을 찾음 (몬스터의 패턴이 존재하는지 여부 판단에 쓰임.)
    public Skill[] Find_Skills_With_Tag(string _tag)
    {
        List<Skill> skills = new List<Skill>();
        skills = skill_list.FindAll(index => index.skill_data.Skill_Tag == _tag);
        return skills.ToArray();
    }

    public void AddSkill(Skill skill) { skill_list.Add(skill); }

    public void DeletSkill(Skill skill)
    {
        skill_list.Remove(skill);
    }
}
