using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GUIOptionFade : MonoBehaviour
{
    //�錾����
    //�t�F�[�h�p�摜�I�u�W�F�N�g
    [SerializeField]
    Image FadeImage;

    //���t�F�[�h�̏��
    bool FadingIn = false, FadingOut = false, Faded = false;



    //�O���֐�
    //�����_�ȉ��񌅈ȏ�ȉ��̐��l�͓���Ȃ��ł�������
    public void FadeIn(float second, float alpha = 1)
    {
        FadingIn = true;
        StartCoroutine(Fadein(second, alpha));
    }
    //�����_�ȉ��񌅈ȏ�ȉ��̐��l�͓���Ȃ��ł�������
    public void FadeOut(float second, float alpha = 0)
    {
        FadingOut = true;
        StartCoroutine(Fadeout(second, alpha));
    }
    //�t�F�[�h�V�X�e���̍��̏�Ԃ��O�̃X�N���v�g�ł��炤�B
    public bool GetFadingIn() { return FadingIn; }
    public bool GetFadingOut() { return FadingOut; }
    public bool GetFadingInAndOut() { return !FadingIn&&!FadingOut; }
    public bool GetFaded() { return Faded; }



    //�����֐�
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
