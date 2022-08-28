using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomal_ATK : Skill
{
    public Unit unit;
    public Animation_Controller animation_Con;
    [SerializeField] private GameObject ATK_Area;
    public bool Is_ATK;

    private void Awake()
    {
        Is_ATK = true;
    }

    public override void Skill_Ative()
    {
        if(!Is_ATK)
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
        yield return new WaitForSeconds(0.1f);
        ATK_Area.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        ATK_Area.SetActive(false);
        unit.Change_State(Unit.State.IDLE);
        yield return new WaitForSeconds(unit.fAttack_Delay - 0.2f);
        Is_ATK = true;
    }
}
