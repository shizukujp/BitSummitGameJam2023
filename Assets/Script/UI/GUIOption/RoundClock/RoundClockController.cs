using System.Collections;
using UnityEngine;

public class RoundClockController : MonoBehaviour
{
    [Tooltip("���S�ƂȂ�I�u�W�F�N�g")]
    public GameObject TargetObject;
    Vector3 RotateAxis = Vector3.forward;
    [Tooltip("���v")]
    public GameObject Hour, Min;
    public void PlayRoundClockAnim(float time)
    {
        //�󋵊m�F
        float min = RoundController.instance.GetETurn() * 30;
        float hour = RoundController.instance.GetRound() * 30;

        //��ԍX�V
        // �w��I�u�W�F�N�g�𒆐S�ɉ�]����
        Hour.transform.RotateAround(
            TargetObject.transform.position,
            RotateAxis,
            -hour
            );
        // �w��I�u�W�F�N�g�𒆐S�ɉ�]����
        Min.transform.RotateAround(
            TargetObject.transform.position,
            RotateAxis,
            -min
            );

        //���������𗬂�
        StartCoroutine(RoundClock(time,hour,min));
    }

    IEnumerator RoundClock(float time,float SetHour, float SetMin)
    {
        float timer = (int)time * 60;

        float HourSpeed = SetHour / timer;
        float MinSpeed = SetMin / timer;

        while (timer>0)
        {
            timer--;

            // �w��I�u�W�F�N�g�𒆐S�ɉ�]����
            Hour.transform.RotateAround(
                TargetObject.transform.position,
                RotateAxis,
                HourSpeed
                );
            // �w��I�u�W�F�N�g�𒆐S�ɉ�]����
            Min.transform.RotateAround(
                TargetObject.transform.position,
                RotateAxis,
                MinSpeed
                );
            yield return new WaitForSeconds(0.01f);
        }

        gameObject.SetActive(false);
    }
}
