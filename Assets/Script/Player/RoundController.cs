using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    public static RoundController instance;


    //シーンの交換について
    Scene scenePreb;

    int playerturn = 1, playerturnpreb = 1, round = 1, enemyturn = 1,
        enemyturnend = 0, saveturn = -1;
    RecordTurnPosition recordTurnPositon;

    bool playerWatchSave = false;

    public GameObject countText;
    public GameObject TurnText;

    public static bool OnOff_Enemy = false;
    public static bool OnOff_Player = false;


    GameObject player, monsterGenerator;
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
        if (GameObject.Find("MonsterGenerator") != null) monsterGenerator = GameObject.Find("MonsterGenerator");
    }


    //実行用関数
    private void Update()
    {
        if(Input.GetKey(KeyCode.O))
        {
            if(!OnOff_Enemy)OnOff_Enemy = OnOff_Player = true;
            MasRiset();
        }
        if (Input.GetKey(KeyCode.P))
        {
            if (OnOff_Enemy) OnOff_Enemy = OnOff_Player = false;
            MasRiset();
        }
         //もしシーンが変わったら
        if (SceneManager.GetActiveScene() != scenePreb)
        {
            playerturn = 1;
            playerturnpreb = 1;
            round = 1;
            enemyturn = 1;
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
            Player.isPlayerTurn = false;
        }
        //テスト用
        //if (Input.GetKey(KeyCode.Escape) && !Player.instance.isPlayerTurn) EnemyTurnEnd();
        //テスト用
        //if (Input.GetKey(KeyCode.Escape) && !Player.instance.isPlayerTurn) EnemyTurnEnd();

        //シーン内に敵がいないときに自動プレイヤーのターンに移行する
        if (recordTurnPositon.EnemyCount() == 0 && !Player.isPlayerTurn)
        {
            if (!playerWatchSave) recordTurnPositon.SetTurnPosition(enemyturn);
            if (playerWatchSave) playerWatchSave = false;
            enemyturn++;
            if (enemyturn < 12) Player.isPlayerTurn = true;
        }

        //敵に見つかった次のターンに戻る処理
        if (EnemyMove.Deathcount == 2)
        {
            GameReset();
            EnemyMove.Deathcount = 0;
        }
        

            //Debug.Log(enemyturn);
            if (enemyturn > 12)
        {
            GameReset();
        }
    }



    //内部で動く関数
    void GameReset()
    {
        round++;

        //敵とプレイヤーの位置を最初の位置に戻す
        recordTurnPositon.GetTurnPositionToScene(0);

        //モンスターをラウンドごとに生成する（あれば）
        if (monsterGenerator.GetComponent<MonsterGenerator>().SetRound(round))
        {
            recordTurnPositon.ScanEnemy();
            recordTurnPositon.SetTurnPosition(0);

        }
            


        //ターンを最初のターンに戻す
        playerturn = 1;
        playerturnpreb = 1;
        enemyturn = 1;

        //懐中時計の設定
        if (pocketWatch.GetPocketWatchCheck()) pocketWatch.ResetPocketWatchCheck();

        //色修正
        //CanMoveMas.instance.Moveoff();
        //CanMoveMas.instance.CanMove();
        //TurnText.GetComponent<Count>().score = 1;
        //countText.GetComponent<Count>().score = 0;
        //プレイヤー動きの追加
        EnemyMove.IsEnemyMove = false;
        Player.isPlayerTurn = true;
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
        saveturn = -1;
    }

    //ターン関係
    public int GetTurn() { return playerturn; }
    public int GetETurn() { return enemyturn; }
    public int GetRound() { return round; }
    public void SetTurn(int tn) { playerturn = tn; }
    public void SetRound(int rd) { round = rd; }
    public int GetSaveTurn() { return saveturn; }
    
    //全ての敵が移動を終えたからターンを終わらせる
    public void EnemyTurnEnd() 
    {
        enemyturnend++;
        if (recordTurnPositon.EnemyCount() >= enemyturnend)
        {
            if (!playerWatchSave) recordTurnPositon.SetTurnPosition(enemyturn);
            if (playerWatchSave) playerWatchSave = false;
            
            if (enemyturn < 12) Player.isPlayerTurn = true;
            if (recordTurnPositon.EnemyCount() != enemyturnend) return;
            EnemyMove.IsEnemyMove = false;
            enemyturn++;
            enemyturnend = 0;
        }
    }
    public void MasRiset()
    {
        int i = 0;
        foreach (GameObject tiles in recordTurnPositon.Tiles)
        {
            ColorChange change = recordTurnPositon.Tiles[i].GetComponent<ColorChange>();
            change.RisetColor();
            i++;
        }
    }
    public void EnemyTurn()
    {
        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            foreach (GameObject enemys in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                EnemyMove enem =  enemys.GetComponent<EnemyMove>();
                enem.isEneMove = true;
            }
        }
    }
}
