using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveControl : MonoBehaviour {

    private static SaveControl _instance;
    public static SaveControl instance
    {
        get
        {
            return _instance;
        }
    }

    private static int _highScore;

    public int highScore
    {
        get{ return _highScore; }
        set{ _highScore = value; }
    }

    private static int _coinSave;

    public static int coinSave
    {
        get { return _coinSave; }
        set { _coinSave = value; }
    }
    
    ScoreControl scoreControlScript;

    private void Awake()
    {

        _instance = this;

    }

    private void Start()
    {
        scoreControlScript = ScoreControl.instance;
    }


    public void SaveScoreMT()
    {
       
        if (scoreControlScript.score > PlayerPrefs.GetInt("HighScore"))
        {
            highScore = scoreControlScript.score;

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

    }

    public void SaveCoinMT()
    {

        coinSave = scoreControlScript.coin;

        PlayerPrefs.SetInt("Coin", coinSave);
        PlayerPrefs.Save();

        
    }



    


}
