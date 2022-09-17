using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�ش� �������� ��� �κп� �����ϴ� ����������.
public enum Equipment_Type
{
    Start_Enum = -1,
    Helmet,
    Left_Weapon,
    Right_Weapon,
    TwoHand_Weapon,
    Amror,
    Accessories,
    end
};

//�������� ������ ���� Ŭ����
public class Item_Slot : MonoBehaviour
{
    //������ ������(�������� ��ų, Ÿ��, ���� ��)
    public Item_Data item;
    //�������� ���������� �ش� ���������� ��ü���� SpriteRenderer
    public SpriteRenderer[] Items_Image;
    public Equipment_Type type;
    public bool Is_Skill_Ative = false;

    public void Set_Item(Item_Data item_Data)
    {
        if (item != null)
        {
            item.Skill.Cancel_Skill();
            Destroy(item.gameObject);
        }//���� �������� ���� ��� �ش� �������� ��ų�� Cancel �ϰ� �������� �����Ѵ�.

        //������ �����Ͱ� ���� ��� (EX ���� ��� ���⿡�� �Ѽչ���� �����) Ȥ�� �������� ������
        if (item_Data == null)
        {
            item = null;
            for (int i = 0; i < Items_Image.Length; i++)
            {
                Items_Image[i].enabled = false;
            }
            return;
        }

        //�ش� ������ �´��� �Ǻ� �� ����.
        if (type == item_Data.Item_Type)
        {
            item = item_Data;
            item_Data.transform.SetParent(this.transform);

            for (int i = 0; i < Items_Image.Length; i++)
            {
                Items_Image[i].enabled = true;
                Items_Image[i].sprite = item_Data.Item_Image[i];
            }
        }
    }

    private void OnDisable()
    {
        if(item == null)
        {
            return;
        }
        item.Skill.Cancel_Skill();
        for (int i = 0; i < Items_Image.Length; i++)
        {
            Items_Image[i].enabled = false;
        }
    }

    private void Update()
    {
        //�������� ������ �� �ش� �������� ��Ƽ�� ���� (��Ÿ�� 30�� ������ 1ȸ �����ش�.)�� ���� �нú� ���·� ������ 
        //Ȱ��ȭ�Ѵ�.
        if (item != null)
        {
            if (!Is_Skill_Ative)
            {
                Is_Skill_Ative = true;
                item.Skill.Skill_Ative();
            }
        }
    }
}
