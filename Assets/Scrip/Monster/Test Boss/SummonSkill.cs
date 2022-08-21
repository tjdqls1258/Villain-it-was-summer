using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonSkill : Skill
{
    public GameObject Summon_Prefap;
    public int MaxSummon;
    public int count;
    public bool Skill_Delay;
    public Animation_Controller animation_Con;

    [SerializeField] List<GameObject> Pool = new List<GameObject>();

    private void Awake()
    {
        for(int i= 0; i <= MaxSummon; i++)
        {
            GameObject SummonObject = Instantiate(Summon_Prefap);
            Pool.Add(SummonObject);
            SummonObject.SetActive(false);
        }
        Skill_Delay = false;
    }
    public override void Skill_Ative()
    {
        if(Skill_Delay)
        {
            return;
        }
        Skill_Delay = true;

        for(int i = 0; i < Pool.Count; i++)
        {
            if( Pool[i].activeInHierarchy == false)
            {
                Pool[i].transform.position = 
                    new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y + 1, transform.position.z);
                Pool[i].SetActive(true);
            }
        }
        StartCoroutine(Skill_Delay_Timmer());
    }

    private IEnumerator Skill_Delay_Timmer()
    {
        yield return new WaitForSeconds(10.0f);
        Skill_Delay = false;
    }

    public override void Cancel_Skill()
    {
        
    }
}
