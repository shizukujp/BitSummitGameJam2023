using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public GameObject Settings;
    public void Sound()
    {

    }

    public void OpenOption()
    {
        if (!Settings.activeSelf)
        {
            Settings.SetActive(true);
            Settings.GetComponent<SoundSettings>().OpenSoundSettingsCheck();
        }
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
