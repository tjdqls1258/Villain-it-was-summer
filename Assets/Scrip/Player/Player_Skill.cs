using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Skill : MonoBehaviour
{
    public Skill skill01, skill02;
    public Transform ATK_area;
    public Image Ative_Skill;
    public Image Passive_Skill;

    private void Awake()
    {
        //스킬 메니저를 찾아서 스킬을 등록함.
        GameObject skill_manager = GameObject.Find("Skill Manager");
        if (skill_manager == null)
        {
            return;
        }
        skill01 = skill_manager.GetComponent<Skill_Inventory>().Selet_Ative;
        skill02 = skill_manager.GetComponent<Skill_Inventory>().Selet_Passive;

        if (skill01 != null)
        {
            skill01.transform.GetComponent<Button>().enabled = false;
            skill01.transform.GetComponent<Image>().enabled = false;
            Ative_Skill.sprite = skill01.Skill_Icon;
        }
        if (skill02 != null)
        {
            skill02.transform.GetComponent<Button>().enabled = false;
            skill02.transform.GetComponent<Image>().enabled = false;
            Passive_Skill.sprite = skill02.Skill_Icon;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(skill01 == null)
            {
                return;
            }
            GetComponentInChildren<Animator>().SetTrigger("Skill");

            if (skill01.Skill_Effect_List != null)
            {
                Instantiate(skill01.Skill_Effect_List, ATK_area.position, Quaternion.identity);
            }
            skill01.Skill_Ative();
        }
    }
}
