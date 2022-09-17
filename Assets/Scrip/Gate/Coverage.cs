using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coverage : MonoBehaviour
{
    public int Moeny = 100;
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag =="Player")
        {
            Debug.Log("�������� Ŭ����!");
            collision.GetComponent<Animation_Controller>().Is_Move(0);
            sprite.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (Input.GetKey(KeyCode.C))
            {
                Destroy(gameObject);
                Debug.Log("������ ����.");
            }
        }
    }

    public void coverage_To_Player(int Level)
    {
        GameObject player = GameObject.Find("Player");
        Moeny *= Level;
    }
}
