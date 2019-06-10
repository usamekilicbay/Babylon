using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ActiveSceneControl : MonoBehaviour {

    private static ActiveSceneControl _instance;
    public static ActiveSceneControl instance
    {
        get
        {
            return _instance;
        }
    }

    ChosenLevelControl chosenLevelControlScript;

    public string activeSceneName;

    private void Awake()
    {
        _instance = this;
    }

    public void ActiveSceneMT()
    {     
            SceneManager.LoadScene(activeSceneName);
    }
}
