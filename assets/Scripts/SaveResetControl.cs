    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveResetControl : MonoBehaviour {

    private static SaveResetControl _instance;
    public static SaveResetControl instance
    {
        get
        {
            return _instance;
        }
    }

    public GameObject hiddenButton;

  /*  private void Awake()
    {
        
      / PlayerPrefs.DeleteKey("isTakenSnow");
        PlayerPrefs.DeleteKey("isTakenDesert");
        PlayerPrefs.DeleteKey("isTakenIceCream");
        PlayerPrefs.DeleteKey("isTakenJungle");
        PlayerPrefs.DeleteKey("isTakenLava");

        PlayerPrefs.SetInt("HighScore", 0);

        PlayerPrefs.SetInt("Coin", 0);

        PlayerPrefs.Save();
    }*/
    
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            if (Input.touchCount == 6)
            {
                hiddenButton.SetActive(true);
            }
        }
        

        
    }

    public void ResetBuy()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.Save();

        hiddenButton.SetActive(false);
    }
}
