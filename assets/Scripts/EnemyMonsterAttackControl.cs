using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonsterAttackControl : MonoBehaviour {

    
    public LayerMask layerMask;
    public float enemyMonsterMoveSpeed,enemyMonsterAspect;
    public AudioClip monsterSound;
    AudioSource audioSource;


    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        enemyMonsterAspect = this.gameObject.GetComponentInChildren<EnemyMonsterMoveControl>().enemyMonsterAspect;

        if (Physics2D.Raycast(transform.position, transform.right*enemyMonsterAspect,7.0f,layerMask))
        {
            enemyMonsterMoveSpeed = 5;
            audioSource.PlayOneShot(monsterSound);
        }
        else
        {
            enemyMonsterMoveSpeed = 2;
        }

        this.gameObject.transform.position += new Vector3(enemyMonsterMoveSpeed * enemyMonsterAspect * Time.deltaTime, 0, 0);
    }

}

    

