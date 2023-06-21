using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordTurnPosition : MonoBehaviour
{
    GameObject[] enemy;     //敵のオブジェクト群
    GameObject player;      //プレイヤーオブジェクト

    public GameObject[] Tiles;
    GameObject[] Enemys;

    //ラウンドごとに敵とプレイヤーの位置を保存する関数の宣言
    Vector3[,] roundPosition = new Vector3[13, 11];

    private void Awake()
    {
        ScanEnemy();
        
        player = GameObject.Find("Player");
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        SetTurnPosition(0);
    }
    private void Start()
    {
        Tiles = GameObject.FindGameObjectsWithTag("Tile");
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        //Debug.Log("タイルの数:"　+ Tiles.Length);
    }

    private void Update()
    {
        //Debug.Log(roundPosition1);
        //Debug.Log(roundPosition2);
        //Debug.Log(enemy[2].transform.position);
        //Debug.Log(enemy[3].transform.position);
    }
    public int EnemyCount()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
       
        return Enemys.Length;
    }
    //敵は何人いるかを再スキャンする
    public void ScanEnemy()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    //関数で保存した位置を呼び出して代入する。
    public void GetTurnPositionToScene(int turn)
    {
        if (turn < 13)
        {
            var i = 0;
            foreach (GameObject em in enemy)
            {
                if (em != null)
                {
                    em.transform.position = roundPosition[turn,i];
                    i++;
                }
            }
            player.transform.position = roundPosition[turn, i];
        }
        
        foreach (GameObject enemys in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Vector2 pos = enemys.transform.localScale;

            EnemyMove enemy = enemys.GetComponent<EnemyMove>();
            enemy.Go = true;
            enemy.Up = enemy.FUp;
            enemy.Down = enemy.FDown;
            enemy.Right = enemy.FRight;
            enemy.Left = enemy.FLeft;
            enemy.animator.SetBool("isDiscover", false);
            enemy.isAlerm = false;
            enemy.isEneMove = false;

            //向きの初期化
            if (enemy.FRight && pos.x > 0) pos.x *= -1;
            if (enemy.FLeft && pos.x < 0) pos.x *= -1;
            enemy.transform.localScale = pos;
        }
        Player.instance.South = false;
        Player.instance.North = false;
        Player.instance.West = false;
        Player.instance.East = false;
        foreach (GameObject tiles in Tiles)
        {
            ColorChange change = tiles.GetComponent<ColorChange>();
            change.RisetColor();
        }
        Player.isPlayerTurn = true;
        
    }

    //ターン毎に位置を保存する
    public void SetTurnPosition(int turn)
    {
        player = GameObject.Find("Player");
        //Debug.Log("SetTurn : "+turn);

        if (turn < 13)
        {
            var i = 0;
            if(enemy != null)
            {
                foreach(GameObject em in enemy)
                {
                    if(em != null)
                    {
                        roundPosition[turn,i] = em.transform.position;
                        i++;
                    }
                }
            }
            if (player != null)
            {
                roundPosition[turn, i] = player.transform.position;
            }
        }
    }
}
