using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Player_Move : MonoBehaviour
{
    //public KeyCode Move_Left, Move_Right, Jump, ATK;
    [SerializeField] private GameObject Down_Collider;

    public Player player;
    private Move move;
    private Nomal_ATK atk;
    private Dash dash;
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        move = (Move)player.Find_Skill_With_Tag("Move");
        atk = (Nomal_ATK)player.Find_Skill_With_Tag("ATK");
        dash = (Dash)player.Find_Skill_With_Tag("Dash");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move.Set_Target_pos(-transform.right);
            move.Skill_Ative();
            if (Input.GetKeyDown(KeyCode.X) )
            {
                dash.Set_Dash_Vector(Vector3.left);
                dash.Skill_Ative();
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move.Set_Target_pos(transform.right);
            move.Skill_Ative();
            if (Input.GetKeyDown(KeyCode.X))
            {
                dash.Set_Dash_Vector(Vector3.right);
                dash.Skill_Ative();
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            move.Cancel_Skill();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Z) && atk.Is_ATK)
        {
            move.Cancel_Skill();
            atk.Skill_Ative();
        }
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Down_Collider.GetComponent<Player_Down_Jump>().ChangeLayer();
        }
        else
        {
            if (Mathf.Abs(rigid.velocity.y) > 0)
            {
                return;
            }

            rigid.AddForce(Vector2.up * player.Jump_Power, ForceMode2D.Impulse);
        }
    }
}
