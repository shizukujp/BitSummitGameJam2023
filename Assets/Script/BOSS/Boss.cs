using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{
    private Transform[] allTiles;
    private Transform[] attackTiles;

    private Animator anim;

    [SerializeField] private int attackTileCount = 5;
    [SerializeField] private float attackTime = 3f;

    [SerializeField] public int state = 0;
    //0:待机，1：预备攻击，2：攻击，3：冷却

    public static Boss instance;

    public bool isTurn = false;

    private void Awake() {
        if(instance == null){
            instance = this;
        }else{

        }
    }

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

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetTrigger("preFinish");
        anim.SetTrigger("isClamDown");
        if(state == 0 && isTurn){
            anim.SetBool("isPre", false);
            anim.SetBool("isAttack", false);
            state = 1;
        }else if(state == 1 && isTurn){
            anim.SetBool("isPre", true);
            anim.SetBool("isAttack", false);
            StartCoroutine(preAttack());
        }else if(state == 2 && isTurn){
            anim.SetBool("isPre", false);
            anim.SetBool("isAttack", true);
            StartCoroutine(attack());
        }
    }

    IEnumerator preAttack()
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
        isTurn = false;
        state = 2;
        yield return new WaitForSeconds(1f);
    }

    IEnumerator attack()
    {
        foreach(Transform tile in attackTiles)
        {
            tile.GetComponent<SpriteRenderer>().color = new Color(0.943f, 0.943f, 0.943f, 0.475f);
        }        
        isTurn = false;
        state = 0;
        yield return new WaitForSeconds(1f);
    }
}
