using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//해당 아이템이 어느 부분에 착용하는 아이템인지.
public enum Equipment_Type
{
    Start_Enum = -1,
    Shoes,
    Left_Weapon,
    Right_Weapon,
    TwoHand_Weapon,
    Amror,
    Accessories,
    end
};

//아이템을 착용할 슬롯 클래스
public class Item_Slot : MonoBehaviour
{
    public Image Euqiment_image;
    //아이템 데이터(아이템의 스킬, 타입, 스텟 등)
    public Item_Data item;
    //아이템을 착용했을때 해당 아이템으로 교체해줄 SpriteRenderer
    public SpriteRenderer[] Items_Image;
    public Equipment_Type type;
    public bool Is_Skill_Ative = false;

    private void Awake()
    {
        Set_Item(item);
    }

    public void Set_Item(Item_Data item_Data)
    {
        if (item != null)
        {
            item.Skill.Cancel_Skill();
            Destroy(item.gameObject);
        }//현재 아이템이 있을 경우 해당 아이템의 스킬을 Cancel 하고 아이템을 제거한다.

        //아이템 데이터가 없는 경우 (EX 무기 양손 무기에서 한손무기로 변경시) 혹은 아이템을 버릴시
        if (item_Data == null)
        {
            item = null;
            for (int i = 0; i < Items_Image.Length; i++)
            {
                Items_Image[i].enabled = false;
                Euqiment_image.sprite = null;
                Euqiment_image.enabled = false;
            }
            return;
        }

        //해당 부위가 맞는지 판별 후 착용.
        if (type == item_Data.Item_Type)
        {
            item = item_Data;
            item_Data.transform.SetParent(this.transform);

            for (int i = 0; i < Items_Image.Length; i++)
            {
                Items_Image[i].enabled = true;
                Items_Image[i].sprite = item_Data.Item_Image[i];
            }
            Euqiment_image.sprite = item_Data.Item_Image[0];
            Euqiment_image.enabled = true;
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
        //아이템이 존재할 때 해당 아이템이 엑티브 형태 (쿨타임 30초 공격을 1회 막아준다.)일 경우와 패시브 형태로 나누어 
        //활성화한다.
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
