using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public void NewGame()
    {
        //ó������ �����̹Ƿ� �÷��� ó�� ������
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        //�ʿ��ϰ� �Ǹ� �ۼ� - ����� ����
        //SceneManager.LoadScene();
    }

    public void Tutorial()
    {
        //Ʃ�丮�� ������ �̵�
        //SceneManager.LoadScene();
    }

    public void ExitGame()
    {
        //��������
        Application.Quit();
    }
}
