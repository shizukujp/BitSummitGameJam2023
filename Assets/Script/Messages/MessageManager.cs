using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public static MessageManager instance;
    [SerializeField] public static int key = 0;
    [SerializeField] private bool isAlive = false;

    public static bool VisibleText;
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

    public void ClickLog(){
        if(isAlive){
            GameObject.Find("GameManager/PlayerUI/MessagePanel").SetActive(false);
            isAlive = false;
            VisibleText = false;
        }
    }
    public void indexMinas()
    {
        for (int i = 0; i < RoundController.PointToScene; i++)
        {
            key--;
        }
        RoundController.PointToScene = 0;
    }
}
