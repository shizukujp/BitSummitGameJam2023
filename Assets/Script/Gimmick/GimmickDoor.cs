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
                Debug.Log("DoorOrSwitch�ɃG���[���������܂���");
                break;
        }
    }

    //���ƃX�C�b�`�̃v���O����
    void Door()
    {

    }
    void Switch()
    {

    }
}
