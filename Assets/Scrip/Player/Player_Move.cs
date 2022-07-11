using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Player_Move : MonoBehaviour
{
    public float Move_Speed = 1.0f;
    public float Jump_Power = 5.0f;

    private Rigidbody2D rigid;
    [SerializeField] private GameObject Down_Collider;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Move_Speed *Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Move_Speed * Time.deltaTime;
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
    }

    private void Jump()
    {
        if(Mathf.Abs(rigid.velocity.y) > 0)
        {
            return;
        }

        rigid.AddForce(Vector2.up * Jump_Power , ForceMode2D.Impulse);
    }
}
