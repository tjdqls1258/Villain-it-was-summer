using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill : MonoBehaviour
{
    public List<Skill> Skill_List = new List<Skill>();
    public Skill skill01, skill02;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponentInChildren<Animator>().SetTrigger("Skill");
            skill01.Skill_Ative();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponentInChildren<Animator>().SetTrigger("Skill");
            skill02.Skill_Ative();
        }
    }
}
