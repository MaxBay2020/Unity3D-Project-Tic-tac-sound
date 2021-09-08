using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip clickClip, congradsClip, tryAgainClip;
    private AudioSource audioSource;

    public static SoundManager _instance;
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public void ClickSoundPlay()
    {
        audioSource.PlayOneShot(clickClip);
    }

    public void CongradsSoundPlay()
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(congradsClip);
    }

    public void TryAgainSoundPlay()
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(tryAgainClip);
    }
}
