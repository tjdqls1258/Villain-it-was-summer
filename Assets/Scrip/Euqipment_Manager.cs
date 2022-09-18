using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Euqipment_Manager : MonoBehaviour
{
    public Text ExplanationText;
    public Image ItemImage;

    Item_Slot Select_Slot;

    public void Show_Euqipment(Item_Slot item_Slot)
    {
        if(item_Slot.item == null)
        {
            return;
        }
        Select_Slot = item_Slot;
        ItemImage.enabled = true;
        ItemImage.sprite = item_Slot.item.Item_Image[0];
       
        StringBuilder Explanation_Text = new StringBuilder("HP " + item_Slot.item.Add_Hp + "\n추가 공격력  " + item_Slot.item.Damage
            + "\n공격 속도 " + item_Slot.item.Atk_Speed + "\n이동 속도 " + item_Slot.item.Move_Speed + "\n\n" + item_Slot.item.Explanation_Item);

        ExplanationText.text = Explanation_Text.ToString();
    }

    public void DropItem()
    {
        if (Select_Slot != null)
        {
            ItemImage.enabled = false ;
            ExplanationText.text = "";
            Select_Slot.Set_Item(null);
        }
    }
}
