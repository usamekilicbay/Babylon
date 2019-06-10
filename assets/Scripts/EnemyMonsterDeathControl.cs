using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonsterDeathControl : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathWave")
        {
            DeathMT();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "King")
        {
            DeathMT();
        }
    }

    void DeathMT()
    {
        //Destroy(this.gameObject);
        gameObject.SetActive(false);
    }
}
