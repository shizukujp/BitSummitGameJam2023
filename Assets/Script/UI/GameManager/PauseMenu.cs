using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject SoundSettings, Graphobj, Settingobj, BackToHomeobj, OpenPauseMenuobj, ClosePauseMenuobj;
    //                   W50,H50    X370,Y-45   X370,Y-95   X370,Y-145      X370,Y-195      X370,Y-192,W60,H70

    //Menu Check
    bool OpeningMenu, CloseingMenu;

    //現在のアニメーション状況を記録する
    int MovingUIAnimPos = 0;

    //コルーチンチェック用
    Coroutine OpenAnim, CloseAnim;

    //MovingMenuPosition
    float MovingMenuBasePosX, MovingMenuBasePosY;

    private void Start()
    {
        MovingMenuBasePosX = OpenPauseMenuobj.transform.position.x;
        MovingMenuBasePosY = OpenPauseMenuobj.transform.position.y;
    }

    /// <summary>
    /// コルーチン関連
    /// </summary>
    IEnumerator OpenPauseMenu()
    {
        while (MovingUIAnimPos < 50)
        {
            Debug.Log(1);
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
            Debug.Log(2);
            MovingUIAnimPos--;
            SetMovingUIPos(MovingUIAnimPos);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        SetMovingUIActive(false);
        CloseingMenu = false;
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


    //内部関数
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
        BackToHomeobj.transform.position = new Vector2(MovingMenuBasePosX, MovingMenuBasePosY + Pos);
        Settingobj.transform.position = new Vector2(MovingMenuBasePosX, MovingMenuBasePosY + (Pos*2));
        Graphobj.transform.position = new Vector2(MovingMenuBasePosX, MovingMenuBasePosY + (Pos*3));
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
        //今コルーチンが動いているなら消してもどに戻す
        CheckPauseMenuCoroutine();
        //今の状態を更新
        OpeningMenu = true;
        //メニューを見えるようにするが、クリックはできないように
        SetMovingUIInteractable(false);
        SetMovingUIActive(true);
        //開く動画を流す
        OpenAnim = StartCoroutine(OpenPauseMenu());
        //開くButtonを閉じるButtonにする
        OCPauseMenu();
    }

    public void ClosePausemenu()
    {
        //If Coroutine is moving clean that Coroutine
        CheckPauseMenuCoroutine();
        //check the new situation
        CloseingMenu = true;
        //クリックはできないように
        SetMovingUIInteractable(false);
        //play the close animation
        CloseAnim = StartCoroutine(ClosePauseMenu());
        //Change the OC button
        OCPauseMenu();
    }


    public void BackToHome()
    {
        SceneManager.LoadScene("Title");
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
