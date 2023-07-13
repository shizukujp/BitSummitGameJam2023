using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundClockRotation : MonoBehaviour
{
    [SerializeField, Tooltip("�^�[�Q�b�g�I�u�W�F�N�g")]
    private GameObject TargetObject;

    [SerializeField, Tooltip("��]��")]
    private Vector3 RotateAxis = Vector3.up;

    [Tooltip("���x�W��")]
    public float SpeedFactor = 0.1f;

    Vector3 OpenPosition;

    private void Awake()
    {
        OpenPosition = transform.position;
        // �w��I�u�W�F�N�g�𒆐S�ɉ�]����
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
            // �w��I�u�W�F�N�g�𒆐S�ɉ�]����
            this.transform.RotateAround(
                TargetObject.transform.position,
                RotateAxis,
                SpeedFactor
                );
        }
    }
}
