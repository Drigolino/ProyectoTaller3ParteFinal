using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    public static int highscore;
    public Text scoreText;
    public Text highscoreTex;
    // Start is called before the first frame update
    void Start()
    {
        Load();
        score = 0;
        //PlayerPrefs.SetInt("score", 0);
        //PlayerPrefs.SetInt("highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        highscoreTex.text = highscore.ToString();
        if(score>highscore)
        {            
            highscore = score;
            Save();
        }

    }
    public void AddScore(int amount)
    {
        score += amount;       
    }  
    public void Save()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("highscore", highscore);
    }
    public void Load()
    {
        score = PlayerPrefs.GetInt("score");
        highscore = PlayerPrefs.GetInt("highscore");
    }
}
