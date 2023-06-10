using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickDoor : MonoBehaviour
{

    enum DoorOrSwitch
    {
        Door,
        Switch,
    }
    [SerializeField]
    DoorOrSwitch doorOrSwitch = new DoorOrSwitch();


    private void Update()
    {
        switch (doorOrSwitch)
        {
            case DoorOrSwitch.Door:
                Door();
                break;
            case DoorOrSwitch.Switch:
                Switch();
                break;
            default:
                Debug.Log("DoorOrSwitchにエラーが発生しました");
                break;
        }
    }

    //扉とスイッチのプログラム
    void Door()
    {

    }
    void Switch()
    {

    }
}
