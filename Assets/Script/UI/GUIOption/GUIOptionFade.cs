using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GUIOptionFade : MonoBehaviour
{
    //宣言部分
    //フェード用画像オブジェクト
    [SerializeField]
    Image FadeImage;

    //今フェードの状態
    bool FadingIn = false, FadingOut = false, Faded = false;



    //外部関数
    //小数点以下二桁以上以下の数値は入れないでください
    public void FadeIn(float second, float alpha = 1)
    {
        FadingIn = true;
        StartCoroutine(Fadein(second, alpha));
    }
    //小数点以下二桁以上以下の数値は入れないでください
    public void FadeOut(float second, float alpha = 0)
    {
        FadingOut = true;
        StartCoroutine(Fadeout(second, alpha));
    }
    //フェードシステムの今の状態を外のスクリプトでもらう。
    public bool GetFadingIn() { return FadingIn; }
    public bool GetFadingOut() { return FadingOut; }
    public bool GetFadingInAndOut() { return !FadingIn&&!FadingOut; }
    public bool GetFaded() { return Faded; }



    //内部関数
    IEnumerator Fadein(float second, float alpha)
    {
        var FadeSpeed = alpha / (second * 100);
        var FadeInsec = 0f;
        while (FadeInsec <= second)
        {
            FadeInsec += 0.01f;
            FadeImage.color = new Color(FadeImage.color.r,FadeImage.color.g,FadeImage.color.b,FadeImage.color.a+FadeSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, alpha);
        Faded = true;
        FadingIn = false;
    }
    IEnumerator Fadeout(float second, float alpha)
    {
        var FadeSpeed = (1 - alpha) / (second * 100);
        var FadeOutsec = 0f;
        while (FadeOutsec <= second)
        {
            FadeOutsec += 0.01f;
            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, FadeImage.color.a - FadeSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, alpha);
        Faded = false;
        FadingOut = false;
    }
}
