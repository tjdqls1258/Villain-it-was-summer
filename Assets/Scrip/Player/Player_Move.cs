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
            transform.position += Vector3.left * Move_Speed *Time.deltaTime;
            ATK_Area.transform.position = transform.position + Vector3.left * 1.165f;
            if (Input.GetKeyDown(KeyCode.X) && Is_Dsah)
            {
                Dash(Vector3.left);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Move_Speed * Time.deltaTime;
            ATK_Area.transform.position = transform.position + Vector3.right * 1.165f;
            if (Input.GetKeyDown(KeyCode.X) && Is_Dsah)
            {
                Dash(Vector3.right);
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Down_Collider.GetComponent<Player_Down_Jump>().ChangeLayer();
            }
            else
            {
                Jump();
            }
        }

        if(Input.GetKey(KeyCode.Z) && Is_ATK)
        {
            Is_ATK = false;
            ATK_Ation.SetActive(true);
            StartCoroutine(ATK());
        }

    }

    private void Jump()
    {
        if(Mathf.Abs(rigid.velocity.y) > 0)
        {
            return;
        }

        rigid.AddForce(Vector2.up * Jump_Power , ForceMode2D.Impulse);
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
