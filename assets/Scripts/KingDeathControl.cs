using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingDeathControl : MonoBehaviour {

    private static KingDeathControl _instance;
    public static KingDeathControl instance
    {
        get { return _instance; }
    }
    
    SaveControl saveControlScript;
    UIManager uIManagerScript;
    GameSystemManager gameSystemManager;

    private void Start()
    {
        saveControlScript = SaveControl.instance;
        uIManagerScript = GameObject.Find("Object For UI Scripts").GetComponent<UIManager>();
        gameSystemManager = GameSystemManager.Instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathWave" || collision.gameObject.tag == "EnemyMonster")
        {
            DeathMT();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            DeathMT();
        }
    }

    public void DeathMT()
    {
        saveControlScript.SaveCoinMT();
        saveControlScript.SaveScoreMT();

        gameSystemManager.GameOver();
        uIManagerScript.GameOverMT();
    }
}
