using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum State { IDLE, MOVE, ATK, HIT }
    public State state = State.IDLE;
    public float fDistance = 2f;
    public float fMove_Spd = 1f;
    public float fAttack_Delay = 3f;
    public float iHP = 100;
    public int iMP = 0;
    public int iAD = 10;
    public int iAP = 10;
    public int iDEF = 5;
    public int iMDEF = 5;

    public void Change_State(Unit.State state)
    {
        this.state = state;
    }
}
