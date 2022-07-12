using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Event : MonoBehaviour
{
    public delegate void OnCollision(Collision2D collision);
    public delegate void OnTrigger(Collider2D collider);

    //각각 Enter(충돌 시) Stay(충돌 중) Exit(충돌 종료 시) 상황에 맞게 이벤트 등록 해서 사용
    public event OnCollision Enter;
    public event OnCollision Stay;
    public event OnCollision Exit;

    //트리거 일경우
    public event OnTrigger Trigger_Enter;
    public event OnTrigger Trigger_Stay;
    public event OnTrigger Trigger_Exit;

    private void Start()
    {
        GameObject.Find("Collision_Manger").GetComponent<Collision_Manger>().Add_Collider(this);
    }

    #region OnCollisionEnter2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Enter == null)
        {
            return;
        }
        Enter(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Stay == null)
        {
            return;
        }
        Stay(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (Exit == null)
        {
            return;
        }
        Exit(collision);
    }
    #endregion

    #region OnTriggerEnter2D

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Trigger_Enter == null)
        {
            return;
        }
        Trigger_Enter(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Trigger_Stay == null)
        {
            return;
        }
        Trigger_Stay(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Trigger_Exit == null)
        {
            return;
        }
        Trigger_Exit(collision);
    }
    #endregion
}
