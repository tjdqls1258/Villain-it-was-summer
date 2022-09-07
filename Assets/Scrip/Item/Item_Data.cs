using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Data : MonoBehaviour
{
    [Header("Item Information")]
    public bool Is_Twohand;
    public int Damage;
    public float Add_Hp;
    public Equipment_Type Item_Type;

    public float Atk_Speed;
    public float Move_Speed;

    public Sprite[] Item_Image;
    public Skill Skill;
}
