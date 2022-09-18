using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Data : MonoBehaviour
{
    [Header("Item Information")]
    public bool Is_Twohand; //������� ����ϴ� �������� �Ǻ�
    public int Damage;

    public Equipment_Type Item_Type;

    public float Add_Hp;
    public float Atk_Speed;
    public float Move_Speed;

    public string Explanation_Item;

    public Sprite[] Item_Image;
    public Skill Skill;
}
