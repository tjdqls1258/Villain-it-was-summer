using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower_ATK : Skill
{
    public Unit unit;
    public Animation_Controller animation_Con;
    public GameObject DangerSingleObject;
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
        unit.Change_State(Unit.State.Skill);
        ATK_AreaOn();
        yield return new WaitForSeconds(unit.fAttack_Delay);
        unit.Change_State(Unit.State.IDLE);
        Is_ATK = true;
    }

    public void ATK_AreaOn()
    {
        DangerSingleObject.transform.position = GameObject.Find("Player").transform.position;
        DangerSingleObject.SetActive(true);
        ATK_AreaOff();
    }

    public void ATK_AreaOff()
    {
        unit.Change_State(Unit.State.IDLE);
    }
}
