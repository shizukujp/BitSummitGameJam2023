using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{
    private GameObject[] allTiles;
    private GameObject[] attackTiles;

    private Animator anim;

    [SerializeField] private GameObject attackTile;

    [SerializeField] private int attackTileCount = 5;
    [SerializeField] private float attackTime = 3f;

    [SerializeField] public int state = 0;
    //0:待机，1：预备攻击，2：攻击，3：冷却

    public static Boss instance;

    public bool isTurn = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        /*allTiles = new GameObject[GameObject.Find("map1").transform.childCount];
        for (int i = 0; i < GameObject.Find("map1").transform.childCount; i++)
        {
            allTiles[i] = GameObject.Find("map1").transform.GetChild(i).gameObject;
        }*/
        allTiles = GameObject.FindGameObjectsWithTag("Tile");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetTrigger("preFinish");
        anim.SetTrigger("isClamDown");
        if (state == 0 && isTurn)
        {
            anim.SetBool("isPre", false);
            anim.SetBool("isAttack", false);
            state = 1;
        }
        else if (state == 1 && isTurn)
        {
            anim.SetBool("isPre", true);
            anim.SetBool("isAttack", false);
            StartCoroutine(preAttack());
            foreach(GameObject tile in attackTiles)
            {
                tile.GetComponent<ColorChange>().isAttack = true;
                tile.GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
                if(ColorChange.instance.CanPlayerMoveColor()){
                    tile.GetComponent<SpriteRenderer>().color = new Color(1f, 0.2f, 0.2f, 0.475f);

                }
            }
        }
        else if (state == 2 && isTurn)
        {
            anim.SetBool("isPre", false);
            anim.SetBool("isAttack", true);
            StartCoroutine(attack());
            foreach (GameObject tile in attackTiles)
            {
                tile.GetComponent<SpriteRenderer>().color = new Color(0.943f, 0.943f, 0.943f, 0.475f);
            }
        }
    }

    IEnumerator preAttack()
    {
        attackTiles = new GameObject[attackTileCount];
        for (int i = 0; i < attackTileCount; i++)
        {
            attackTiles[i] = allTiles[Random.Range(0, allTiles.Length-1)];
        }
        isTurn = false;
        state = 2;
        yield return new WaitForSeconds(1f);
    }

    IEnumerator attack()
    {
        isTurn = false;
        state = 0;
        foreach (GameObject tile in attackTiles)
        {
            Instantiate(attackTile, tile.transform.position, Quaternion.identity);
            if (Player.instance.transform.position == tile.transform.position)
            {
                EnemyMove.Deathcount = 2;
                RoundController.instance.MasRiset();
            }
        }
        yield return new WaitForSeconds(1f);
    }
}
