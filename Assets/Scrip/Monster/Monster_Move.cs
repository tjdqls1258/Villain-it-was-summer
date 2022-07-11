using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Monster_Move : MonoBehaviour
{
    public Vector3 This_And_Player_Distance;
    private Vector3 Move_Vector;
    
    [SerializeField] private float Move_Speed = 1.0f;
    [SerializeField] private float See_Max_Distance = 7.0f;
    [SerializeField] private float ATK_Distance = 2.3f;
    public float Ray_Distance = 1.0f;

    private GameObject Player;
    private Animator animator;
    private SpriteRenderer sprite;

    private RaycastHit2D Is_Ground;
    private int Layer_Mask = (1 << 3 | 7);

    private void Awake()
    {
        Player = GameObject.Find("Player");
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        Look_Player();
    }

    private void Look_Player()
    {
        This_And_Player_Distance = Player.transform.position - transform.position;
        Is_Ground = Physics2D.Raycast(transform.position, -transform.up, Ray_Distance, Layer_Mask);
        if (!Is_Ground)
        {
            Move_Vector = This_And_Player_Distance.normalized;
            Move_Vector.y = 0;
            Move_Vector.z = 0;
            transform.position -= Move_Vector * Move_Speed * Time.deltaTime;
            animator.SetFloat("Move_Speed", 0);
            return;
        }

        if (Mathf.Abs(This_And_Player_Distance.y) < 0.2f)
        {
            if (This_And_Player_Distance.x > 0.0f)
            {
                sprite.flipX = false;
            }
            else if (This_And_Player_Distance.x < 0.0f)
            {
                sprite.flipX = true;
            }

            if (Vector3.Distance(transform.position, Player.transform.position) <= ATK_Distance)
            {
                if (!(animator.GetCurrentAnimatorStateInfo(0).IsName("ATK")))
                {
                    GetComponentInChildren<Monster_ATK>().Monster_ATK_Start();
                    animator.SetFloat("Move_Speed", 0);
                    animator.SetTrigger("ATK");
                }
            }
            else if(Mathf.Abs(This_And_Player_Distance.x) <= See_Max_Distance)
            {
                Move_Vector = This_And_Player_Distance.normalized;
                Move_Vector.y = 0;
                Move_Vector.z = 0;
                animator.SetFloat("Move_Speed", Move_Speed);
                transform.position += Move_Vector * Move_Speed * Time.deltaTime;
            }
            else
            {
                animator.SetFloat("Move_Speed", 0);
            }
        }
        else
        {
            animator.SetFloat("Move_Speed", 0);
        }
    }
}
