using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    public Text pointsText;

    
   
    public void SetUp(int score)
    {   
        gameObject.SetActive(true);
        //pointsText.gameObject.SetActive(true);
        //pointsText.text = $"Score: {points} points";
        pointsText.text = score.ToString() + "POINTS";
        //pointsText.gameObject.SetActive(true);
           // pointsText.text = score.ToString() + " POINTS";
            //pointsText.text = $"Score: {score} points";
            
            //SetUp Canvas de GameOver

    }

}
