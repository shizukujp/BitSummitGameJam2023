using UnityEngine.UI;
using UnityEngine;

public class SoundSettings : MonoBehaviour
{
    public GameObject SoundSettingsobj;
    public Slider BGM, SE;

    //サウンド設定を初めて開く時
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
                Time.timeScale = 0f;
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


    public void OpenSoundSettingsCheck()
    {
        firstCheck = true;
    }
    public void CloseSoundSettings()
    {
        SoundSettingsobj.SetActive(false);
        Time.timeScale = 1f;
    }
}
