using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMoveMas : MonoBehaviour
{
    public GameObject player;

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
            /*if(child.transform.position == player.transform.position)
            {
                child.GetComponent<SpriteRenderer>().color = new Color(0.157f, 0.157f, 0.157f, 0.475f);
            }
            else */if (Vector2.Distance(player.transform.position, child.transform.position) <= 2f)
            {
                //Debug.Log("移動可能です");
                child.GetComponent<SpriteRenderer>().color = new Color(0.566f, 0.556f, 0.556f, 0.475f);
            }
            else
            {
                child.GetComponent<SpriteRenderer>().color = new Color(0.943f, 0.943f, 0.943f, 0.475f);
            }
        }
    }

    public void Moveoff()
    {

        Transform parentTransform = transform;

        // 子オブジェクトを全て取得する
        foreach (Transform child in parentTransform)
        {
            child.GetComponent<SpriteRenderer>().color = new Color(0.943f, 0.943f, 0.943f, 0.475f);
        }
    }
}
