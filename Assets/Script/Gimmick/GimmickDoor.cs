using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickDoor : MonoBehaviour
{
    public GameObject clearPoint;
    public bool isHorizontal;

    int animCount = 0;
    //bool DoorIsOpen = false;

    private void Update()
    {
        /*if (DoorIsOpen)
        {
            
        }
        else
        {
            
        }*/
    }

    public IEnumerator DoorOpen()
    {
        while(animCount < 73)
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
        }
    }

    public IEnumerator DoorClose()
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
        }
    }

    

}
