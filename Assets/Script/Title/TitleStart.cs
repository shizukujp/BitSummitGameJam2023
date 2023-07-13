using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class TitleStart : MonoBehaviour
{
    public string GameScene = "";
    public float GameFadeTime = 3;
    public float TimerSpeed = 5;
    public Second_Title[] second_Titles = new Second_Title[3];
    Coroutine StartGameCorotine;

    public void GameStart()
    {

        if (StartGameCorotine == null)
        {
            foreach(var title in second_Titles)
            {
                title.SpeedFactor *= TimerSpeed;
            }
            GUIOption.Instance.GetGUIOptionFade().FadeIn(GameFadeTime);
            StartGameCorotine = StartCoroutine(StartGame());
        }
    }

    IEnumerator StartGame()
    {
        var FadeTime = 0f;
        while(FadeTime < GameFadeTime)
        {
            FadeTime += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        if (GameScene != "")
        {
            SceneManager.LoadScene(GameScene);
        }
        else
        {
            Debug.Log("�Q�[���V�[���̃V�[���l�[����ǉ����Ă��������B");
        }
    }
}
