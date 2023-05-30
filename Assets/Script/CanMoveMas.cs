using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMoveMas : MonoBehaviour
{
    public GameObject player;
    public Material MyColor;//一番薄い色
    public Material MyColor2;//2番目に濃い色
    public static CanMoveMas instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CanMove()
    {
        Transform parentTransform = transform;

        // 子オブジェクトを全て取得する
        foreach (Transform child in parentTransform)
        {
            // 子オブジェクトに対する処理をここに書く
            if (Vector2.Distance(player.transform.position, child.transform.position) / 1f <= 2f)
            {
                Debug.Log("移動可能です");
                child.GetComponent<Renderer>().material = MyColor2;
            }
            else
            {
                child.GetComponent<Renderer>().material = MyColor;
            }
        }
    }
}
