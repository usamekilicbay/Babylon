using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingPointNScoreControl : MonoBehaviour {

    private static KingPointNScoreControl _instance;
    public static KingPointNScoreControl instance
    {
        get { return _instance; }
    }

    ScoreControl scoreControlScript;
    FloorScoreControl floorScoreControlScript;

    private void Start()
    {
        scoreControlScript = ScoreControl.instance;
        //floorScoreControlScript = new FloorScoreControl();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            scoreControlScript.coinPoint += 10;
            scoreControlScript.coin += 10;
        }

        if (collision.gameObject.tag == "EnemyMonster")
        {
            scoreControlScript.killPoint += 50;
        }

        if (collision.gameObject.tag == "DynamicFloor" || collision.gameObject.tag == "StaticFloor")
        {
            if (!collision.gameObject.GetComponent<FloorScoreControl>().getScore)
            {
                scoreControlScript.floorPoint += 1;
                collision.gameObject.GetComponent<FloorScoreControl>().getScore = true;
            }

        }

    }

   
}
