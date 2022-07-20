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
            if(Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("다음 스테이지로");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
