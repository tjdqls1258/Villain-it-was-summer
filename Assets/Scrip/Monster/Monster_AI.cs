using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Monster_AI : MonoBehaviour
{
    public Vector3 This_And_Player_Distance;
    
    [SerializeField] private float See_Max_Distance = 7.0f;
    [SerializeField] private float ATK_Distance = 2.3f;
    public float Ray_Distance = 1.0f;

    private GameObject Player;
    public Monster monster;

    private RaycastHit2D Is_Ground;
    private int Layer_Mask = (1 << 3 | 7);

    private void Awake()
    {
        Player = GameObject.Find("Player");
        monster = GetComponent<Monster>();
    }

    private void Update()
    {
        Look_Player();
    }

    private void Look_Player()
    {
        This_And_Player_Distance = Player.transform.position - transform.position;
        Is_Ground = Physics2D.Raycast(transform.position, -transform.up, Ray_Distance, Layer_Mask);
        Move move = (Move)monster.Find_Skill_With_Tag("Move");
        if (!Is_Ground)
        {
            move.Set_Target_pos(-This_And_Player_Distance.normalized);
            move.Skill_Ative();
            return;
        }

        if (Mathf.Abs(This_And_Player_Distance.y) < 0.2f)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) <= ATK_Distance)
            {
                Nomal_ATK atk = (Nomal_ATK)monster.Find_Skill_With_Tag("ATK");
                if (atk.Is_ATK)
                {
                    move.Cancel_Skill();
                    atk.Skill_Ative();
                }
            }
            else if(Mathf.Abs(This_And_Player_Distance.x) <= See_Max_Distance)
            {
                move.Set_Target_pos(This_And_Player_Distance.normalized);
                move.Skill_Ative();
            }
            else
            {
                move.Cancel_Skill();
            }
        }
        else
        {
            move.Cancel_Skill();
        }
    }
}
