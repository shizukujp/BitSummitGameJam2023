using UnityEngine.SceneManagement;
using UnityEngine;

public class ClearPoint : MonoBehaviour
{
    [Header("移動したいシーンをここに書いてください。")]
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
                Debug.Log("シーンネームを追加してください。");
            }
        }
    }
}
