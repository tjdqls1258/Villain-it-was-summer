using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Player_Move : MonoBehaviour
{
    //public KeyCode Move_Left, Move_Right, Jump, ATK;
    public float Move_Speed = 1.0f;
    public float Jump_Power = 5.0f;
    public float Dash_Power = 5.0f;
    public float ATK_Delay = 0.5f;

    private bool Is_ATK;
    private bool Is_Dsah;

    private Rigidbody2D rigid;
    [SerializeField] private GameObject Down_Collider;
    [SerializeField] private GameObject ATK_Area;
    [SerializeField] private GameObject Dash_Effect;
    [SerializeField] private GameObject Unit_To_Player;
    [SerializeField] private Animator animator;
    public GameObject ATK_Ation;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Is_ATK = true;
        Is_Dsah = true;
    }

    private void Update()
    {
        if(rigid.velocity.x != 0.0f)
        {
            return;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Move(Vector3.left);
            Unit_To_Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(Vector3.right);
            Unit_To_Player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetFloat("Move_Speed", 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(Input.GetKey(KeyCode.Z) && Is_ATK)
        {
            Is_ATK = false;
            ATK_Ation.SetActive(true);
            animator.SetTrigger("ATK");
            StartCoroutine(ATK());
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

            rigid.AddForce(Vector2.up * Jump_Power, ForceMode2D.Impulse);
        }
    }

    private void Move(Vector3 _move)
    {
        transform.position += _move * Move_Speed * Time.deltaTime;
        animator.SetFloat("Move_Speed", 1.0f);
        ATK_Area.transform.position = transform.position + _move * 1.165f;
        if (Input.GetKeyDown(KeyCode.X) && Is_Dsah)
        {
            Dash(_move);
        }
    }
    private void Dash(Vector2 _Dash_Vector)
    {
        Is_Dsah = false;
        rigid.AddForce(_Dash_Vector * Dash_Power, ForceMode2D.Impulse);
        StartCoroutine(Dash_Timmer());
    }
    
    private IEnumerator ATK()
    {
        yield return new WaitForSeconds(0.2f);
        ATK_Ation.SetActive(false);
        yield return new WaitForSeconds(ATK_Delay - 0.2f);
        Is_ATK = true;
    }

    private IEnumerator Dash_Timmer()
    {
        Dash_Effect.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        rigid.velocity = new Vector3(0.0f, rigid.velocity.y, 0.0f);
        Dash_Effect.SetActive(false);
        Is_Dsah = true;
    }
}
