using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farie_ATK : Skill
{
    public Unit unit;
    public Animation_Controller animation_Con;

    public float SkillSize = 4f;
    public float Heal = 1f;
    public bool Is_ATK;

    private void Awake()
    {
        Is_ATK = true;
    }

    public override void Skill_Ative()
    {
        if (!Is_ATK)
        {
            return;
        }
        Is_ATK = false;
        animation_Con.Toggle_ATK();
        StartCoroutine(ATK());
    }

    public override void Cancel_Skill()
    {

    }

    private IEnumerator ATK()
    {
        unit.Change_State(Unit.State.ATK);
        yield return new WaitForSeconds(unit.fAttack_Delay);
        Is_ATK = true;
    }

    public void ATK_AreaOn()
    {
        Collider2D[] Hits = Physics2D.OverlapBoxAll(transform.position, Vector2.one * SkillSize, 0);
        for(int i = 0; i < Hits.Length; i++)
        {
            if (Hits[i].gameObject.CompareTag("Player"))
            {
                continue;
            }
            try
            {
                Hits[i].GetComponent<Unit>().fHP =
                    Hits[i].GetComponent<Unit>().fHP + Heal <= Hits[i].GetComponent<Unit>().MaxHp ?
                    Hits[i].GetComponent<Unit>().fHP + Heal : Hits[i].GetComponent<Unit>().MaxHp;
                Debug.Log(Hits[i].name);
            }
            catch(System.Exception e) { }
        }
    }

    public void ATK_AreaOff()
    {
        unit.Change_State(Unit.State.IDLE);
    }
}
