using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField]
    AudioSource bgmAudioSource;
    [SerializeField]
    AudioSource seAudioSource;


    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }


        //シーンを変えるごとに設定をリセットする
        //GameObject soundManager = CheckOtherSoundManager();
        //bool checkResult = soundManager != null && soundManager != gameObject;

        //if (checkResult)
        //{
        //    Destroy(soundManager);
        //}

        //DontDestroyOnLoad(gameObject);
        //Instance = gameObject.GetComponent<SoundManager>() ;

        //Instance = this;
    }
    //GameObject CheckOtherSoundManager()
    //{
    //    return GameObject.FindGameObjectWithTag("SoundManager");
    //}


    public float BgmVolume
    {
        get
        {
            return bgmAudioSource.volume;
        }
        set
        {
            bgmAudioSource.volume = Mathf.Clamp01(value);
        }
    }

    public float SeVolume
    {
        get
        {
            return seAudioSource.volume;
        }
        set
        {
            seAudioSource.volume = Mathf.Clamp01(value);
        }
    }

    public void PlayBgm(AudioClip clip)
    {
        bgmAudioSource.clip = clip;

        if (clip == null)
        {
            return;
        }

        bgmAudioSource.Play();
    }

    public void PlaySe(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }

        seAudioSource.PlayOneShot(clip);
    }

}