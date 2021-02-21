using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    Text pointsText;

    int points = 0;

    
    public void SetUp(int score)
    {
        points += score;
        pointsText.gameObject.SetActive(true);
        pointsText.text = $"Score: {points} points";

    }

    
}
