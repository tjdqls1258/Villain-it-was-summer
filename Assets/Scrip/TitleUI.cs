using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public void NewGame()
    {
        //처음부터 시작이므로 플레이 처음 씬으로
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        //필요하게 되면 작성 - 현재는 더미
        //SceneManager.LoadScene();
    }

    public void Tutorial()
    {
        //튜토리얼 씬으로 이동
        //SceneManager.LoadScene();
    }

    public void ExitGame()
    {
        //게임종료
        Application.Quit();
    }
}
