using UnityEngine.UI;
using UnityEngine;

public class PocketWatch : MonoBehaviour
{
    public Image pocketWatch;
    int pocketWatchCheackLoad = 0;
    bool pocketWatchCheck = false;

    public static bool SameTime = false;
    private void Update()
    {
        //check playerturn and use watch

        if (Player.isPlayerTurn)
        {
            if (Input.GetKeyDown(KeyCode.E) && pocketWatchCheck && pocketWatchCheackLoad == 0 && !SameTime)
            {
                pocketWatchCheackLoad++;
                RoundController.instance.UsePocketWatchToLoad();
            }

            if (Input.GetKeyDown(KeyCode.E) && !pocketWatchCheck)
            {
                SameTime = true;
                pocketWatchCheck = true;
                RoundController.instance.UsePocketWatchToSave();
                //get saving turn to show
                RoundController.instance.GetSaveTurn();
            }
        }
        if (pocketWatchCheackLoad != 0 && pocketWatchCheck) pocketWatch.gameObject.SetActive(false);
        if (pocketWatchCheackLoad == 0) pocketWatch.gameObject.SetActive(true);
        //Debug.Log(pocketWatchCheackLoad);

        if (RoundController.instance.GetSaveTurn() != -1 && pocketWatchCheck)
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
