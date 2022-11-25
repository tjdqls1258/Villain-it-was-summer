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
    private Hit hit;
    private Rigidbody2D rigid;
    public GameObject DangerSing;
    private Cam_Shacking cam;


private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        cam = GetComponent<Cam_Shacking>();
        rigid = GetComponent<Rigidbody2D>();
        move = (Move)player.Find_Skill_With_Tag("Move");
        atk = (Nomal_ATK)player.Find_Skill_With_Tag("ATK");
        dash = (Dash)player.Find_Skill_With_Tag("Dash");
        hit = GetComponent<Hit>();
    }

    private void Update()
    {
        if (player.state == Unit.State.DIE)
        {
            return;
        }

        #region Movement
        move.Set_Target_pos((transform.right * Input.GetAxis("Horizontal")));
        move.Skill_Ative();
        

        if (Input.GetKeyDown(KeyCode.X))
        {
            dash.Set_Dash_Vector(Vector3.left);
            dash.Skill_Ative();
        }

        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            move.Cancel_Skill();
            player.Change_State(Unit.State.IDLE);
        }
        else
        {
            player.Change_State(Unit.State.MOVE);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Z) && atk.Is_ATK)
        {
            Debug.Log("AKT");
            move.Cancel_Skill();
            atk.Skill_Ative();
        }
        #endregion

        if (hit.Is_Hit)
        {
            StartCoroutine(cam.CameraShake(0.1f, 0.01f, hit.Hit_Invincible_Time));
            StartCoroutine(cam.ChagePost(0.1f, hit.Hit_Invincible_Time));
        }
    }

    private void LateUpdate()
    {
        if (player.fHP <= (player.MaxHp * 0.2f))
        {
            DangerSing.SetActive(true);
        }
        else
        {
            DangerSing.SetActive(false);
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
            player.Change_State(Unit.State.MOVE);
            rigid.AddForce(Vector2.up * player.Jump_Power, ForceMode2D.Impulse);
        }
    }
}
