using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject[] rotatePos;

    public bool isRotate;
    public float Speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.localEulerAngles.x);
    }

    // Update is called once per frame
    void Update()
    {
        if(isRotate && transform.localEulerAngles.x - 360 < -30.0)
        {
            transform.Rotate(Time.deltaTime * Speed, 0, 0);
        }
        else if(!isRotate && transform.localEulerAngles.x - 360 > -45.0)
        {
            transform.Rotate(-Time.deltaTime * Speed, 0, 0);
        }
    }
}
