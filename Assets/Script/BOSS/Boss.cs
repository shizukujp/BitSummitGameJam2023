using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{
    private Transform[] allTiles;
    private Transform[] attackTiles;

    [SerializeField] private int attackTileCount = 5;
    [SerializeField] private float attackTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        allTiles = new Transform[GameObject.FindGameObjectWithTag("map1").transform.childCount];
        var i = 0;
        foreach(Transform tile in GameObject.FindGameObjectWithTag("map1").transform)
        {
            allTiles[i] = tile;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
