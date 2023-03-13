using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI text;
    private string format = "000000";
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("highscore", 0);
        updateText(score, text, "HIGH SCORE ");
    }

    private void updateText(int value, TextMeshProUGUI text, string startString)
    {
        text.text = startString + value.ToString(format);
    }
}
