using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject summonobj, Environment;

    [System.Serializable]
    public struct newEnemy{
        [Tooltip("このラウンドで敵が生成されます"),Header("このラウンドで敵が生成されます")]
        public int RoundCount;
        [Tooltip("生成箇所"),Header("生成箇所")]
        public float PositionX, PositionY;
        [Tooltip("移動目的地"),Header("敵の移動目的地")]
        public int MovePosX, MovePosY;
        [Tooltip("横移動かどうか"), Header("敵の詳細bool設定")]
        public bool isVertical;
        [Tooltip("最初の移動方向")]
        public bool left, right, up, down;
    }

    [SerializeField]
    public List<newEnemy> newEnemies = new List<newEnemy>();

    int round = 1;

    bool CheckRoundToSummon()
    {
        for(int i = 0; i < newEnemies.Count; i++)
        {
            if (round == newEnemies[i].RoundCount)
            {
                var enemy = Instantiate(summonobj,new Vector3(newEnemies[i].PositionX, newEnemies[i].PositionY, 0), Quaternion.identity, Environment.transform);
                enemy.GetComponent<EnemyMove>().SetMovingDir(newEnemies[i].MovePosX, newEnemies[i].MovePosY, newEnemies[i].isVertical , newEnemies[i].left, newEnemies[i].right, newEnemies[i].up, newEnemies[i].down);
                RoundController.instance.MasRiset();
                return true;
            }
        }
        return false;
    }





    //今はどのラウンドにいるかをラウンドマネジャから受信する
    public bool SetRound(int rd)
    {
        round = rd;
        return CheckRoundToSummon();
    }
}
