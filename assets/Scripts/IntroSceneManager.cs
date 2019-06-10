using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroSceneManager : MonoBehaviour {

	
	void Start ()
    {
        DontDestroyOnLoad(GameObject.Find("Object For Active Scene Name")); 
        StartCoroutine(LoadTheGameMT());
	}

    IEnumerator LoadTheGameMT()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("MainMenuScene");
    }
}
