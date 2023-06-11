using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleStart : MonoBehaviour
{
    public string GameScene = "";

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(GameScene != "")
            {
                SceneManager.LoadScene(GameScene);
            }
            else
            {
                Debug.Log("�Q�[���V�[���̃V�[���l�[����ǉ����Ă��������B");
            }
        }
    }
}
