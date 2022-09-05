using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public Accessories_Slot[] Accessories_Slot;

    public Weapon_Slot Left_Weapon_Slot;
    public Weapon_Slot Right_Weapon_Slot;

    public Item_Slot Helmet_Slot;
    public Item_Slot Amror_Slot;

    public bool Is_ToHand = false;

    public void Amror_Equip_Item(Item_Data item)
    {
        Amror_Slot.Set_Item(item);
    }

    public void Helmet_Equip_Item(Item_Data item)
    {
        Helmet_Slot.Set_Item(item);
    }
}
