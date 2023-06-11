using System.Collections;
using UnityEngine;

public class GimmickDSwitch : MonoBehaviour
{
    //全体スイッチコントロール
    static bool SwitchHadOn = false;
    //door
    public GimmickDoor door;

    GameObject player;
    //animation
    Animator animator;
    int SwitchMode;

    bool PlayerOverCheck, animCheck = false;





    private void Start()
    {
        //set animator
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        PlayerPositonCheck();
        if (SwitchHadOn && SwitchMode == 1 && animCheck)
        {
            animCheck = false;
            StartCoroutine(CloseAnim());
        }
        //Animator reset in new frame
        animator.SetInteger("SwitchMode", SwitchMode);
    }



    //マウスの動き
    private void OnMouseOver()
    {
        //Kはテスト用
        if (PlayerOverCheck && !animCheck && (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.K)))
        {
            animCheck = true;
            SwitchHadOn = true;
            Player.instance.Motion();
            StartCoroutine(OpenAnim());

        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,0.6f,0.6f,1f);
    }
    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }



    IEnumerator OpenAnim()
    {
        yield return new WaitForSeconds(0.20f);
        SwitchHadOn = false;
        SwitchMode = 1;
        yield return new WaitForSeconds(0.30f);
        StartCoroutine(door.DoorOpen());
    }
    IEnumerator CloseAnim()
    {
        yield return new WaitForSeconds(0.20f);
        SwitchMode = 2;
        yield return new WaitForSeconds(0.30f);
        SwitchMode = 0;
        StartCoroutine(door.DoorClose());
    }





    //内部実行関数
    void PlayerPositonCheck()
    {
        if (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) < 1.5f)
        {
            PlayerOverCheck = true;
        }else if (Mathf.Abs(player.transform.position.y - gameObject.transform.position.y) < 1.5f)
        {
            PlayerOverCheck = true;
        }
        else
        {
            PlayerOverCheck = false;
        }
    }
}
