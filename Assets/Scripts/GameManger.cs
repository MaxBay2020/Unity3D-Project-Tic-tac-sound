using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger _instance;
    public bool isPlayer2;
    public bool player01Ready;
    public bool player02Ready;
    public GameObject letterBoard;
    public GameObject gameBoard;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        letterBoard.SetActive(!(player01Ready && player02Ready));
        gameBoard.SetActive(player01Ready && player02Ready);
    }

}
