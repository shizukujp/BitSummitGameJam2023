using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    public static RoundController instance;


    //シーンの交換について
    Scene scenePreb;

    int playerturn = 1, playerturnpreb = 1, playerround = 1, enemyturn = 1, enemyround = 1, saveturn = -1;
    RecordTurnPosition recordTurnPositon;

    bool playerWatchSave = false;

    GameObject player;
    PocketWatch pocketWatch;

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

        //プレイヤーオブジェクトを代入
        player = GameObject.Find("Player");
        pocketWatch = player.GetComponent<PocketWatch>();

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

            //シーンが変わったらプレイヤーオブジェクトを代入
            player = GameObject.Find("Player");
            pocketWatch = player.GetComponent<PocketWatch>();

            //移動したシーンを代入
            scenePreb = SceneManager.GetActiveScene();
        }

        if (playerturn != playerturnpreb )
        {
            playerturnpreb = playerturn;
            Player.instance.isPlayerTurn = false;
        }
        //テスト用
        //if (Input.GetKey(KeyCode.Escape) && !Player.instance.isPlayerTurn) EnemyTurnEnd();
        //テスト用
        //if (Input.GetKey(KeyCode.Escape) && !Player.instance.isPlayerTurn) EnemyTurnEnd();

        //敵に見つかった次のターンに戻る処理
        if(EnemyMove.Deathcount == 2)
        {
            GameReset();
            EnemyMove.Deathcount = 0;
        }
        //Debug.Log(enemyturn);
        if (enemyturn >= 12)
        {
            GameReset();
        }
    }



    //内部で動く関数
    void GameReset()
    {
        //敵とプレイヤーの位置を最初の位置に戻す
        recordTurnPositon.GetTurnPositionToScene(0);

        //ターンを最初のターンに戻す
        playerturn = 1;
        playerturnpreb = 1;
        enemyturn = 1;

        //懐中時計の設定
        if (pocketWatch.GetPocketWatchCheck()) pocketWatch.ResetPocketWatchCheck();

        //色修正
        CanMoveMas.instance.Moveoff();
        CanMoveMas.instance.CanMove();

        //プレイヤー動きの追加
        Player.instance.isPlayerTurn = true;
    }



    //パブリック関数
    //懐中時計関係
    public void UsePocketWatchToSave()
    {
        playerWatchSave = true;
        recordTurnPositon.SetTurnPosition(enemyturn);
        saveturn = enemyturn;
    } 
    public void UsePocketWatchToLoad()
    {
        recordTurnPositon.GetTurnPositionToScene(saveturn);
    }

    //ターン関係
    public int GetTurn() { return playerturn; }
    public int GetRound() { return playerround; }
    public void SetTurn(int tn) { playerturn = tn; }
    public void SetRound(int rd) { playerround = rd; }
    
    //ターンの交代に関して
    public void EnemyTurnEnd() 
    { 
        if (!playerWatchSave) recordTurnPositon.SetTurnPosition(enemyturn);
        if (playerWatchSave) playerWatchSave = false;
        enemyturn++;
        if (enemyturn < 12) Player.instance.isPlayerTurn = true;
    }
    public void EnemyRoundEnd()
    {
        enemyround++;
    }
}
