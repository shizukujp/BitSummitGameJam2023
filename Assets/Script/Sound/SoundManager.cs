using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField]
    AudioSource bgmAudioSource;
    [SerializeField]
    AudioSource bgmAudioSource2;
    [SerializeField]
    AudioSource seAudioSource;
    bool swap = false;
    public AudioClip click;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            bgmAudioSource.Play();
            bgmAudioSource.volume = 0.2f;
            bgmAudioSource2.volume = 0f;
        }
        else
        {
            Destroy(gameObject);
        }

        
        //�V�[����ς��邲�Ƃɐݒ�����Z�b�g����
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
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlaySe(click);
        }
    }

    public float BgmVolume
    {
        get
        {
            if (!swap)
            {
                return bgmAudioSource.volume;
            }
            return bgmAudioSource2.volume;
        }
        set
        {
            if(!swap)bgmAudioSource.volume = Mathf.Clamp01(value);
            if(swap)bgmAudioSource2.volume = Mathf.Clamp01(value);
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
    public void Swap()
    {
        SwapBGM(bgmAudioSource, bgmAudioSource2);
    }
    public void SwapBGM(AudioSource bgm1, AudioSource bgm2)
    {
        var fadeOutSource = bgm1;    // 再生中のAudioSourceを取得する
        var fadeInSource = bgm2; // 再生していないAudioSourceを取得する
        swap = true;
        CrossFadeBGM(fadeInSource, fadeOutSource, 1.0f).Forget();
    }

    async UniTask CrossFadeBGM(AudioSource fadeInSource, AudioSource fadeOutSource, float duration)
    {
        fadeInSource.volume = 0;
        fadeInSource.Play();
        float initVol = fadeOutSource.volume;
        for (float time = 0; time < duration; time += Time.deltaTime * 0.1f)
        {
            fadeInSource.volume = Mathf.Lerp(0, 0.3f, time / duration);
            fadeOutSource.volume = Mathf.Lerp(initVol, 0, (time / duration) * 2f);

            await UniTask.WaitForEndOfFrame();
            /* ~中断チェックは省略~ */
        }

        fadeInSource.volume = 0.3f;
        fadeOutSource.volume = 0;
    }
}