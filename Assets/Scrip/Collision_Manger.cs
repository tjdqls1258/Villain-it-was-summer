using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Manger : MonoBehaviour
{
    private List<Collision_Event> coll = new List<Collision_Event>();

    public void Add_Collider(Collision_Event collider, GameObject self)
    {
        coll.Add(collider);
        Add_Event_Collider(collider, self);
    }

    private void Add_Event_Collider(Collision_Event collider, GameObject self)
    {
        collider.Trigger_Stay += Stay_Collision;
    }

    private void Stay_Collision(Collider2D collision, GameObject self)
    {
        switch (collision.gameObject.tag) //나와 충돌 한게 무엇인지
        {
            case "Player":
                collision.gameObject.GetComponentInParent<Hit>().Player_Is_Hit(self.GetComponent<Unit>().iAD);
                break;

            case "Monster":
                collision.gameObject.GetComponentInParent<Hit>().Player_Is_Hit(self.GetComponent<Unit>().iAD);
                break;
        }
    }
}
