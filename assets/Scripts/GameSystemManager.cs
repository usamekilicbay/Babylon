using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystemManager : MonoBehaviour {
    private static GameSystemManager _instance;
    public static GameSystemManager Instance { get { return _instance; } }
    //public static bool qGameOver= false;

    ScoreControl scoreControlScript;
    ActiveSceneControl activeSceneControlScript;
    UIManager uIManagerScript;
   // InterstitialAds interstitialAds;


    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        scoreControlScript  = ScoreControl.instance;
        activeSceneControlScript = ActiveSceneControl.instance;
        uIManagerScript = gameObject.GetComponent<UIManager>();
       // interstitialAds = InterstitialAds.Instance;
    }

    public void GameOver()
    {
        //interstitialAds.GecisReklamiGoster();
        uIManagerScript.GameOverMT();
        PauseGameMT();
    }

    public void PlayOrPlayAgainMT()
    {
        /*if (qGameOver)
        {
            qGameOver = false;
        }*/

        Time.timeScale = 1;
        SceneManager.LoadScene(activeSceneControlScript.activeSceneName);
    }

    public void PauseGameMT()
    {
        Time.timeScale = 0;
    }

    public void ResumeGameMT()
    {
        Time.timeScale = 1;
    }

    public void GoMainMenuMT()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void GoSettingsMT()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void GoStoreMT()
    {
        SceneManager.LoadScene("StoreScene");
    }

    public void GoCreditsMT()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
