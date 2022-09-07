using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

public class Item_Slot : MonoBehaviour
{
    public Item_Data item;

    public SpriteRenderer[] Items_Image;
    public Equipment_Type type;
    public bool Is_Skill_Ative = false;
    private Color color_a0;

    private void Awake()
    {
        color_a0 = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        Set_Item(item);
    }

    public void Set_Item(Item_Data item_Data)
    {
        int count = 0;
        //������ �����Ͱ� ���� ��� (EX ���� ��� ���⿡�� �Ѽչ���� �����)
        //�ش� �Լ� �������� �ش� �������� ��� �߰� �ʿ�.
        if (item_Data == null)
        {
            item = null;
            foreach (SpriteRenderer spriteRender in Items_Image)
            {
                spriteRender.color = color_a0;
                count++;
            }
            return;
        }

        if (type == item_Data.Item_Type)
        {
            item = item_Data;
            foreach (SpriteRenderer spriteRender in Items_Image)
            {
                spriteRender.color = Color.white;
                spriteRender.sprite = item_Data.Item_Image[count];
                count++;
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
        int count = 0;
        foreach (SpriteRenderer spriteRender in Items_Image)
        {
            spriteRender.color = color_a0;
            count++;
        }
    }

    private void Update()
    {
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
