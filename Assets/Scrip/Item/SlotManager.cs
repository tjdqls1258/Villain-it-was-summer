using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public Item_Slot[] Accessories_Slot;

    public Item_Slot Left_Weapon_Slot;
    public Item_Slot Right_Weapon_Slot;

    public Item_Slot Helmet_Slot;
    public Item_Slot Amror_Slot;
    
    public bool Is_ToHand = false;

    private uint CurrentAccessories = 0;
    public void Equip_Item(Item_Data item, int SeletAccessories)
    {
        switch(item.Item_Type)
        {
            case Equipment_Type.Amror:
                Amror_Slot.Set_Item(item);
                break;

            case Equipment_Type.Helmet:
                Helmet_Slot.Set_Item(item);
                break;

            case Equipment_Type.Left_Weapon:
                Left_Weapon_Slot.Set_Item(item);
                if(Left_Weapon_Slot.item.Is_Twohand)
                {
                    Right_Weapon_Slot.enabled = false;
                }
                break;

            case Equipment_Type.Right_Weapon:
                Right_Weapon_Slot.Set_Item(item);
                break;

            case Equipment_Type.Accessories:
                if (CurrentAccessories < Accessories_Slot.Length)
                {
                    Accessories_Slot[CurrentAccessories].Set_Item(item);
                    CurrentAccessories++;
                }
                else 
                {
                    Accessories_Slot[SeletAccessories].Set_Item(item);
                }
                break;
        }

    }
}
