using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    
    void Start()
    {
        highScoreText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.highScore == 0)
        {
            highScoreText.text = "";
        }
        else
        {
            highScoreText.text = $"High Score:{GameManager.instance.highScore}";
        }
        
    }
}
