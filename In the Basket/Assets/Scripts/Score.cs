using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [Header("Score UI Settings")]
    public TextMeshProUGUI highScoreDisplay;
    public bool inGame = true;
    public bool DisplayHiScore = true;

    private int score;

    public void Start()
    {
        if (DisplayHiScore == true)
        {
            highScoreDisplay.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
    }

    public void HighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            highScoreDisplay.text = score.ToString(); 
        }
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}

