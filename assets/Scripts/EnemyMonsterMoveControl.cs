using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonsterMoveControl : MonoBehaviour
{
    public GameObject enemyMonster;
    public LayerMask layerMask;
    public int enemyMonsterAspect;

    private void Update()
    {

        if (!Physics2D.Raycast(transform.position, Vector2.down, 1f, layerMask))
        {
            Vector3 scale = transform.parent.localScale;
            scale.x *= -1;
            transform.parent.localScale = scale;
        }
      

        enemyMonsterAspect = Mathf.RoundToInt(Mathf.Sign(transform.parent.localScale.x));//bunu degistirmedin hic, obur tarafta bunu kullaniyorsun
    }
}
