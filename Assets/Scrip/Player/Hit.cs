using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public bool Is_Hit = false;
    public float Reset_Hit_Time = 0.5f;

    public void Player_Is_Hit()
    {
        StartCoroutine(Reset_Hit());
        Debug.Log("����");
    }

    IEnumerator Reset_Hit()
    {
        yield return new WaitForSeconds(Reset_Hit_Time);
        Is_Hit = false;
        Debug.Log("����");
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.tag == "Monster_ATK") && (Is_Hit == false))
        {
            Is_Hit = true;
            Debug.Log("�浹");
            Player_Is_Hit();
        }
    }

}
