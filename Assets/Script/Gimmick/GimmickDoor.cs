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


    

}
