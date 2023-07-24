using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject SoundSettings, Graphobj, Settingobj, BackToHomeobj, OpenPauseMenuobj, ClosePauseMenuobj;
    //W50,H50    X370,Y-45   X370,Y-95   X370,Y-145      X370,Y-195      X370,Y-192,W60,H70

    //Menu Check
    bool OpeningMenu, CloseingMenu;

    //���݂̃A�j���[�V�����󋵂��L�^����
    int MovingUIAnimPos = 0;

    //�R���[�`���`�F�b�N�p
    Coroutine OpenAnim, CloseAnim;

    //MovingMenuPosition
    float MovingMenuBasePosX, MovingMenuBasePosY;

    public static bool IsOpen;
    private void Start()
    {
        MovingMenuBasePosX = OpenPauseMenuobj.transform.position.x;
        MovingMenuBasePosY = OpenPauseMenuobj.transform.position.y;
    }

    /// <summary>
    /// �R���[�`���֘A
    /// </summary>
    IEnumerator OpenPauseMenu()
    {
        IsOpen = true;
        while (MovingUIAnimPos < 50)
        {
            MovingUIAnimPos++;
            SetMovingUIPos(MovingUIAnimPos);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        SetMovingUIInteractable(true);
        OpeningMenu = false;
    }

    IEnumerator ClosePauseMenu()
    {
        while (MovingUIAnimPos > 0)
        {
            MovingUIAnimPos--;
            SetMovingUIPos(MovingUIAnimPos);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        SetMovingUIActive(false);
        CloseingMenu = false;
        IsOpen = false;
    }
    void CheckPauseMenuCoroutine()
    {
        if (OpeningMenu)
        {
            OpeningMenu = false;
            StopCoroutine(OpenAnim);
        }
        if (CloseingMenu)
        {
            CloseingMenu = false;
            StopCoroutine(CloseAnim);
        }
    }


    //�����֐�
    void OCPauseMenu()
    {
        if (CloseingMenu)
        {
            ClosePauseMenuobj.SetActive(false);
            OpenPauseMenuobj.SetActive(true);
        }
        if (OpeningMenu)
        {
            OpenPauseMenuobj.SetActive(false);
            ClosePauseMenuobj.SetActive(true);
        }
    }
    void SetMovingUIPos(int Pos)
    {
        BackToHomeobj.transform.position = new Vector2(MovingMenuBasePosX, MovingMenuBasePosY + Pos*2);
        Settingobj.transform.position = new Vector2(MovingMenuBasePosX, MovingMenuBasePosY + (Pos*2*2));
        Graphobj.transform.position = new Vector2(MovingMenuBasePosX, MovingMenuBasePosY + (Pos*3*2));
    }
    void SetMovingUIActive(bool Act)
    {
        BackToHomeobj.SetActive(Act);
        Settingobj.SetActive(Act);
        Graphobj.SetActive(Act);
    }
    void SetMovingUIInteractable(bool canuse)
    {
        BackToHomeobj.GetComponent<Button>().interactable = canuse;
        Settingobj.GetComponent<Button>().interactable = canuse;
        Graphobj.GetComponent<Button>().interactable = canuse;
    }


    //Button Click event
    public void OpenPausemenu()
    {
        //���R���[�`���������Ă���Ȃ�����Ă��ǂɖ߂�
        CheckPauseMenuCoroutine();
        //���̏�Ԃ��X�V
        OpeningMenu = true;
        //���j���[��������悤�ɂ��邪�A�N���b�N�͂ł��Ȃ��悤��
        SetMovingUIInteractable(false);
        SetMovingUIActive(true);
        //�J������𗬂�
        OpenAnim = StartCoroutine(OpenPauseMenu());
        //�J��Button�����Button�ɂ���
        OCPauseMenu();
    }

    public void ClosePausemenu()
    {
        //If Coroutine is moving clean that Coroutine
        CheckPauseMenuCoroutine();
        //check the new situation
        CloseingMenu = true;
        //�N���b�N�͂ł��Ȃ��悤��
        SetMovingUIInteractable(false);
        //play the close animation
        CloseAnim = StartCoroutine(ClosePauseMenu());
        //Change the OC button
        OCPauseMenu();
    }


    public void BackToHome()
    {
        SceneManager.LoadScene("Title");
        IsOpen = false;
        SoundManager.Instance.RisetBGM();
    }
    public void Setting()
    {
        if (!SoundSettings.activeSelf)
        {
            SoundSettings.GetComponent<SoundSettings>().OpenSoundSettingsCheck();
            SoundSettings.SetActive(true);
        }
    }
    public void Graph()
    {
        Debug.Log(5);
    }


}
