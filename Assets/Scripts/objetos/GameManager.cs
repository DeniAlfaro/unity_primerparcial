using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     public static GameManager instance;

    [SerializeField]

    Score score;

    public Score Score { get => score; }

    //GAME OVER SCREEN

    public static bool gameOver;

    public GameObject gameOverScreen;

    //YOU WIN SCREEN
    public static bool youWin;

    public GameObject youWinScreen;
    
    void Awake()
    {

            instance = this; 
            gameOver = false;
            youWin = false;      
         
    }

     void Update() {
        if(gameOver)
        {
            gameOverScreen.SetActive(true);
        }
        else if(youWin)
        {
            youWinScreen.SetActive(true);
        }
    }

    public Score GetScore => score;
    
}
