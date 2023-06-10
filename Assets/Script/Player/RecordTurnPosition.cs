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
    Vector3[] roundPosition0 = new Vector3[11], roundPosition1 = new Vector3[11], roundPosition2 = new Vector3[11], roundPosition3 = new Vector3[11], roundPosition4 = new Vector3[11],
        roundPosition5 = new Vector3[11], roundPosition6 = new Vector3[11], roundPosition7 = new Vector3[11], roundPosition8 = new Vector3[11],
        roundPosition9 = new Vector3[11], roundPosition10 = new Vector3[11], roundPosition11 = new Vector3[11], roundPosition12 = new Vector3[11];

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
        //Debug.Log("GetTurn : " + turn);
        switch (turn)
        {
            case 0:
                var i0 = 0;
                if (enemy != null)
                {
                    foreach(GameObject enemys in enemy)
                    {
                        if(enemys != null)
                        {
                            enemys.transform.position = roundPosition0[i0];
                            i0++;
                        }
                    }
                }
                player.transform.position = roundPosition0[i0];
                break;
            case 1:
                var i1 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            enemys.transform.position = roundPosition1[i1];
                            i1++;
                        }
                    }
                }
                player.transform.position = roundPosition1[i1];
                break;
            case 2:
                var i2 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            enemys.transform.position = roundPosition2[i2];
                            i2++;
                        }
                    }
                }
                player.transform.position = roundPosition2[i2];
                break;
            case 3:
                var i3 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            enemys.transform.position = roundPosition3[i3];
                            i3++;
                        }
                    }
                }
                player.transform.position = roundPosition3[i3];
                break;
            case 4:
                var i4 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            enemys.transform.position = roundPosition4[i4];
                            i4++;
                        }
                    }
                }
                player.transform.position = roundPosition4[i4];
                break;
            case 5:
                var i5 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            enemys.transform.position = roundPosition5[i5];
                            i5++;
                        }
                    }
                }
                player.transform.position = roundPosition5[i5];
                break;
            case 6:
                var i6 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            enemys.transform.position = roundPosition6[i6];
                            i6++;
                        }
                    }
                }
                player.transform.position = roundPosition6[i6];
                break;
            case 7:
                var i7 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            enemys.transform.position = roundPosition7[i7];
                            i7++;
                        }
                    }
                }
                player.transform.position = roundPosition7[i7];
                break;
            case 8:
                var i8 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            enemys.transform.position = roundPosition8[i8];
                            i8++;
                        }
                    }
                }
                player.transform.position = roundPosition8[i8];
                break;
            case 9:
                var i9 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            enemys.transform.position = roundPosition9[i9];
                            i9++;
                        }
                    }
                }
                player.transform.position = roundPosition9[i9];
                break;
            case 10:
                var i10 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            enemys.transform.position = roundPosition10[i10];
                            i10++;
                        }
                    }
                }
                player.transform.position = roundPosition10[i10];
                break;
            case 11:
                var i11 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            enemys.transform.position = roundPosition11[i11];
                            i11++;
                        }
                    }
                }
                player.transform.position = roundPosition11[i11];
                break;
            case 12:
                var i12 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            enemys.transform.position = roundPosition12[i12];
                            i12++;
                        }
                    }
                }
                player.transform.position = roundPosition12[i12];
                break;
            default:
                Debug.Log("enemy load error");
                break;
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
        //Debug.Log("SetTurn : "+turn);
        switch (turn)
        {
            case 0:
                var i0 = 0;
                if(enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            roundPosition0[i0] = enemys.transform.position;
                            i0++;
                        }
                    }
                }
                roundPosition0[i0] = player.transform.position;
                break;
            case 1:
                var i1 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            roundPosition1[i1] = enemys.transform.position;
                            i1++;
                        }
                    }
                }
                roundPosition1[i1] = player.transform.position;
                break;
            case 2:
                var i2 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            roundPosition2[i2] = enemys.transform.position;
                            i2++;
                        }
                    }
                }
                roundPosition2[i2] = player.transform.position;
                break;
            case 3:
                var i3 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            roundPosition3[i3] = enemys.transform.position;
                            i3++;
                        }
                    }
                }
                roundPosition3[i3] = player.transform.position;
                break;
            case 4:
                var i4 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            roundPosition4[i4] = enemys.transform.position;
                            i4++;
                        }
                    }
                }
                roundPosition4[i4] = player.transform.position;
                break;
            case 5:
                var i5 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            roundPosition5[i5] = enemys.transform.position;
                            i5++;
                        }
                    }
                }
                roundPosition5[i5] = player.transform.position;
                break;
            case 6:
                var i6 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            roundPosition6[i6] = enemys.transform.position;
                            i6++;
                        }
                    }
                }
                roundPosition6[i6] = player.transform.position;
                break;
            case 7:
                var i7 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            roundPosition7[i7] = enemys.transform.position;
                            i7++;
                        }
                    }
                }
                roundPosition7[i7] = player.transform.position;
                break;
            case 8:
                var i8 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            roundPosition8[i8] = enemys.transform.position;
                            i8++;
                        }
                    }
                }
                roundPosition8[i8] = player.transform.position;
                break;
            case 9:
                var i9 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            roundPosition9[i9] = enemys.transform.position;
                            i9++;
                        }
                    }
                }
                roundPosition9[i9] = player.transform.position;
                break;
            case 10:
                var i10 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            roundPosition10[i10] = enemys.transform.position;
                            i10++;
                        }
                    }
                }
                roundPosition10[i10] = player.transform.position;
                break;
            case 11:
                var i11 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            roundPosition11[i11] = enemys.transform.position;
                            i11++;
                        }
                    }
                }
                roundPosition11[i11] = player.transform.position;
                break;
            case 12:
                var i12 = 0;
                if (enemy != null)
                {
                    foreach (GameObject enemys in enemy)
                    {
                        if (enemys != null)
                        {
                            roundPosition12[i12] = enemys.transform.position;
                            i12++;
                        }
                    }
                }
                roundPosition12[i12] = player.transform.position;
                break;
            default:
                break;
        }
    }
}
