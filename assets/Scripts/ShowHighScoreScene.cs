using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShowHighScoreScene : MonoBehaviour {

    private static ShowHighScoreScene _instance;
    public static ShowHighScoreScene instance
    {
        get
        {
            return _instance;
        }
    }

    int showHighScore;
    public Text highScoreText;

	void Update ()
    {
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            if (PlayerPrefs.HasKey("HighScore"))
            {
                showHighScore = PlayerPrefs.GetInt("HighScore");
                highScoreText.text = showHighScore.ToString();
            }
        }
	}
}
