using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBossAI : MonoBehaviour
{
    private Transform PlayerTr;
    public Monster monster;
    [SerializeField] private Skill[] Skills;
    private bool skill_on;
    int skill_number;

    private void Awake()
    {
        skill_number = 0;
        PlayerTr = GameObject.Find("Player").transform;
        monster = GetComponent<Monster>();
    }

    private void OnEnable()
    {
        monster.Change_State(Unit.State.IDLE);
        StartCoroutine(UsingSkill());
    }

    private IEnumerator UsingSkill()
    {
        //일반 공격 중이 아니거나 스킬을 사용 가능할 경우 공격 사거리내에 있는 플레이어에게 스킬을 사용함. 
        while (true)
        {
            if (monster.state == Unit.State.IDLE)
            {
                yield return new WaitForSeconds(5.0f);
                skill_number = Random.Range(0, Skills.Length);
                if (Skills[skill_number] == null)
                {
                    yield break;
                }
                Debug.Log(skill_number);
                Skills[skill_number].Skill_Ative();
            }
            else
            {
                yield return null;
            }
        }
    }
}
