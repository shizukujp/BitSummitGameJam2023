using UnityEngine.SceneManagement;
using UnityEngine;

public class ClearPoint : MonoBehaviour
{
    [Header("SceneName")]
    public string NextSceneName = "";

    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if(player.transform.position == gameObject.transform.position)
        {
            if(NextSceneName != "")
            {
                SceneManager.LoadScene(NextSceneName);
            }
            else
            {
                Debug.Log("�V�[���l�[����ǉ����Ă��������B");
            }
        }
    }
}
