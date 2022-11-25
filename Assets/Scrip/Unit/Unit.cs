using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //��� ������ �⺻ ������ (�÷��̾�, ���� ��)
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

    //���� �ٲٴ� �Լ�.
    public void Change_State(Unit.State state)
    {
        this.state = state;
    }
    //��ų�� �±װ� �ִµ� ��ų����Ʈ ������ �ش� �±׸� ���� �ش� ��ų�� ã��.
    public Skill Find_Skill_With_Tag(string _tag)
    {
        int index = skill_list.FindIndex(index => index.skill_data.Skill_Tag == _tag);
        //��ã���� -1 ��ȯ
        if(index < 0)
        {
            return null;
        }
        return skill_list[index];
    }

    //�ش� �±׸� ���� ��� ��ų�� ã�� (������ ������ �����ϴ��� ���� �Ǵܿ� ����.)
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
