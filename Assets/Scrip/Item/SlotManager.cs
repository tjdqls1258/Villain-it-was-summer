using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    private Player player_Unit;

    public Item_Slot[] Accessories_Slot;

    public Item_Slot Left_Weapon_Slot;
    public Item_Slot Right_Weapon_Slot;
    public Item_Slot Helmet_Slot;
    public Item_Slot Amror_Slot;

    public bool Is_ToHand = false;

    //�߰� ���� ����.
    public int Add_Damage = 0;
    public float Add_Hp = 0;
    public float Add_Atk_Speed;
    public float Add_Move_Speed;

    private uint CurrentAccessories = 0;

    Collider2D Coll_Item;

    public void Awake()
    {
        player_Unit = GetComponentInParent<Player>();
        Reset_State();
        Add_ItemState_To_Player();
    }

    public void Equip_Item(Item_Data item)
    {
        Reset_State();//������ ������ ���� ��Ű��

        //�������� ��ü��
        switch (item.Item_Type)
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
                    Right_Weapon_Slot.Set_Item(null);
                }
                break;

            case Equipment_Type.Right_Weapon:
                if (Left_Weapon_Slot.item != null)
                {
                    if (Left_Weapon_Slot.item.Is_Twohand)
                    {
                        break;
                    }
                }

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
                    //��� ������ ���� �����ϰ� �ؾ���.
                    return;
                }
                break;
        } 

        Add_ItemState_To_Player(); //������ �߰���Ų��.
    }

    public void Add_ItemState_To_Player()
    {
        foreach (Item_Slot AccessoriesItems in Accessories_Slot)
        {
            Add_State(AccessoriesItems.item);
        }
        Add_State(Left_Weapon_Slot.item);
        Add_State(Right_Weapon_Slot.item);
        Add_State(Helmet_Slot.item);
        Add_State(Amror_Slot.item);
        Set_Player_State(Add_Damage, Add_Hp, Add_Move_Speed, Add_Atk_Speed);
    }

    //�ݺ��� ���̱� ���� �Լ�.
    private void Add_State(Item_Data item)
    {
        if(item == null)
        {
            return;
        }
        Add_Damage += item.Damage;
        Add_Hp += item.Add_Hp;
        Add_Atk_Speed += item.Atk_Speed;
        Add_Move_Speed += item.Move_Speed;
    }

    //���� �ʱ�ȭ
    public void Reset_State()
    {
        Set_Player_State(-Add_Damage, -Add_Hp, -Add_Move_Speed, -Add_Atk_Speed);
        Add_Damage = 0;
        Add_Hp = 0;
        Add_Atk_Speed = 0;
        Add_Move_Speed = 0;
    }

    public void Set_Player_State(int AD, float Hp, float Speed, float ATKSpeed)
    {
        player_Unit.iAD += AD;
        player_Unit.MaxHp += Hp;
        player_Unit.fMove_Spd += Speed;
        player_Unit.fAttack_Delay += ATKSpeed;
    }

    private void Update()
    {
        if(Input.GetButtonDown("GetItem"))
        {
            if(Coll_Item == null)
            {
                return;
            }

            Equip_Item(Coll_Item.GetComponent<Item_Data>());
            Coll_Item.gameObject.SetActive(false);
            Coll_Item = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Coll_Item = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item") && Coll_Item == collision)
        {
            Coll_Item = null;
        }
    }
}