using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    [SerializeField] GameObject SettingPanel;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject inventory;

    private bool isdie = false;
    private bool IsPause = false;
    private bool invenon = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isdie)
        {
            if (IsPause)
            {
                Resume();
            }
            else
            {
                PauseEnter();
            }
        }
        if(Input.GetKeyDown(KeyCode.Tab) && !isdie && !IsPause)
        {
            if (invenon)
            {
                inventory.SetActive(false);
                invenon = false;
            }
            else
            {
                inventory.SetActive(true);
                invenon = true;
            }
        }
    }
    public void PauseEnter()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SettingPanel.SetActive(true);
        Time.timeScale = 0.0f;
        IsPause = true;
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SettingPanel.SetActive(false);
        IsPause = false;
        Time.timeScale = 1.0f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Title");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void IsDie()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
   
}

