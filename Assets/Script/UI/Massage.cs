using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Massage : MonoBehaviour
{
    public static Massage instance;

    public void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            //Destroy(gameObject);
        }
    }

    //メッセージ枠が表示されているかどうか
    public static bool inMassage = false;
    public GameObject MassageUI;
    public Text nameText;
    public Text massageText;
    // Start is called before the first frame update
    void Start()
    {
        MassageUI.SetActive(false);
    }

    void Update()
    {
    }
    public void MessageOpen(GameObject obj)
    {
        MassageUI.SetActive(true);
        inMassage = true;
        switch (obj.tag)
        {
            case "Item":
                nameText.text = "アイテム";
                massageText.text = "これはアイテムだ";
                break;
            default:
                nameText.text = "あいうえお";
                massageText.text = "かきくけこ";
                break;
        }
    }
    public void MessageClose()
    {
        MassageUI.SetActive(false);
        inMassage = false;
    }
}
