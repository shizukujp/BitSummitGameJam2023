using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PocketWatch : MonoBehaviour
{
    public float FadeWaitTime;

    Image pocketWatch;
    int pocketWatchCheackLoad = 0;
    bool pocketWatchCheck = false;
    GameObject[] recordEnemy;

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
                Player.instance.NotInWatch = false;
                if (GameObject.Find("GUIOption"))
                {
                    GameObject.Find("GUIOption").GetComponent<WatchTransient>().PocketWatchTransientAnim();
                }
                StartCoroutine(ChangeWatch());
                //pocketWatchRemainingCount--;

                if (pocketWatchRemainingCount != 0)
                {
                    pocketWatchCheackLoad = -1;
                    pocketWatchCheck = false;
                }
            }else
            //場所を記録
            if (Input.GetKeyDown(KeyCode.E) && !pocketWatchCheck && pocketWatchRemainingCount != 0 && !CheckPos())
            {
                recordEnemy = GameObject.FindGameObjectsWithTag("Enemy");
                SameTime = true;
                pocketWatchCheck = true;
                RoundController.instance.UsePocketWatchToSave(recordEnemy);
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

    public void SetPocketWatch(Image image)
    {
        pocketWatch = image;
    }

    bool CheckPos()
    {
        GameObject[] Pos = GameObject.FindGameObjectsWithTag("DontPos");
        foreach(GameObject pos in Pos)
        {
            if (transform.position == pos.transform.position) return true;
        }
        return false;
    }

    IEnumerator ChangeWatch()
    {
        yield return new WaitForSeconds(/*FadeWaitTime*/0);

        RoundController.instance.UsePocketWatchToLoad(recordEnemy);

        Player.instance.NotInWatch = true;
    }
}
