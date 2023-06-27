using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_Title : MonoBehaviour
{
    [SerializeField, Tooltip("�^�[�Q�b�g�I�u�W�F�N�g")]
    private GameObject TargetObject;

    [SerializeField, Tooltip("��]��")]
    private Vector3 RotateAxis = Vector3.up;

    [SerializeField, Tooltip("���x�W��")]
    private float SpeedFactor = 0.1f;

    void Update()
    {
        if (TargetObject == null) return;

        // �w��I�u�W�F�N�g�𒆐S�ɉ�]����
        this.transform.RotateAround(
            TargetObject.transform.position,
            RotateAxis,
            360.0f / (1.0f / SpeedFactor) * Time.deltaTime
            );
    }


}
