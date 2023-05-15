using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour
{
    public float rotateTime = 0.2f;

    private Transform player;
    private bool isRotating = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;

        Rotate();
    }

    void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
        {
            StartCoroutine(RotateAround(-45, rotateTime));
        }
        if (Input.GetKey(KeyCode.E) && !isRotating)
        {
            StartCoroutine(RotateAround(45, rotateTime));
        }
    }

    IEnumerator RotateAround(float angel, float time)
    {
        float number = 60 * time;
        float nextAngel = angel / number;
        isRotating = true;

        for (int i = 0; i < number; i++)
        {
            transform.Rotate(new Vector3(0, 0, nextAngel));
            yield return new WaitForFixedUpdate();
        }

        isRotating = false;
    }

    /*IEnumerator RotateAround(float angel, float time)
    {
        float number = 100 * time;
        float nextAngel = angel / number;
        isRotating = true;

        for (int i = 0; i < number; i++)
        {
            transform.Rotate(new Vector3(0, 0, nextAngel));
            yield return new WaitForSeconds(0.01);
        }

        isRotating = false;
    }*/
}
