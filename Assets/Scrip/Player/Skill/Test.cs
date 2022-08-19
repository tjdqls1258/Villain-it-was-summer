using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Skill[] skills;
    public Skill_Inventory skillInven;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            skills = gameObject.GetComponents<Skill>();
            for (int i = 0; i < skills.Length; i++)
            {
                skillInven.Add_Skill(skills[i].skill_data);
            }
        }
    }
}
