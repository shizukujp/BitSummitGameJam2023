using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickDoor : MonoBehaviour
{
    public GameObject clearPoint;
    public bool isHorizontal;

    int animCount = 0;
    //ドアが空いているか
    [Tooltip("開いていたらチェック")]
    public bool IsOpen = false;

    [Header("最初に動く方向にチェック")]
    public bool Right, Left;

    GimmickDSwitch Switchcolor;
    public enum DoorColorType
    {
        red, blue, purple, yellow
    }
    public DoorColorType Color;
    string col;

    public float speed = 1f;
    Vector3 pos;

    public bool moving = false;
    private void Start()
    {
        col = Color.ToString();
    }
    private void Update()
    {
        if(moving)
        {
            //Debug.Log("idoutyu");
            Move();
        }
        if(Input.GetKey(KeyCode.J))
        {
            Debug.Log(this.gameObject + ":" + IsOpen);
        }
    }
    public IEnumerator DoorOpenClose(string color)
    {
        if (col == color)
        {
            if (!IsOpen)//ドアが空いていなかったら
            {
                while (animCount < 73)
                {
                    if (isHorizontal)
                    {
                        transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
                    }
                    animCount++;
                    yield return new WaitForEndOfFrame();
                }
                animCount = 0;
                if (clearPoint != null)
                {
                    clearPoint.SetActive(true);
                    IsOpen = true;
                }
            }
            else if (IsOpen)//ドアが空いていたら
            {
                while (animCount < 73)
                {
                    if (isHorizontal)
                    {
                        transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
                    }
                    animCount++;
                    yield return new WaitForEndOfFrame();
                }
                animCount = 0;
                if (clearPoint != null)
                {
                    clearPoint.SetActive(false);
                    IsOpen = false;
                }
            }
        }
        
    }


    public void DoorOpenOrClose(string color)
    {
        if (col == color)
        {
            if (!IsOpen)//ドアが空いていなかったら
            {
                if(Right)
                {
                    if (isHorizontal)
                    {
                        pos = transform.position;
                        pos.x += 1f;
                    }
                    else
                    {
                        pos = transform.position;
                        pos.y += 1f;
                    }
                }else if(Left)
                {
                    if (isHorizontal)
                    {
                        pos = transform.position;
                        pos.x -= 1f;
                    }
                    else
                    {
                        pos = transform.position;
                        pos.y -= 1f;
                    }
                }else
                {
                    if (isHorizontal)
                    {
                        pos = transform.position;
                        pos.x += 1f;
                    }
                    else
                    {
                        pos = transform.position;
                        pos.y += 1f;
                    }
                }
                moving = true;
            }
            else if (IsOpen)
            {
                if(Right)
                {
                    if (isHorizontal)
                    {
                        pos = transform.position;
                        pos.x -= 1f;
                    }
                    else
                    {
                        pos = transform.position;
                        pos.y -= 1f;
                    }
                }else if(Left)
                {
                    if (isHorizontal)
                    {
                        pos = transform.position;
                        pos.x += 1f;
                    }
                    else
                    {
                        pos = transform.position;
                        pos.y += 1f;
                    }
                }else
                {
                    if (isHorizontal)
                    {
                        pos = transform.position;
                        pos.x -= 1f;
                    }
                    else
                    {
                        pos = transform.position;
                        pos.y -= 1f;
                    }
                }
                moving = true;
            }
        }
    }


    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        if (transform.position == pos)
        {
            int i = 0;
            

            if(!IsOpen && i == 0)
            {
                if (clearPoint != null) clearPoint.SetActive(true);
                IsOpen = true;//開いた
                i = 1;
            }
            if(IsOpen && i == 0)
            {
                if (clearPoint != null) clearPoint.SetActive(false);
                IsOpen = false;//閉まった
            }
            moving = false;
        }
    }
}
