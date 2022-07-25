using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coverage : MonoBehaviour
{
    public int Moeny = 100;
    //public List<Item> Coverage_List = new List<Item>(); 
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag =="Player")
        {
            Debug.Log("스테이지 클리어!");
            sprite.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            sprite.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.X))
            {

                Debug.Log("보상을 얻음.");
            }
        }
    }

    public void coverage_To_Player(int Level)
    {
        GameObject player = GameObject.Find("Player");
        Moeny *= Level;
        //player.GetCompoent("Inven").Get_Item(Coverage_List[0,Coverage_List.count]);
    }
}
