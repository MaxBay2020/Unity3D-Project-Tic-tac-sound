using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip clickClip, congradsClip, tryAgainClip;
    private AudioSource audioSource;
    public AudioClip[] allLettersSound;

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

    public void CongratsSoundPlay()
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(congradsClip);
    }

    public void TryAgainSoundPlay()
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(tryAgainClip);
    }

    public void LetterSoundPlay(string whichLetter)
    {
        foreach (var eachLetterClip in allLettersSound)
        {
            if (eachLetterClip.name.Equals(whichLetter))
            {
                audioSource.PlayOneShot(eachLetterClip);
                break;
            }
        }
    }
}
