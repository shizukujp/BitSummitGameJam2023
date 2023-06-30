using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHack : MonoBehaviour
{

    public Vector2 pos1;
    public Vector2 pos2;
    GameObject player;
    bool one = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if((pos1.x <= player.transform.position.x && player.transform.position.x <= pos2.x) && (pos1.y <= player.transform.position.y && player.transform.position.y <= pos2.y))
        {
            if(one)
            {
                GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 100);
                one = false;
            }
        }else
        {
            if(!one)
            {
                one = true;
            }
        }
    }
}
