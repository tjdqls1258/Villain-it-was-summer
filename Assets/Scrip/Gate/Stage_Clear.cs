using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_Clear : MonoBehaviour
{
    public int next;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player" )
        {
            if(Input.GetKey(KeyCode.C))
            {
                Debug.Log("다음 스테이지로");
                NextStage(next);
            }
        }
    }

    public void NextStage(int Level)
    {
        SceneManager.LoadScene(Level + 1);
    }
}
