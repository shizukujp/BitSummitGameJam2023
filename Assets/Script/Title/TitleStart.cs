using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleStart : MonoBehaviour
{
    public string GameScene = "";

   
    public void GameStart()
    {
        if (GameScene != "")
        {
            SceneManager.LoadScene(GameScene);
        }
        else
        {
            Debug.Log("ゲームシーンのシーンネームを追加してください。");
        }
    }
}
