using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosChecker : MonoBehaviour
{
    GameObject player;
    GameObject rotate;
    bool one = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rotate = GameObject.Find("CameraPosition");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= 0.5f && !rotate.GetComponent<RotateController>().isRotate)
        {
            rotate.GetComponent<RotateController>().isRotate = true;
            one = true;
            return;
        }else if(Vector2.Distance(transform.position, player.transform.position) >= 0.5f && one)
        {
            rotate.GetComponent<RotateController>().isRotate = false;
            one = false;
        }

    }
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !rotate.GetComponent<RotateController>().isRotate)
        {
            rotate.GetComponent<RotateController>().isRotate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rotate.GetComponent<RotateController>().isRotate = false;
        }
    }*/
}
