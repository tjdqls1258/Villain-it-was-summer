using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : Skill
{
    public Unit unit;
    public Animation_Controller animation_Con;
    private Vector3 Target;
    private Vector3 Local_Size;
    private Rigidbody2D rigid;
    private RaycastHit2D hit;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Local_Size = transform.localScale;
    }

    public override void Skill_Ative()
    {
        Vector3 Dir_Pos = Target;
        Dir_Pos.y = 0;
        Dir_Pos.z = 0;

        transform.position += Dir_Pos * unit.fMove_Spd * Time.deltaTime;
        if (Dir_Pos.x < 0)
        {
            transform.localScale = new Vector3(Local_Size.x, Local_Size.y, Local_Size.z);
        }
        else if(Dir_Pos.x > 0)
        {
            transform.localScale = new Vector3(-Local_Size.x, Local_Size.y, Local_Size.z);
        }
        animation_Con.Is_Move(Target.magnitude);
    }

    public void Set_Target_pos(Vector3 _target)
    {
        Target = _target;
    }

    public override void Cancel_Skill()
    {
        animation_Con.Is_Move(0);
        Target = Vector3.zero;
    }
}
