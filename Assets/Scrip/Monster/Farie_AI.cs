using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Farie_AI : MonoBehaviour
{
    [Header("")]
    public Monster monster;

    //이동, 공격을 담당 하는 스킬.
    Farie_ATK atk;

    private void Awake()
    {
        monster = GetComponent<Monster>();
        atk = (Farie_ATK)monster.Find_Skill_With_Tag("ATK");
    }

    private void OnEnable()
    {
        monster.Change_State(Unit.State.IDLE);
    }

    private void Update()
    {
        if (monster.state == Unit.State.DIE)
        {
            return;
        }
        ATK_Ation();
    }

    private void ATK_Ation()
    {
        atk.Skill_Ative();
        monster.Change_State(Unit.State.ATK);
    }
}
