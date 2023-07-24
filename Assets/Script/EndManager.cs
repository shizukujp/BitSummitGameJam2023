using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    [SerializeField] private int messageCount;
    public GameObject[] BG;
    RoundController rc;
    private void Awake() {
        messageCount = MessageManager.key;
    }

    private void Start() {
        if (messageCount < 10){
            BG[0].SetActive(true);
            BG[1].SetActive(false);
            BG[2].SetActive(false);
        }else if (messageCount < 15){
            BG[0].SetActive(false);
            BG[1].SetActive(true);
            BG[2].SetActive(false);
        }else{
            BG[0].SetActive(false);
            BG[1].SetActive(false);
            BG[2].SetActive(true);
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
            MessageManager.key = 0;
            SoundManager.Instance.RisetBGM();
        }
    }
}
