using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill : MonoBehaviour
{
    public Skill skill01, skill02;
    public Transform ATK_area;
    private void Awake()
    {
        GameObject skill_manager = GameObject.Find("Skill Manager");
        if (skill_manager == null)
        {
            //return;
        }
        //skill01 = skill_manager.GetComponent<Skill_Inventory>().Selet_Ative;
        //skill02 = skill_manager.GetComponent<Skill_Inventory>().Selet_Passive;
        if (skill01 != null)
        {
            gameObject.AddComponent(skill01.GetType());
        }
        if (skill02 != null)
        {
            gameObject.AddComponent(skill02.GetType());
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponentInChildren<Animator>().SetTrigger("Skill");
            Instantiate(skill01.Skill_Effect_List, ATK_area.position, Quaternion.identity);
            skill01.Skill_Ative();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponentInChildren<Animator>().SetTrigger("Skill");
            if (skill02 != null)
            {
                skill02.Skill_Ative();
            }
        }
    }
}
