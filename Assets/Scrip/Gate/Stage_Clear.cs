using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_Clear : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player" )
        {
            if(Input.GetKey(KeyCode.C))
            {
                Debug.Log("���� ����������");
                NextStage(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void NextStage(int Level)
    {
        SceneManager.LoadScene(Level + 1);
    }
}
