using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChosenLevelControl : MonoBehaviour {

    private static ChosenLevelControl _instance;
    public static ChosenLevelControl instance
    {
        get
        {
            return _instance;
        }
    }

    private static string _chosenLevel;
    public string chosenLevel
    {
        get { return _chosenLevel; }
        set { _chosenLevel = value; }
    }

    ActiveSceneControl activeSceneControlScript;
    LevelBuyControl levelBuyControlScript;

    public ChosenLevelControl()
    {
        _instance = this;
    }

    public Text standardWorldText, snowWorldText, desertWorldText, iceCreamWorldText, jungleWorldText, lavaWorldText;

    private void Awake()
    {
        activeSceneControlScript = ActiveSceneControl.instance;
        levelBuyControlScript = LevelBuyControl.instance;
    }


    public void LevelSelectMT(string name)
    {

        //deselect
        if (chosenLevel == "SnowWorldScene" && PlayerPrefs.GetInt("isTakenSnow") == 1)
        {
            snowWorldText.text = "Owned";
        }
        else if (chosenLevel == "DesertWorldScene" && PlayerPrefs.GetInt("isTakenDesert") == 1)
        {
            desertWorldText.text = "Owned";
        }
        else if (chosenLevel == "IceCreamWorldScene" && PlayerPrefs.GetInt("isTakenIceCream") == 1)
        {
            iceCreamWorldText.text = "Owned";
        }
        else if (chosenLevel == "JungleWorldScene" && PlayerPrefs.GetInt("isTakenJungle") == 1)
        {
            jungleWorldText.text = "Owned";
        }
        else if (chosenLevel == "LavaWorldScene" && PlayerPrefs.GetInt("isTakenLava") == 1)
        {
            lavaWorldText.text = "Owned";
        }
        else if (chosenLevel == "StandardWorldScene")
        {
            standardWorldText.text = "Owned";
        }

        chosenLevel = name;
        activeSceneControlScript.activeSceneName = chosenLevel;

        if (name == "SnowWorldScene" && PlayerPrefs.GetInt("isTakenSnow") == 1)
        {
            snowWorldText.text = "Selected World";
        }
        else if (name == "DesertWorldScene" && PlayerPrefs.GetInt("isTakenDesert") == 1)
        {
            desertWorldText.text = "Selected World";
        }
        else if (name == "IceCreamWorldScene" && PlayerPrefs.GetInt("isTakenIceCream") == 1)
        {
            iceCreamWorldText.text = "Selected World";
        }
        else if (name == "JungleWorldScene" && PlayerPrefs.GetInt("isTakenJungle") == 1)
        {
            jungleWorldText.text = "Selected World";
        }
        else if (name == "LavaWorldScene" && PlayerPrefs.GetInt("isTakenLava") == 1)
        {
            lavaWorldText.text = "Selected World";
        }
        else if (name == "StandardWorldScene")
        {           
            standardWorldText.text = "Selected World";
        }

    }

    /* public void StandardLevelMT()
     {
         chosenLevel = "StandardWorldScene";
         activeSceneControlScript.activeSceneName = chosenLevel;
         WhichSelected();
     }

     public void SnowLevelMT()
     {
         chosenLevel = "SnowWorldScene";

         if (PlayerPrefs.GetInt("isTakenSnow") == 1)
         {
             activeSceneControlScript.activeSceneName = chosenLevel;
             WhichSelected();
         }
         else
         {
             Debug.Log("Para ver para! Yoksa oynayamazsın");
         }
     }

     public void DesertLevelMT()
     {
         chosenLevel = "DesertWorldScene";

         if (PlayerPrefs.GetInt("isTakenDesert") == 1)
         {
             activeSceneControlScript.activeSceneName = chosenLevel;
             WhichSelected();
         }
         else
         {
             Debug.Log("Para ver para! Yoksa oynayamazsın");
         }
     }

     public void IceCreamLevelMT()
     {
         chosenLevel = "IceCreamWorldScene";

         if (PlayerPrefs.GetInt("isTakenIceCream") == 1)
         {
             activeSceneControlScript.activeSceneName = chosenLevel;
             WhichSelected();
         }
         else
         {
             Debug.Log("Para ver para! Yoksa oynayamazsın");
         }
     }

     public void JungleLevelMT()
     {
         chosenLevel = "JungleWorldScene";

         if (PlayerPrefs.GetInt("isTakenJungle") == 1)
         {
             activeSceneControlScript.activeSceneName = chosenLevel;
             WhichSelected();
         }
         else
         {
             Debug.Log("Para ver para! Yoksa oynayamazsın");
         }
     }

     public void LavaLevelMT()
     {
         chosenLevel = "LavaWorldScene";

         if (PlayerPrefs.GetInt("isTakenLava") == 1)
         {
             activeSceneControlScript.activeSceneName = chosenLevel;
             WhichSelected();
         }
         else
         {
             Debug.Log("Para ver para! Yoksa oynayamazsın");
         }
     }


     public void WhichSelected()
     {

         if (activeSceneControlScript.activeSceneName == "SnowWorldScene" && PlayerPrefs.GetInt("isTakenSnow") == 1)
         {
             snowWorldText.text = "Selected World";
             standardWorldText.text = "";
             desertWorldText.text = "";
             iceCreamWorldText.text = "";
             jungleWorldText.text = "";
             lavaWorldText.text = "";
         }
         else if (activeSceneControlScript.activeSceneName == "DesertWorldScene" && PlayerPrefs.GetInt("isTakenDesert") == 1)
         {
             desertWorldText.text = "Selected World";
             snowWorldText.text = "";
             standardWorldText.text = "";
             iceCreamWorldText.text = "";
             jungleWorldText.text = "";
             lavaWorldText.text = "";
         }
         else if (activeSceneControlScript.activeSceneName == "IceCreamWorldScene" && PlayerPrefs.GetInt("isTakenIceCream") == 1)
         {
             iceCreamWorldText.text = "Selected World";
             snowWorldText.text = "";
             desertWorldText.text = "";
             standardWorldText.text = "";
             jungleWorldText.text = "";
             lavaWorldText.text = "";
         }
         else if (activeSceneControlScript.activeSceneName == "JungleWorldScene" && PlayerPrefs.GetInt("isTakenJungle") == 1)
         {
             jungleWorldText.text = "Selected World";
             snowWorldText.text = "";
             desertWorldText.text = "";
             iceCreamWorldText.text = "";
             standardWorldText.text = "";
             lavaWorldText.text = "";
         }
         else if (activeSceneControlScript.activeSceneName == "LavaWorldScene" && PlayerPrefs.GetInt("isTakenLava") == 1)
         {
             lavaWorldText.text = "Selected World";
             snowWorldText.text = "";
             desertWorldText.text = "";
             iceCreamWorldText.text = "";
             jungleWorldText.text = "";
             standardWorldText.text = "";
         }
         else if (activeSceneControlScript.activeSceneName == "StandardWorldScene")
         {
             standardWorldText.text = "Selected World";
             snowWorldText.text = "";
             desertWorldText.text = "";
             iceCreamWorldText.text = "";
             jungleWorldText.text = "";
             lavaWorldText.text = "";
         }
     }*/
}
