using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketWatch : MonoBehaviour
{
    int pocketWatchCheackLoad = 0;
    bool pocketWatchCheck = false;

    private void Update()
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
        }

    }


    //�������v�̃Q�b�g�Z�b�g�֐�
    public bool GetPocketWatchCheck()
    {
        return pocketWatchCheck;
    }
    public void SetPocketWatchCheck(bool PWC)
    {
        pocketWatchCheck = PWC;
    }
    //�������v�̃��Z�b�g�֐�
    public void ResetPocketWatchCheck()
    {
        pocketWatchCheck = false;
        pocketWatchCheackLoad = 0;
    }
}
