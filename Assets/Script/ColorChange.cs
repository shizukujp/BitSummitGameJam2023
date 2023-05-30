using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material MyColor;//一番薄い色
    public Material MyColor2;//2番目に濃い色
    public Material MyColor3;//一番濃い色
    // Start is called before the first frame update
    public bool A = true;
    GameObject player;

    public static ColorChange instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        player = Player.instance.player;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが動いていない間
        if(A && !Player.instance.ismove)
        {
            Debug.Log("生成");
            CanPlayerMove();
        }
        /*if(!Player.instance.ismove )
        {
            A = true;
        }*/
    }

    void OnMouseEnter()
    {
        if(!Player.instance.ismove)
        {
            //プレイヤーが移動可能なマスだったら
            if(Vector2.Distance(player.transform.position, transform.position) / 1f <= 2f)
            {
                GetComponent<Renderer>().material = MyColor3;
            }else//それ以外
            {
                GetComponent<Renderer>().material = MyColor2;
            }
        }
            
    }

    //マウスカーソルを離したとき
    void OnMouseExit()
    {
        if (!Player.instance.ismove)
        {
            //プレイヤーが移動可能な範囲のマスだったら
            if (Vector2.Distance(player.transform.position, transform.position) / 1f <= 2f)
            {
                GetComponent<Renderer>().material = MyColor2;
            }else
            {
                GetComponent<Renderer>().material = MyColor;
            }
        }
    }
    //プレイヤーが移動可能なマスを表示する
    public void CanPlayerMove()
    {
        if (Vector2.Distance(player.transform.position, transform.position) / 1f <= 2f)
        {
            Debug.Log("移動可能です");
            GetComponent<Renderer>().material = MyColor2;
        }
        else
        {
            GetComponent<Renderer>().material = MyColor;
        }
        A = false;
    }

    //移動するマス以外のマスの色を元に戻す
    public void Riset()
    {
        /*Debug.Log("リセットされました");
        if (Vector2.Distance(player.transform.position, transform.position) / 1f <= 2f)
        {
            GetComponent<Renderer>().material = MyColor;
        }
        Player.instance.B = false;*/
        A = true;
    }

}
