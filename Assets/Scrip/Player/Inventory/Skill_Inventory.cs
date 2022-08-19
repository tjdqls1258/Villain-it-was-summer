using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;
using System.Reflection;

public class Skill_Inventory : MonoBehaviour
{
    public string SaveFilename;
    public Skill Selet_Ative;
    public Skill Selet_Passive;
    public GameObject Skill_Selet_Butten;

    public GameObject Ative_ContentObject;
    public GameObject Passive_ContenObject;

    public Image SelectedAtiveImage;
    public Image SelectedPassiveImage;

    [System.Serializable]
    class SkillList
    {
        public List<Skill.Skill_Data> Ative_SkillList = new List<Skill.Skill_Data>();
        public List<Skill.Skill_Data> Passive_SkillList = new List<Skill.Skill_Data>();
    }

    SkillList skillList = new SkillList();

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Assembly assembly = Assembly.GetExecutingAssembly();

        string SaveFile = JsonData.Load(SaveFilename);
        if(SaveFile != null)
        {
            skillList = JsonUtility.FromJson<SkillList>(SaveFile);
        }
        else
        {
            JsonData.Save<SkillList>(skillList, SaveFilename);
        }

        if (SceneManager.GetActiveScene().name == "Ready")
        {
            for (int i = 0; i < skillList.Ative_SkillList.Count; i++)
            {
                GameObject selet_buten = Instantiate(Skill_Selet_Butten);

                Type Compoent_Type = assembly.GetType(skillList.Ative_SkillList[i].SkillName);
                if(Compoent_Type == null)
                {
                    Debug.LogError("없는 스킬 이름");
                    return;
                }
                selet_buten.AddComponent(Compoent_Type);
                selet_buten.GetComponent<Skill>().skill_data = skillList.Ative_SkillList[i];
                selet_buten.GetComponent<Button>().onClick.AddListener(() =>
                Set_AtiveSkill(selet_buten.GetComponent<Skill>()));
                selet_buten.GetComponentInChildren<Image>().sprite = selet_buten.GetComponent<Skill>().Skill_Icon;
                selet_buten.transform.parent = Ative_ContentObject.transform;
            }
            for (int i = 0; i < skillList.Passive_SkillList.Count; i++)
            {
                GameObject selet_buten = Instantiate(Skill_Selet_Butten);

                Type Compoent_Type = assembly.GetType(skillList.Passive_SkillList[i].SkillName);
                if (Compoent_Type == null)
                {
                    Debug.LogError("없는 스킬 이름");
                    return;
                }
                selet_buten.AddComponent(Compoent_Type);
                selet_buten.GetComponent<Skill>().skill_data = skillList.Passive_SkillList[i];
                selet_buten.GetComponent<Button>().onClick.AddListener(() =>
                Set_PassiveSkill(selet_buten.GetComponent<Skill>()));
                selet_buten.GetComponentInChildren<Image>().sprite = selet_buten.GetComponent<Skill>().Skill_Icon;
                selet_buten.transform.parent = Passive_ContenObject.transform;
            }
        }
    }

    public void Add_Skill(Skill.Skill_Data _skill)
    {
        if(_skill.skill_Type <= Skill_Type.Start || _skill.skill_Type >= Skill_Type.End)
        {
            return;
        }
        switch(_skill.skill_Type)
        {
            case Skill_Type.ACTIVE:
                skillList.Ative_SkillList.Add(_skill);
                break;
            case Skill_Type.PASSIVE:
                skillList.Passive_SkillList.Add(_skill);
                break;
        }
        JsonData.Save<SkillList>(skillList, SaveFilename);
    }

    public void Set_AtiveSkill(Skill skill)
    {
        SelectedAtiveImage.sprite = skill.Skill_Icon;
        Selet_Ative = skill;
        Debug.Log(skill.skill_data.SkillName);
    }
    public void Set_PassiveSkill(Skill skill)
    {
        SelectedPassiveImage.sprite = skill.Skill_Icon;
        Selet_Passive = skill;
        Debug.Log(skill.skill_data.SkillName);
    }

}
