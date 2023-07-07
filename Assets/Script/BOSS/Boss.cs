using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{
    private Transform[] allTiles;
    private Transform[] attackTiles;

    [SerializeField] private int attackTileCount = 5;
    [SerializeField] private float attackTime = 3f;

    [SerializeField] private int state = 0;
    //0:待机，1：预备攻击，2：攻击，3：冷却
    // Start is called before the first frame update
    void Start()
    {
        allTiles = new Transform[GameObject.Find("map1").transform.childCount];
        var i = 0;
        foreach(Transform tile in GameObject.Find("map1").transform)
        {
            allTiles[i] = tile;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 0)
        {
            
        }
    }

    void preAttack()
    {
        attackTiles = new Transform[attackTileCount];
        for(int i = 0; i < attackTileCount; i++)
        {
            attackTiles[i] = allTiles[Random.Range(0, allTiles.Length)];
        }
        foreach(Transform tile in attackTiles)
        {
            tile.GetComponent<SpriteRenderer>().color = new Color(0.157f, 0.157f, 0.157f, 0.475f);
        }
    }

    void attack()
    {
        foreach(Transform tile in attackTiles)
        {
            tile.GetComponent<SpriteRenderer>().color = new Color(0.943f, 0.943f, 0.943f, 0.475f);
        }
    }
}
