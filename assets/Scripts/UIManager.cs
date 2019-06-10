using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameObject pausePanel,gameOverPanel,moveButtons,pauseButton,playAgainButton;

    public void StartOrResumeMT()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        moveButtons.SetActive(true);
    }

    public void PauseMT()
    {
        pausePanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void GameOverMT()
    {
        gameOverPanel.SetActive(true);
        moveButtons.SetActive(false);
        pauseButton.SetActive(false);
        playAgainButton.SetActive(false);
    }
}
