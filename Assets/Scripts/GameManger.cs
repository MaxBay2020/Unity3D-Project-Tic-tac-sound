using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public static GameManger _instance;
    public bool isPlayer2toChoose;
    public bool player01Ready;
    public bool player02Ready;
    public GameObject letterBoard;
    public GameObject gameBoard;
    public GameObject instructionText;
    public GameObject player01, player02;
    public GameObject player01Outline, player02Outline;
    public bool player02Go;

    private bool hasWinner;
    private bool noWinner;
    public GameObject bgGrey;
    public GameObject winningPanel;
    private string winner;

    private bool isPlayingDone;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {

        bgGrey.SetActive(hasWinner || noWinner);

        letterBoard.SetActive(!(player01Ready && player02Ready));
        gameBoard.SetActive(player01Ready && player02Ready);
        instructionText.SetActive(!gameBoard.activeSelf);
        player01Outline.SetActive(player01Ready && player02Ready);
        if (player02Go)
        {
            player01Outline.SetActive(false);
        }
        if (player01 != null && player02 != null)
        {
            WhoWins();
        }

        

    }

    public void WhoWins()
    {
        List<Transform> cells = new List<Transform>();
        foreach (Transform eachCell in gameBoard.transform)
        {
            cells.Add(eachCell);
        }

        string player01SpriteName = player01.GetComponent<Image>().sprite.name;
        string player02SpriteName = player02.GetComponent<Image>().sprite.name;


        //case 01: 0,1,2
        AllCases(cells, 0, 1, 2, player01SpriteName);

        //case 02: 3,4,5
        AllCases(cells, 3, 4, 5, player01SpriteName);

        //case 03: 6,7,8
        AllCases(cells, 6, 7, 8, player01SpriteName);

        //case 04: 0,3,6
        AllCases(cells, 0, 3, 6, player01SpriteName);

        //case 05: 1,4,7
        AllCases(cells, 1, 4, 7, player01SpriteName);

        //case 06: 2,5,8
        AllCases(cells, 2, 5, 8, player01SpriteName);

        //case 07: 0,4,8
        AllCases(cells, 0, 4, 8, player01SpriteName);

        //case 08: 2,4,6
        AllCases(cells, 2, 4, 6, player01SpriteName);


        WinningPanelDisplay();
    }

    /// <summary>
    /// all cases possible
    /// </summary>
    /// <param name="cells"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <param name="k"></param>
    /// <param name="player01SpriteName"></param>
    public void AllCases(List<Transform> cells,int i, int j, int k, string player01SpriteName)
    {
        if (cells[i].GetComponent<Image>().sprite != null && cells[j].GetComponent<Image>().sprite != null && cells[k].GetComponent<Image>().sprite != null)
        {
            if (cells[i].GetComponent<Image>().sprite.name == cells[j].GetComponent<Image>().sprite.name && cells[j].GetComponent<Image>().sprite.name == cells[k].GetComponent<Image>().sprite.name)
            {
                if (cells[i].GetComponent<Image>().sprite.name == player01SpriteName)
                {
                    winner="Player 1";
                    
                }
                else
                {
                    winner = "Player 2";
                }
                hasWinner = true;
            }
        }

        foreach (Transform eachCell in cells)
        {
            if (eachCell.GetComponent<Image>().sprite == null)
                return;
        }
        noWinner = true;
    }

    /// <summary>
    /// display winning panel
    /// </summary>
    public void WinningPanelDisplay()
    {
        winningPanel.SetActive(hasWinner || noWinner);

        if (hasWinner)
        {
            winningPanel.transform.Find("Title").GetComponent<Text>().text = "Congratulations!";
            winningPanel.transform.Find("Winner").GetComponent<Text>().text = winner + " wins!";
            if (!isPlayingDone)
            {
                SoundManager._instance.CongratsSoundPlay();
                isPlayingDone = true;
            }
                
            return;
        }

        if (noWinner)
        {
            winningPanel.transform.Find("Title").GetComponent<Text>().text = "Oops! It is a draw";
            winningPanel.transform.Find("Winner").GetComponent<Text>().text = "No winner!";
            
            if (!isPlayingDone)
            {
                SoundManager._instance.TryAgainSoundPlay();
                isPlayingDone = true;
            }
            return;
        }

        

    }

}
