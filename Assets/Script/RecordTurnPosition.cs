using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordTurnPosition : MonoBehaviour
{
    GameObject[] enemy = new GameObject[10];     //敵オブジェクトの配列
    GameObject player;      //プレイヤー


    //ラウンドごとのポジションの保存変数配列（0はラウンドが始まる前の位置情報）
    Vector3[] roundPosition0 = new Vector3[11], roundPosition1 = new Vector3[11], roundPosition2 = new Vector3[11], roundPosition3 = new Vector3[11], roundPosition4 = new Vector3[11],
        roundPosition5 = new Vector3[11], roundPosition6 = new Vector3[11], roundPosition7 = new Vector3[11], roundPosition8 = new Vector3[11],
        roundPosition9 = new Vector3[11], roundPosition10 = new Vector3[11], roundPosition11 = new Vector3[11], roundPosition12 = new Vector3[11];

    private void Awake()
    {
        ScanEnemy();
        
        player = GameObject.Find("Player");
        SetTurnPosition(0);
    }

    private void Update()
    {
        
    }

    //敵の個数をスキャンして使う
    public void ScanEnemy()
    {
        var i = 0;

        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            foreach (GameObject enemys in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy[i] = enemys;
                i++;
            }
        }
    }

    //位置情報の使用
    public void GetTurnPositionToScene(int turn)
    {
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
                Debug.Log("保存されていない変数配列が呼ばれている、もう一度確認してください");
                break;
        }
    }


    //ラウンドごとに位置情報の保存
    public void SetTurnPosition(int turn)
    {
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
                Debug.Log("ケースにない値が保存された、もう一度確認してください");
                break;
        }
    }
}
