using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_Title : MonoBehaviour
{
    [SerializeField, Tooltip("ターゲットオブジェクト")]
    private GameObject TargetObject;

    [SerializeField, Tooltip("回転軸")]
    private Vector3 RotateAxis = Vector3.up;

    [SerializeField, Tooltip("速度係数")]
    private float SpeedFactor = 0.1f;

    void Update()
    {
        if (TargetObject == null) return;

        // 指定オブジェクトを中心に回転する
        this.transform.RotateAround(
            TargetObject.transform.position,
            RotateAxis,
            360.0f / (1.0f / SpeedFactor) * Time.deltaTime
            );
    }


}
