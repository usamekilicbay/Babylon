using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenCoin : MonoBehaviour {
    private void Awake()
    {
       // PlayerPrefs.SetInt("Coin", 10000000);
    }
    void Update ()
    {
        /*if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            if (Input.touchCount == 3)
            {
                PlayerPrefs.SetInt("Coin", 10000000);
                PlayerPrefs.Save();
            }
        }*/
	}
}
