using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Event : MonoBehaviour
{
    public delegate void OnCollision(Collision2D collision, GameObject self);
    public delegate void OnTrigger(Collider2D collider, GameObject self);

    //���� Enter(�浹 ��) Stay(�浹 ��) Exit(�浹 ���� ��) ��Ȳ�� �°� �̺�Ʈ ��� �ؼ� ���
    public event OnCollision Enter;
    public event OnCollision Stay;
    public event OnCollision Exit;

    //Ʈ���� �ϰ��
    public event OnTrigger Trigger_Enter;
    public event OnTrigger Trigger_Stay;
    public event OnTrigger Trigger_Exit;

    private void Start()
    {
        GameObject.Find("Collision_Manger").GetComponent<Collision_Manger>().Add_Collider(this, gameObject);
    }

    #region OnCollisionEnter2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Enter == null)
        {
            return;
        }
        Enter(collision, gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Stay == null)
        {
            return;
        }
        Stay(collision,gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (Exit == null)
        {
            return;
        }
        Exit(collision, gameObject);
    }
    #endregion

    #region OnTriggerEnter2D

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Trigger_Enter == null)
        {
            return;
        }
        Trigger_Enter(collision, gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Trigger_Stay == null)
        {
            return;
        }
        Trigger_Stay(collision, gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Trigger_Exit == null)
        {
            return;
        }
        Trigger_Exit(collision, gameObject);
    }
    #endregion
}
