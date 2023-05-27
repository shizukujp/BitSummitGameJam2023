using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material MyColor;
    public Material MyColor2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseEnter()
    {
        //this.gameObject.GetComponent<SpriteRenderer>().color = new Color(204, 204, 204, 128);
        GetComponent<Renderer>().material = MyColor;
    }

    //マウスカーソルを離したとき
    void OnMouseExit()
    {
        //RGBAでのカラー指定
        //this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 128);
        //GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 128);
        GetComponent<Renderer>().material = MyColor2;
    }
}
