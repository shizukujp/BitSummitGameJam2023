using System.Collections;
using UnityEngine;

public class RoundClockController : MonoBehaviour
{
    [Tooltip("中心となるオブジェクト")]
    public GameObject TargetObject;
    Vector3 RotateAxis = Vector3.forward;
    [Tooltip("時計")]
    public GameObject Hour, Min;
    public void PlayRoundClockAnim(float time)
    {
        //状況確認
        float min = RoundController.instance.GetETurn() * 30;
        float hour = RoundController.instance.GetRound() * 30;

        //状態更新
        // 指定オブジェクトを中心に回転する
        Hour.transform.RotateAround(
            TargetObject.transform.position,
            RotateAxis,
            -hour
            );
        // 指定オブジェクトを中心に回転する
        Min.transform.RotateAround(
            TargetObject.transform.position,
            RotateAxis,
            -min
            );

        //代入→動画を流す
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

            // 指定オブジェクトを中心に回転する
            Hour.transform.RotateAround(
                TargetObject.transform.position,
                RotateAxis,
                HourSpeed
                );
            // 指定オブジェクトを中心に回転する
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
