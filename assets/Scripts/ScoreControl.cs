using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreControl : MonoBehaviour {

    private static ScoreControl _instance; //burası sınıfın örneği yani orjinali aslında, static olarak tutuluyor, dışardan erişilemez.
    public static ScoreControl instance // burası da sınıfın örneğini tutar, geri döndürür sadece get ile, fakat set edilemediği için değiştiri
    {
        get
        {
            return _instance;//
        }
    }

    public Text scoreText;
    public Text gameOverMoneyText;
    public GameObject gameOver;
    private static int _coin, _coinPoint, _floorPoint, _killPoint, _score;

    public int coinPoint
    {
        get
        {
            return _coinPoint;
        }
        set
        {
            _coinPoint = value;
        }
    }

    public int coin
    {
        get
        {
            return _coin;
        }
        set
        {
            _coin = value;
        }
    }

    public int floorPoint
    {
        get
        {
            return _floorPoint;
        }
        set
        {
            _floorPoint = value;
        }
    }

    public int killPoint
    {
        get
        {
            return _killPoint;
        }
        set
        {
            _killPoint = value;
        }
    }

    public int score
    {
        get
        {
            return _score = coinPoint + floorPoint + killPoint;
        }
        set
        {
            _score = value;
        }
    }


    #region metodlar
    private void Awake()
    {
        _instance = this;

        ScoreResetMT();
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
    }

    private void Update()
    {
         if (SceneManager.GetActiveScene().name != "StoreScene" || SceneManager.GetActiveScene().name != "MainMenuScene" || SceneManager.GetActiveScene().name != "SettingsScene" || SceneManager.GetActiveScene().name != "IntrosScene")
        {
            ScoreMT();

            if (gameOver.activeInHierarchy  == true)
            {
                gameOverMoneyText.text = coinPoint.ToString();
            }
        }
        
    }

    public void ScoreResetMT()
    {
        coinPoint = 0;
        floorPoint = 0;
        killPoint = 0;
    }

    public void ScoreMT()
    {
        scoreText.text = score.ToString();
    }
    #endregion

}
