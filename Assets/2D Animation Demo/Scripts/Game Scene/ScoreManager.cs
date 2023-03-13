using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;

    private int scoreInt;
    private int highscoreInt;
    private string format = "000000";
    // Start is called before the first frame update
    void Start()
    {
        scoreInt = 0;
        
            //if you want to put the highscore back to 0 uncomment the line just bellow
        //PlayerPrefs.SetInt("highscore", 0);
        
        highscoreInt = PlayerPrefs.GetInt("highscore", 0);
        updateText(highscoreInt, highscore, "HIGH SCORE\n");
        EnemyComplete.OnEnemyAboutToBeDestroyed += DestroyEnemy;
    }

    private void DestroyEnemy(int enemyValue)
    {
        scoreInt += enemyValue;
        updateText(scoreInt, score, "SCORE\n");
        if (scoreInt > highscoreInt)
        {
            PlayerPrefs.SetInt("highscore", scoreInt);
            highscoreInt = scoreInt;
            updateText(highscoreInt, highscore, "HIGH SCORE\n");
        }
    }

    private void updateText(int value, TextMeshProUGUI text, string startString)
    {
        text.text = startString + value.ToString(format);
    }
}
