using UnityEngine.UI;
using UnityEngine;

public class SoundSettings : MonoBehaviour
{
    public GameObject SoundSettingsobj;
    public Slider BGM, SE;

    bool firstCheck;

    private void Update()
    {
        if (SoundSettingsobj.activeSelf)
        {
            if (firstCheck)
            {
                firstCheck = false;
                BGM.value = SoundManager.Instance.BgmVolume;
                SE.value = SoundManager.Instance.SeVolume;
            }
            else
            {
                SoundManager.Instance.BgmVolume = BGM.value;
                SoundManager.Instance.SeVolume = SE.value;
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                CloseSoundSettings();
            }
        }
    }


    public void OpenSoundSettingsCheck(bool ossc)
    {
        firstCheck = ossc;
    }
    public void CloseSoundSettings()
    {
        SoundSettingsobj.SetActive(false);
    }
}
