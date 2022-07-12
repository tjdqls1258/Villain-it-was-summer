using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Manger : MonoBehaviour
{
    private List<Collision_Event> coll = new List<Collision_Event>();

    public void Add_Collider(Collision_Event collider)
    {
        coll.Add(collider);
        Add_Event_Collider(collider);
    }

    private void Add_Event_Collider(Collision_Event collider)
    {
        collider.Trigger_Stay += Stay_Collision;
    }

    private void Stay_Collision(Collider2D collision)
    {
        switch (collision.gameObject.tag) //���� �浹 �Ѱ� ��������
        {
            case "Player"://�浹 �Ѱ� �÷��̾� �ϰ�� (�ڵ������� ���� ���Ͱ� ��)
                collision.gameObject.GetComponent<Hit>().Player_Is_Hit();
                break;

            case "Monster"://�浹 �Ѱ� ���� �ϰ�� (�ڵ������� ���� �÷��̾ ��)
                collision.gameObject.GetComponentInParent<Hit>().Player_Is_Hit();
                break;
        }
    }
}
