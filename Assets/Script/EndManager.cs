using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    [SerializeField] private int messageCount;

    private void Awake() {
        messageCount = MessageManager.instance.key;
    }

    private void Start() {
        if(messageCount < 10){
            GameObject.Find("Canvas/BG1").SetActive(true);
            GameObject.Find("Canvas/BG2").SetActive(false);
            GameObject.Find("Canvas/BG3").SetActive(false);
        }else if (messageCount < 15){
            GameObject.Find("Canvas/BG1").SetActive(false);
            GameObject.Find("Canvas/BG2").SetActive(true);
            GameObject.Find("Canvas/BG3").SetActive(false);
        }else{
            GameObject.Find("Canvas/BG1").SetActive(false);
            GameObject.Find("Canvas/BG2").SetActive(false);
            GameObject.Find("Canvas/BG3").SetActive(true);
        }
    }
}
