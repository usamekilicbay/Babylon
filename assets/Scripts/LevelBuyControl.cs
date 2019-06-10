using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelBuyControl : MonoBehaviour {

    private static LevelBuyControl _instance;
    public static LevelBuyControl instance
    {
        get
        {
            return _instance;
        }
    }


    private static int _getCoin;
    public int getCoin
    {
        get
        {
            return _getCoin;
        }
        set
        {
            _getCoin = value;
        }
    }

    //private static int standardLevelValue = 1000;
   
    private static int iceLevelValue = 5000;
    private static int desertLevelValue = 10000;
    private static int iceCreamLevelValue = 50000;
    private static int jungleLevelValue = 100000;
    private static int lavaLevelValue = 750000;

    public GameObject snowWorldLockIcon, desertWorldLockIcon, iceCreamWorldLockIcon, jungleWorldLockIcon, lavaWorldLockIcon;
    public Text standardWorldText, snowWorldText, desertWorldText, iceCreamWorldText, jungleWorldText, lavaWorldText;

    ChosenLevelControl chosenLevelControlScript;
    ActiveSceneControl activeSceneControlScript;
   

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        chosenLevelControlScript = ChosenLevelControl.instance;
        activeSceneControlScript = ActiveSceneControl.instance;

        standardWorldText.text = "Selected";
        snowWorldText.text = "5000 $";
        desertWorldText.text = "10000 $";
        iceCreamWorldText.text = "50000 $";
        jungleWorldText.text = "100000 $";
        lavaWorldText.text = "750000 $";

        IsLockMT();
       
        
    }

    private void Update()
    {
        getCoin = PlayerPrefs.GetInt("Coin");    
    }

    public void LevelBuyMT()
    {
        /*if (chosenLevelControlScript.chosenLevel == "StandardWorldScene" && !PlayerPrefs.HasKey("isTakenStandard"))
        {
            PlayerPrefs.SetInt("isTakenStandard", 1);        
            PlayerPrefs.Save();            
        }*/
        if (chosenLevelControlScript.chosenLevel == "SnowWorldScene" && getCoin >= iceLevelValue  && !PlayerPrefs.HasKey("isTakenSnow") && PlayerPrefs.GetInt("isTakenSnow") != 1)
        {
            PlayerPrefs.SetInt("isTakenSnow", 1);
            PlayerPrefs.SetInt("Coin", getCoin - iceLevelValue);
            PlayerPrefs.Save();
            IsLockMT();
        }
        else if (chosenLevelControlScript.chosenLevel == "DesertWorldScene" && getCoin >= desertLevelValue && !PlayerPrefs.HasKey("isTakenDesert") && PlayerPrefs.GetInt("isTakenDesert") != 1)
        {         
            PlayerPrefs.SetInt("isTakenDesert", 1);
            PlayerPrefs.SetInt("Coin", getCoin - desertLevelValue);
            PlayerPrefs.Save();
            IsLockMT();
        }
        else if (chosenLevelControlScript.chosenLevel == "IceCreamWorldScene" && getCoin >= iceCreamLevelValue && !PlayerPrefs.HasKey("isTakenIceCream") && PlayerPrefs.GetInt("isTakenIceCream") != 1)
        {         
            PlayerPrefs.SetInt("isTakenIceCream", 1);
            PlayerPrefs.SetInt("Coin", getCoin - iceCreamLevelValue);
            PlayerPrefs.Save();
            IsLockMT();
        }
        else if (chosenLevelControlScript.chosenLevel == "JungleWorldScene" && getCoin >= jungleLevelValue && !PlayerPrefs.HasKey("isTakenJungle") && PlayerPrefs.GetInt("isTakenJungle") != 1)
        {           
            PlayerPrefs.SetInt("isTakenJungle", 1);
            PlayerPrefs.SetInt("Coin", getCoin - jungleLevelValue);
            PlayerPrefs.Save();
            IsLockMT();
        }
        else if (chosenLevelControlScript.chosenLevel == "LavaWorldScene" && getCoin >= lavaLevelValue && !PlayerPrefs.HasKey("isTakenLava") && PlayerPrefs.GetInt("isTakenLava") != 1)
        {
            PlayerPrefs.SetInt("isTakenLava", 1);
            PlayerPrefs.SetInt("Coin", getCoin - lavaLevelValue);
            PlayerPrefs.Save();
            IsLockMT();
        }

    }

    void IsLockMT()
    {
       
        if (PlayerPrefs.HasKey("isTakenSnow"))
        {
            snowWorldLockIcon.SetActive(false);
            snowWorldText.text = "Owned";
        }

        if (PlayerPrefs.HasKey("isTakenDesert"))
        {
            desertWorldLockIcon.SetActive(false);
            desertWorldText.text = "Owned";
        }

        if (PlayerPrefs.HasKey("isTakenIceCream"))
        {
            iceCreamWorldLockIcon.SetActive(false);
            iceCreamWorldText.text = "Owned";
        }

        if (PlayerPrefs.HasKey("isTakenJungle"))
        {
            jungleWorldLockIcon.SetActive(false);
            jungleWorldText.text = "Owned";
        }

        if (PlayerPrefs.HasKey("isTakenLava"))
        {
            lavaWorldLockIcon.SetActive(false);
            lavaWorldText.text = "Owned";
        }
    }

   
}
    