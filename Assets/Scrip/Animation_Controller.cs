using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controller : MonoBehaviour
{
    public Animator Animator_Con;

    private void Awake()
    {
        Animator_Con = GetComponentInChildren<Animator>();
    }

    public void Is_Move(float _moveSpeed)
    {
        Animator_Con.SetFloat("Move_Speed", _moveSpeed);
    }

    public void Toggle_ATK()
    {
        Animator_Con.SetTrigger("ATK");
    }
    
    public void Toggle_ATV_Skill()
    {
        Animator_Con.SetTrigger("Skill");
    }

    public void Toggle_Hit()
    {
        Animator_Con.SetTrigger("Hit");
    }

    public void Toggle_Die()
    {
        Animator_Con.SetTrigger("Dead");
    }

    public float CurrentAnimationLength()
    {
        return Animator_Con.GetCurrentAnimatorStateInfo(0).length;
    }
}
