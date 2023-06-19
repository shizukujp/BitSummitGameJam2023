using System.Collections;
using UnityEngine;

public class GimmickDSwitch : MonoBehaviour
{
    //�S�̃X�C�b�`�R���g���[��
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



    //�}�E�X�̓���
    private void OnMouseOver()
    {
        //Debug.Log(2);
        //K�̓e�X�g�p
        if (PlayerOverCheck && !animCheck && (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.K)))
        {
            //Debug.Log(1);
            animCheck = true;
            SwitchHadOn = true;
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





    //�������s�֐�
    void PlayerPositonCheck()
    {
        if (Vector2.Distance(player.transform.position, transform.position) == 1)
        {
            PlayerOverCheck = true;
        }
        else 
        {
            PlayerOverCheck = false;
        }
    }
}
