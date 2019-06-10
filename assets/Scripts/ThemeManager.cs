using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThemeManager : MonoBehaviour {

    public bool isChanged;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            GetComponent<AudioSource>().PlayDelayed(0.2f);
        }
        else if (scene.buildIndex < 5 && scene.buildIndex != 0)
        {
            GetComponent<AudioSource>().enabled = true;
            if (isChanged)
            {
                GetComponent<AudioSource>().Play();
                isChanged = false;  
            }
        }
        else if (scene.buildIndex > 4 || scene.buildIndex < 10)
        {
            GetComponent<AudioSource>().enabled = false;
            isChanged = true;
        }

    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    //private void Update()
    //{
    //    if (SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 5 
    //        || SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 7
    //        || SceneManager.GetActiveScene().buildIndex == 8 || SceneManager.GetActiveScene().buildIndex == 9)
    //    {
    //        gameObject.GetComponent<ThemeManager>().enabled = false;
    //    }
    //    else
    //    {
    //        gameObject.GetComponent<ThemeManager>().enabled = true;
    //    }
    //}

    //void Start ()
    //{
    //    audioSource = gameObject.GetComponent<AudioSource>();
    //    LoadMusicMT();
    //}


    //void LoadMusicMT()
    //{
    //    audioSource.PlayDelayed(6.8f);
    //}
}
