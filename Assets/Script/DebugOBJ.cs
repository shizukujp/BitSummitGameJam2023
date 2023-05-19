using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugOBJ : MonoBehaviour
{
    public GameObject debugObject;//適当なCollider抜きCubeを作ってassignしておいてください。
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit)
        {

            debugObject.transform.position = hit.point;
        }
        // タッチされたとき
        /*if (Input.GetMouseButtonDown(0))
        {

            // メインカメラからクリックしたポジションに向かってRayを撃つ。
            
            

        }*/
    }
}
