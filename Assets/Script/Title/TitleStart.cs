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
            Debug.Log("�Q�[���V�[���̃V�[���l�[����ǉ����Ă��������B");
        }
    }
}
