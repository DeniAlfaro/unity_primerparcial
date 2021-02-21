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
    public GameOverScreen GameOverScreen;
    int maxPlatform = 0;

    public void GameOver()
    {
        
        GameOverScreen.SetUp(maxPlatform);

    }
    void Awake()
    {
        
            instance = this;       
         
    }

    public Score GetScore => score;
    
}
