using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickEvents : MonoBehaviour
{
    public GameObject player01;
    public GameObject player02;
    public Texture soundMutedImage, soundUnmutedImage;
    public GameObject musicIcon;
    private bool hasMusic = true;

    private string player01Letter, player02Letter;

    public void GetLetter()
    {
        GameObject letterObject = EventSystem.current.currentSelectedGameObject;
        letterObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        letterObject.GetComponent<Button>().enabled = false;
        if (!GameManger._instance.isPlayer2toChoose)
        {
            //if its player01 turn
            player01Letter = letterObject.name;
            letterObject.transform.SetParent(player01.transform);
            letterObject.transform.localPosition = new Vector3(player01.transform.position.x + 180, 0,0);
            GameManger._instance.player01 = GameObject.Instantiate(letterObject);
            GameManger._instance.player01Ready = true;
        }
        else
        {
            //if its player02 turn
            player02Letter = letterObject.name;
            letterObject.transform.SetParent(player02.transform);
            letterObject.transform.localPosition = new Vector3(player02.transform.position.x + 120, 0, 0);
            GameManger._instance.player02 = GameObject.Instantiate(letterObject);
            GameManger._instance.player02Ready = true;
        }
        SoundManager._instance.LetterSoundPlay(letterObject.name);
        GameManger._instance.isPlayer2toChoose = !GameManger._instance.isPlayer2toChoose;
    }


    public void GoStep()
    {
        GameObject currentCell = EventSystem.current.currentSelectedGameObject;
        if (!GameManger._instance.player02Go)
        {
            // player01 is to go
            currentCell.GetComponent<Image>().sprite = GameManger._instance.player01.GetComponent<Image>().sprite;
            currentCell.GetComponent<Image>().SetNativeSize();
            GameManger._instance.player01Outline.SetActive(false);
            GameManger._instance.player02Outline.SetActive(true);
            SoundManager._instance.LetterSoundPlay(player01Letter);
        }
        else
        {
            // player02 is to go
            currentCell.GetComponent<Image>().sprite = GameManger._instance.player02.GetComponent<Image>().sprite;
            currentCell.GetComponent<Image>().SetNativeSize();
            GameManger._instance.player01Outline.SetActive(true);
            GameManger._instance.player02Outline.SetActive(false);
            SoundManager._instance.LetterSoundPlay(player02Letter);
        }

        
        currentCell.GetComponent<Button>().enabled = false;
        GameManger._instance.player02Go = !GameManger._instance.player02Go;
    }

    /// <summary>
    /// when restart button clicked, restart the game;
    /// </summary>
    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// when mute button clicked, mute the bg music
    /// </summary>
    public void MuteButtonClicked()
    {
        if (hasMusic)
        {
            // 1. switch sprite to muted image
            musicIcon.GetComponent<RawImage>().texture = soundMutedImage;
            // 2. turn off music
            Camera.main.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            // 1. switch sprite to unmuted image
            musicIcon.GetComponent<RawImage>().texture = soundUnmutedImage;
            // 2. turn on music
            Camera.main.GetComponent<AudioSource>().mute = false;
        }
        hasMusic = !hasMusic;
    }
}
