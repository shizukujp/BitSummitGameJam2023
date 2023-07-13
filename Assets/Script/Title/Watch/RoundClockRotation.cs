using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundClockRotation : MonoBehaviour
{
    [SerializeField, Tooltip("ターゲットオブジェクト")]
    private GameObject TargetObject;

    [SerializeField, Tooltip("回転軸")]
    private Vector3 RotateAxis = Vector3.up;

    [Tooltip("速度係数")]
    public float SpeedFactor = 0.1f;

    Vector3 OpenPosition;

    private void Awake()
    {
        OpenPosition = transform.position;
        // 指定オブジェクトを中心に回転する
        this.transform.RotateAround(
            TargetObject.transform.position,
            RotateAxis,
            SpeedFactor
            );
    }

    void Update()
    {
        if (TargetObject == null) return;

        if(gameObject.transform.position != OpenPosition)
        {
            // 指定オブジェクトを中心に回転する
            this.transform.RotateAround(
                TargetObject.transform.position,
                RotateAxis,
                SpeedFactor
                );
        }
    }
}
