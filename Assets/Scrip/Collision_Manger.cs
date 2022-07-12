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
        switch (collision.gameObject.tag) //나와 충돌 한게 무엇인지
        {
            case "Player"://충돌 한게 플레이어 일경우 (자동적으로 내가 몬스터가 됨)
                collision.gameObject.GetComponent<Hit>().Player_Is_Hit();
                break;

            case "Monster"://충돌 한게 몬스터 일경우 (자동적으로 내가 플레이어가 됨)
                collision.gameObject.GetComponentInParent<Hit>().Player_Is_Hit();
                break;
        }
    }
}
