using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ShowTotalCoinScene : MonoBehaviour {

    private static ShowTotalCoinScene _instance;
    public static ShowTotalCoinScene instance
    {
        get
        {
            return _instance;
        }
    }

    int showTotalCoin;
    public Text totalCoinText;

	void Update ()
    {
        if (SceneManager.GetActiveScene().name == "StoreScene")
        {
            if (PlayerPrefs.HasKey("Coin"))
            {
                showTotalCoin = PlayerPrefs.GetInt("Coin");
                totalCoinText.text = showTotalCoin.ToString();
            }
        }
    }
}
