using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public static MessageManager instance;
    [SerializeField] private int key = 0;
    [SerializeField] private bool isAlive = false;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            //Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void indexplus()
    {
        key ++;
    }

    public string getTitle(){
        return Log.titles[key];
    }
    
    public string getMessage(){
        isAlive = true;
        return Log.messages[key];
    }

    public void OnClick(){
        if(isAlive){
            GameObject.Find("GameManager/PlayerUI/MessagePanel").SetActive(false);
            isAlive = false;
        }
    }
}
