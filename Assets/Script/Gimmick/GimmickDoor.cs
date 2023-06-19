using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickDoor : MonoBehaviour
{
    public GameObject clearPoint;
    public bool isHorizontal;

    int animCount = 0;
    //ドアが空いているか
    bool IsOpen = false;

    GimmickDSwitch Switchcolor;
    public enum DoorColorType
    {
        red, blue, purple, yellow
    }
    public DoorColorType Color;
    string col;

    float speed = 0.001f;
    public Vector3 pos;

    private void Start()
    {
        col = Color.ToString();
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
                if (isHorizontal)
                {
                    pos = transform.position;
                    pos.x += 0.75f;
                    //transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
                    
                }
                else
                {
                    pos = transform.position;
                    pos.y += 0.75f;
                    //transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
                 
                }
                while(transform.position != pos)
                {
                    transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
                }

                if (transform.position == pos)
                {
                    if (clearPoint != null)
                    {
                        clearPoint.SetActive(true);
                        IsOpen = true;//開いた
                    }
                }
            }
            else if (IsOpen)
            {
                if (isHorizontal)
                {
                    pos = transform.position;
                    pos.x -= 0.75f;
                    //transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
                    //transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
                }
                else
                {
                    pos = transform.position;
                    pos.y -= 0.75f;
                    //transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
                    //transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
                }

                while (transform.position != pos)
                {
                    transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
                }

                if (transform.position == pos)
                {
                    if (clearPoint != null)
                    {
                        clearPoint.SetActive(false);
                        IsOpen = false;//閉まった
                    }
                }
            }
        }
    }
    

}
