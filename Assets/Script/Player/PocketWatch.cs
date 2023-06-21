using UnityEngine.UI;
using UnityEngine;

public class PocketWatch : MonoBehaviour
{
    public Image pocketWatch;
    int pocketWatchCheackLoad = 0;
    bool pocketWatchCheck = false;

    int pocketWatchRemainingCount = 3;

    public static bool SameTime = false;
    private void Update()
    {
        //check playerturn and use watch

        if (Player.isPlayerTurn)
        {
            //記録した場所に移動
            if (Input.GetKeyDown(KeyCode.E) && pocketWatchCheck && pocketWatchCheackLoad == 0 && !SameTime && pocketWatchRemainingCount != 0)
            {
                RoundController.instance.UsePocketWatchToLoad();
                pocketWatchRemainingCount--;

                if (pocketWatchRemainingCount != 0)
                {
                    pocketWatchCheackLoad = -1;
                    pocketWatchCheck = false;
                }
            }else
            //場所を記録
            if (Input.GetKeyDown(KeyCode.E) && !pocketWatchCheck && pocketWatchRemainingCount != 0)
            {
                SameTime = true;
                pocketWatchCheck = true;
                RoundController.instance.UsePocketWatchToSave();
                //get saving turn to show
                RoundController.instance.GetSaveTurn();
                pocketWatchCheackLoad = 0;

                Debug.Log(pocketWatchRemainingCount);
            }
        }
        if (pocketWatchCheackLoad == 0) pocketWatch.gameObject.SetActive(true);
        if (pocketWatchRemainingCount == 0) pocketWatch.gameObject.SetActive(false);
        //Debug.Log(pocketWatchCheackLoad);

        if (RoundController.instance.GetSaveTurn() != -1)
        {
            UsingWatch();
        }
        else
        {
            NotUsingWatch();
        }
    }

    public bool GetPocketWatchCheck()
    {
        return pocketWatchCheck;
    }
    public void SetPocketWatchCheck(bool PWC)
    {
        pocketWatchCheck = PWC;
    }
    public void ResetPocketWatchCheck()
    {
        pocketWatchCheck = false;
        pocketWatchCheackLoad = 0;
    }
    void NotUsingWatch()
    {
        pocketWatch.color = new Color(1f, 1f, 1f, 0.4f);
    }
    void UsingWatch()
    {
        pocketWatch.color = new Color(1f, 1f, 1f, 1f);
    }
}
