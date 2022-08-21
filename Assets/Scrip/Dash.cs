using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Dash : Skill
{
    public Unit unit;

    private bool Is_Dsah;
    public Rigidbody2D rigid;
    private Vector2 _Dash_Vector;

    [SerializeField] private GameObject Dash_Effect;

    public override void Skill_Ative()
    {
        if (rigid.velocity.x != 0.0f && !Is_Dsah)
        {
            return;
        }
        Dash_ToVector();
    }
    public override void Cancel_Skill()
    {

    }
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Is_Dsah = true;
    }
    public void Set_Dash_Vector(Vector2 target)
    {
        _Dash_Vector = target;
    }

    private void Dash_ToVector()
    {
        if (Is_Dsah)
        {
            Is_Dsah = false;
            rigid.AddForce(_Dash_Vector * unit.fDash_Power, ForceMode2D.Impulse);
            StartCoroutine(Dash_Timmer());
        }
    }

    private IEnumerator Dash_Timmer()
    {
        Dash_Effect.SetActive(true);
        gameObject.layer = 11;
        yield return new WaitForSeconds(0.2f);
        gameObject.layer = 6;
        rigid.velocity = new Vector3(0.0f, rigid.velocity.y, 0.0f);
        Dash_Effect.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        Is_Dsah = true;
    }
}
