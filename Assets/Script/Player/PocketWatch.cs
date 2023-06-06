using UnityEngine.UI;
using UnityEngine;

public class PocketWatch : MonoBehaviour
{
    public Image pocketWatch;
    int pocketWatchCheackLoad = 0;
    bool pocketWatchCheck = false;

    private void Update()
    {
        //プレイヤーのターンに懐中時計を使用可能にする
        if (Player.instance.isPlayerTurn)
        {
            if (Input.GetKeyDown(KeyCode.E) && pocketWatchCheck && pocketWatchCheackLoad == 0)
            {
                pocketWatchCheackLoad++;
                RoundController.instance.UsePocketWatchToLoad();
            }

            if (Input.GetKeyDown(KeyCode.E) && !pocketWatchCheck)
            {
                pocketWatchCheck = true;
                RoundController.instance.UsePocketWatchToSave();
                //セーブしたターンの詳細をもらう
                RoundController.instance.GetSaveTurn();
            }
        }
        //一回使用した後に懐中時計を消す
        if (pocketWatchCheackLoad != 0 && pocketWatchCheck) pocketWatch.gameObject.SetActive(false);
        //一回も使用してないときは見えるようにする
        if (pocketWatchCheackLoad == 0) pocketWatch.gameObject.SetActive(true);
        Debug.Log(pocketWatchCheackLoad);

        if (RoundController.instance.GetSaveTurn() != -1 && pocketWatchCheck)
        {
            UsingWatch();
        }
        else
        {
            NotUsingWatch();
        }
    }


    //懐中時計のゲットセット関数
    public bool GetPocketWatchCheck()
    {
        return pocketWatchCheck;
    }
    public void SetPocketWatchCheck(bool PWC)
    {
        pocketWatchCheck = PWC;
    }
    //懐中時計のリセット関数
    public void ResetPocketWatchCheck()
    {
        pocketWatchCheck = false;
        pocketWatchCheackLoad = 0;
    }
    //内部関数
    //元に戻す
    void NotUsingWatch()
    {
        pocketWatch.color = new Color(1f, 1f, 1f, 0.4f);
    }

    //透明度を低くする
    void UsingWatch()
    {
        pocketWatch.color = new Color(1f, 1f, 1f, 1f);
    }
}
