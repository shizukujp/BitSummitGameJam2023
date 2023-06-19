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

    GameObject[] doors;

    //色を指定
    public enum SwitchColorType
    {
        red, blue, purple, yellow
    }
    public SwitchColorType color;
    string col;

    private void Start()
    {
        //set animator
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        doors = GameObject.FindGameObjectsWithTag("Door");
        col = color.ToString();
    }

    private void Update()
    {
        PlayerPositonCheck();
        if (SwitchHadOn && SwitchMode == 1 && animCheck)
        {
            animCheck = false;
            Debug.Log("false");
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
        if (!doors[doors.Length - 1].GetComponent<GimmickDoor>().moving)
        {
            if (PlayerOverCheck && Input.GetMouseButton(0))
            {
                int i = 1;
                if (SwitchMode != 1 && i == 1)
                {
                    SwitchMode = 1;
                    i = 0;
                    Debug.Log("orosu");
                }
                if(SwitchMode == 1 && i == 1)
                {
                    SwitchMode = 2;
                    Debug.Log("ageru");
                }
                foreach (GameObject door in doors)
                {
                    GimmickDoor dor = door.GetComponent<GimmickDoor>();
                    dor.DoorOpenOrClose(col);
                }
            }
        }
        
        /*if (PlayerOverCheck && !animCheck && (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.K)))
        {
            //Debug.Log(1);
            //animCheck = true;
            SwitchHadOn = true;
            //StartCoroutine(Anim());
            foreach (GameObject door in doors)
            {
                GimmickDoor dor = door.GetComponent<GimmickDoor>();
                dor.DoorOpenOrClose(col);
            }
        }*/
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,0.6f,0.6f,1f);
    }
    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }



    IEnumerator Anim()
    {
        yield return new WaitForSeconds(0.20f);
        SwitchHadOn = false;
        SwitchMode = 1;
        yield return new WaitForSeconds(0.30f);
        foreach (GameObject door in doors)
        {
            GimmickDoor dor = door.GetComponent<GimmickDoor>();
            StartCoroutine(dor.DoorOpenClose(col));
        }
    }
    IEnumerator CloseAnim()
    {
        yield return new WaitForSeconds(0.20f);
        SwitchMode = 2;
        yield return new WaitForSeconds(0.30f);
        SwitchMode = 0;
        foreach (GameObject door in doors)
        {
            GimmickDoor dor = door.GetComponent<GimmickDoor>();
            dor.DoorOpenOrClose(col);
        }
        Debug.Log("close");
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
