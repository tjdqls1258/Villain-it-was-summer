using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Player_Move : MonoBehaviour
{
    //public KeyCode Move_Left, Move_Right, Jump, ATK;
    public float Move_Speed = 1.0f;
    public float Jump_Power = 5.0f;
    public float ATK_Delay = 0.5f;

    private bool Is_ATK = true;

    private Rigidbody2D rigid;
    [SerializeField] private GameObject Down_Collider;
    [SerializeField] private GameObject ATK_Area;
    public GameObject ATK_Ation;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Move_Speed *Time.deltaTime;
            ATK_Area.transform.position = transform.position + Vector3.left * 1.165f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Move_Speed * Time.deltaTime;
            ATK_Area.transform.position = transform.position + Vector3.right * 1.165f;
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

    private IEnumerator ATK()
    {
        yield return new WaitForSeconds(0.2f);
        ATK_Ation.SetActive(false);
        yield return new WaitForSeconds(ATK_Delay - 0.2f);
        Is_ATK = true;
    }
}
