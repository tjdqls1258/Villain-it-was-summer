using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Monster_AI : MonoBehaviour
{
    public Vector3 This_And_Player_Distance;
    
    [Header("플레이어 탐지 거리 ,공격 사거리")]
    [SerializeField] private float See_Max_Distance = 7.0f;
    [SerializeField] private float ATK_Distance = 2.3f;
    public float Ray_Distance = 1.0f;

    [Header("")]
    [SerializeField]
    private GameObject Player;
    public Monster monster;

    private RaycastHit2D Is_Ground;
    private int Layer_Mask = (1 << 3) | (1 << 7);
    [SerializeField] private Skill[] Skills;
    private bool skill_on;
    //이동, 공격을 담당 하는 스킬.
    Move move;
    Nomal_ATK atk;

    int skill_number;
    private void Awake()
    {
        skill_on = true;
        skill_number = 0;
        Player = GameObject.Find("Player");
        monster = GetComponent<Monster>();
        move = (Move)monster.Find_Skill_With_Tag("Move");
        atk = (Nomal_ATK)monster.Find_Skill_With_Tag("ATK");
        Skills = monster.Find_Skills_With_Tag("Skill");
    }

    private void OnEnable()
    {
        monster.Change_State(Unit.State.IDLE);
    }

    private void Update()
    {
        if(monster.state == Unit.State.DIE)
        {
            return;
        }
        Look_Player();
        if(skill_on && Skills.Length != 0)
        {
            StartCoroutine(UsingSkill());
        }
    }
    //플레이어를 찾는 함수.
    private void Look_Player()
    {
        if(Player == null)
        {
            return;
        }
        //플레이어를 바라보는 방향과 내 앞이 땅인지 판단하는 레이를 쏜다.
        This_And_Player_Distance = Player.transform.position - transform.position;
        Is_Ground = Physics2D.Raycast(transform.position, -transform.up, Ray_Distance, Layer_Mask);
        
        //땅이 아니면 반대로 이동.
        if (!Is_Ground)
        {
            Debug.Log("Is not Land");
            move.Set_Target_pos(-This_And_Player_Distance.normalized);
            move.Skill_Ative();
            monster.Change_State(Unit.State.MOVE);
            return;
        }

        //플레이어가 같은 플랫폼 위에있는지 판단 후  
        //공격 사거리을 판별해서 그에 맞는 행동을 함. 
        if (Mathf.Abs(This_And_Player_Distance.y) < 0.5f)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) <= ATK_Distance)
            {
                if ( (atk.Is_ATK)&& (monster.state != Unit.State.ATK) )
                {
                    move.Cancel_Skill();
                    atk.Skill_Ative();
                    monster.Change_State(Unit.State.ATK);
                }
            }
            else if(Mathf.Abs(This_And_Player_Distance.x) <= See_Max_Distance)
            {
                move.Set_Target_pos(This_And_Player_Distance.normalized);
                move.Skill_Ative();
                monster.Change_State(Unit.State.MOVE);
            }
            else
            {
                move.Cancel_Skill();
                monster.Change_State(Unit.State.IDLE);
            }
        }
        else
        {
            move.Cancel_Skill();
            monster.Change_State(Unit.State.IDLE);
        }
    }

    private IEnumerator UsingSkill()
    {
        //일반 공격 중이 아니거나 스킬을 사용 가능할 경우 공격 사거리내에 있는 플레이어에게 스킬을 사용함. 
        if (monster.state != Unit.State.ATK || !skill_on)
        {
            yield break;
        }

        if (Vector3.Distance(transform.position, Player.transform.position) <= ATK_Distance)
        {
            skill_number = Random.Range(0, Skills.Length-1);
            Debug.Log(Skills.Length);
            if (Skills[skill_number] == null)
            {
                yield break;
            }
            Skills[skill_number].Skill_Ative();
            yield return new WaitForSeconds(5.0f);
        }
    }
}
