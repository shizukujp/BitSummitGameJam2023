using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTransient : MonoBehaviour
{
    //宣言する
    //外部宣言
    public GameObject pocketWatchobj, watchobj;
    public float PWTAintrofade = 2, PWTAfading = 6,PWTAafterfading = 2,
        WTAintrofade = 2, WTAfading = 6, WTAafterfading = 2;


    //内部宣言
    bool isPocketWatchTransientAnim = false, isWatchTransientAnim = false;
    GUIOptionFade FadeOpt;

    private void Start()
    {
        FadeOpt = GetComponent<GUIOptionFade>();
    }
    //test
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PocketWatchTransientAnim();
        }
    }

    //外部関数
    public void PocketWatchTransientAnim()
    {
        if (!isPocketWatchTransientAnim)
        {
            isPocketWatchTransientAnim = true;
            StartCoroutine(PlayTransientAnim(PWTAintrofade));
        }
    }

    public void WatchTransientAnim()
    {
        if (!isWatchTransientAnim)
        {
            isWatchTransientAnim = true;
            StartCoroutine(PlayTransientAnim(WTAintrofade));
        }
    }


    //内部関数
    IEnumerator PlayTransientAnim(float fadetime)
    {
        if (FadeOpt.GetFadingInAndOut())
        {
            FadeOpt.FadeIn(fadetime);
        }
        yield return new WaitForSeconds(fadetime);

        if (isPocketWatchTransientAnim) StartCoroutine(PlayingTransientAnim(PWTAfading));
        if (isWatchTransientAnim) StartCoroutine(PlayingTransientAnim(WTAfading));
    }

    IEnumerator PlayingTransientAnim(float fadetime)
    {
        //時計アニメーション
        if (isPocketWatchTransientAnim) StartCoroutine(PlayPocketWatchAnim(fadetime-0.5f));
        if (isWatchTransientAnim) StartCoroutine(PlayWatchAnim(fadetime- 0.5f));

        yield return new WaitForSeconds(fadetime);

        if (isPocketWatchTransientAnim) StartCoroutine(PlayedTransientAnim(PWTAafterfading));
        if (isWatchTransientAnim) StartCoroutine(PlayedTransientAnim(WTAafterfading));
    }

    IEnumerator PlayedTransientAnim(float fadetime)
    {
        if (FadeOpt.GetFadingInAndOut())
        {
            FadeOpt.FadeOut(fadetime);
        }
        yield return new WaitForSeconds(fadetime);
        if (isPocketWatchTransientAnim) isPocketWatchTransientAnim = false;
        if (isWatchTransientAnim) isWatchTransientAnim = false;
    }

    IEnumerator PlayPocketWatchAnim(float animtime)
    {
        pocketWatchobj.SetActive(true);
        yield return new WaitForSeconds(animtime);
        pocketWatchobj.SetActive(false);

    }

    IEnumerator PlayWatchAnim(float animtime)
    {
        watchobj.SetActive(true);
        watchobj.GetComponent<RoundClockController>().PlayRoundClockAnim(animtime);
        yield return new WaitForSeconds(animtime);
        watchobj.SetActive(false);
    }


}
