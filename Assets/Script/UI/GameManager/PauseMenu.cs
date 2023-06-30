using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject SoundSettings;



    //Button Click event
    public void OpenPausemenu()
    {
        Debug.Log(1);
    }

    public void ClosePausemenu()
    {

        Debug.Log(2);
    }
    public void BackToHome()
    {
        SceneManager.LoadScene("Title");
    }
    public void Setting()
    {
        if (!SoundSettings.activeSelf)
        {
            SoundSettings.GetComponent<SoundSettings>().OpenSoundSettingsCheck();
            SoundSettings.SetActive(true);
        }
    }
    public void Graph()
    {
        Debug.Log(5);
    }


}
