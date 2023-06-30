using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    //*******************************************************************
    //                Unityで設定
    //*******************************************************************

    /// メッセージパネル（ボタン）
    public GameObject messagePanel;

    /// テキスト
    public TextMeshProUGUI text;

    //*******************************************************************
    //                情報と基本メソッド
    //*******************************************************************

    /// 書くスピード(短いほど早い)
    public float writeSpeed = 0.1f;

    /// 書いている途中かどうか
    public bool isWriting = false;

    /// 文章の番号は Key で表す
    public int key = 0;

    /// テキストを書くメソッド
    public void Write(string s)
    {
        //毎回、書くスピードを 0.2 に戻す------<戻したくない場合はここを消す>
        //writeSpeed = 0.2f;

        StartCoroutine(IEWrite(s));
    }

    /// テキストを消すメソッド
    public void Clean()
    {
        if(text != null) { text.text = ""; } else { Debug.Log("テキストオブジェクトは入れてません"); }
    }

    //*******************************************************************
    //                表示するメッセージ
    //*******************************************************************

    static Dictionary<int, string> message = new Dictionary<int, string>()
    { 
        //----\nは改行を表す----
        { 1, "こんにちは" },
        { 2, "さようなら" },
        { 3, "バイバイ" },
        { 4, "キィえええええええ！" },
        { 999, "・・・・" },
    };

    //*******************************************************************
    //                メッセージパネルがタッチされた時の処理
    //*******************************************************************

    //このメソッドが呼ばれる
    public void OnClick()
    {
        //前のメッセージを書いている途中かどうかで分ける
        if (isWriting)
        {
            //書いている途中にタッチされた時------------------------------

            //スピード(かかる時間)を 0 にして、すぐに最後まで書く
            writeSpeed = 0f;
        }
        else
        {
            //書き終わったあとでタッチされた時----------------------------

            switch (key)
            {
                case 2:
                    // 2 を書いた後-----------------------

                    //一旦ここで溜まった文字を消す
                    Clean();

                    //番号を 3 にする
                    key = 3;

                    //メッセージを書く
                    Write(message[key]);

                    break;

                case 4:
                    // 4 を書いた後----------------------
                    Clean();
                    //番号を 999 にする
                    key = 999;

                    //メッセージを書く
                    Write(message[key]);

                    break;

                case 999:
                    // 999 を書いた後-------------------
                    Clean();
                    //メッセージパネルを消す
                    messagePanel.SetActive(false);

                    break;

                default:
                    //それ以外の場合全て-----------------
                    Clean();
                    //番号を 1 増やす
                    key++;

                    //メッセージを書く
                    Write(message[key]);

                    break;
            }
        }
    }

    //*******************************************************************
    //                その他
    //*******************************************************************

    /// 書くためのコルーチン
    IEnumerator IEWrite(string s)
    {
        //書いている途中の状態にする
        isWriting = true;
        //渡されたstringの文字の数だけループ
        for (int i = 0; i < s.Length; i++)
        {
            //テキストにi番目の文字を付け足して表示する
            text.text += s.Substring(i, 1);
            //次の文字を表示するまで少し待つ
            yield return new WaitForSeconds(writeSpeed);
        }
        //書いている途中の状態を解除する
        isWriting = false;
    }

    /// ゲームスタート時の処理
    void Start()
    {
        //メッセージパネルに書かれている文字を消す
        Clean();
    }
}
