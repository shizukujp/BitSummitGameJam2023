using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    public static RoundController instance;

    //シーンの交換について
    Scene scenePreb;

    int playerturn = 1, playerturnpreb = 1, playerround = 1, enemyturn = 1, enemyround = 1;
    RecordTurnPosition recordTurnPositon;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        scenePreb = SceneManager.GetActiveScene();
        recordTurnPositon = GetComponent<RecordTurnPosition>();
    }


    //実行用関数
    private void Update()
    {
        //もしシーンが変わったら
        if (SceneManager.GetActiveScene() != scenePreb)
        {
            playerturn = 1;
            playerturnpreb = 1;
            playerround = 1;
            enemyturn = 1;
            enemyround = 1;
            recordTurnPositon.SetTurnPosition(0);
        }

        if (playerturn != playerturnpreb)
        {
            playerturnpreb = playerturn;
            Player.instance.isPlayerTurn = false;
        }
        //テスト用
        if (Input.GetKey(KeyCode.Escape) && !Player.instance.isPlayerTurn) EnemyTurnEnd();


        //Debug.Log(enemyturn);
        if (enemyturn >= 12)
        {
            recordTurnPositon.GetTurnPositionToScene(0);

            playerturn = 1;
            enemyturn = 0;

            //色修正
            CanMoveMas.instance.Moveoff();
            CanMoveMas.instance.CanMove();
        }
    }



    //内部で動く関数




    //パブリック関数
    public int GetTurn() { return playerturn; }
    public int GetRound() { return playerround; }
    public void SetTurn(int tn) { playerturn = tn; }
    public void SetRound(int rd) { playerround = rd; }
    public void EnemyTurnEnd() 
    { 
        Player.instance.isPlayerTurn = true;
        recordTurnPositon.SetTurnPosition(enemyturn);
        enemyturn++;
    }
    public void EnemyRoundEnd()
    {
        enemyround++;
    }
}
