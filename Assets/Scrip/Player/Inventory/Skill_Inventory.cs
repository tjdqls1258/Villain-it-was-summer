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

    public static Skill_Inventory Instance;

    [System.Serializable]
    class SkillList
    {
        public List<Skill_Data> Ative_SkillList = new List<Skill_Data>();
        public List<Skill_Data> Passive_SkillList = new List<Skill_Data>();
    }

    SkillList skillList = new SkillList();

    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }

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

    public void Add_Skill(Skill_Data _skill)
    {
        if(_skill.skill_Type <= Skill_Type.Start || _skill.skill_Type >= Skill_Type.End)
        {
            return;
        }
        switch(_skill.skill_Type)
        {
            case Skill_Type.ACTIVE:
                if (skillList.Ative_SkillList.Contains(_skill))
                {
                    break;
                }
                skillList.Ative_SkillList.Add(_skill);
                break;
            case Skill_Type.PASSIVE:
                if (skillList.Passive_SkillList.Contains(_skill))
                {
                    break;
                }
                skillList.Passive_SkillList.Add(_skill);
                break;
        }
        JsonData.Save<SkillList>(skillList, SaveFilename);
    }

    public void Set_AtiveSkill(Skill skill)
    {
        if (Selet_Ative != null)
        {
            Selet_Ative.transform.parent = Ative_ContentObject.transform;
        }
        SelectedAtiveImage.sprite = skill.Skill_Icon;
        Selet_Ative = skill;
    }
    public void Set_PassiveSkill(Skill skill)
    {
        if (Selet_Passive != null)
        {
            Selet_Passive.transform.parent = Passive_ContenObject.transform;
        }
        SelectedPassiveImage.sprite = skill.Skill_Icon;
        Selet_Passive = skill;
    }

    public void Read_ToGame()
    {
        if (Selet_Ative != null)
        {
            Selet_Ative.transform.parent = gameObject.transform;
        }
        if (Selet_Passive != null)
        {
            Selet_Passive.transform.parent = gameObject.transform;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
