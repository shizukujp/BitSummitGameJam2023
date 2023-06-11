using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.isPlayerTurn || Player.instance.ismove) return;
        if(Input.GetMouseButtonDown(0))
            audioSource.PlayOneShot(sound1);
    }
}
