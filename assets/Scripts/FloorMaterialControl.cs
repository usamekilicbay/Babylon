using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMaterialControl : MonoBehaviour
{

    public GameObject coinObject, trapObject,monsterObject;

    public void CoinCreateMT()
    {
        if (Random.value <= 0.3f) {
            var go = Instantiate(coinObject, transform);
            go.transform.localPosition = new Vector3(Random.Range(-2.25f, 2.25f), Random.Range(1.5f, 3f), 0f);
        }
    }

    public void TrapCreateMT()
    {  
        trapObject.transform.localPosition = new Vector3(Random.Range(-1.6f, 1.6f), 2f, 0f);
        trapObject.SetActive(Random.value <= 0.1f);
    }

    public void MonsterCreateMT()
    {
        if (gameObject.tag == "StaticFloor")
        {
            monsterObject.transform.localPosition = new Vector3(Random.Range(-2.2f, 2.2f), 3f, 0f);
            monsterObject.SetActive(Random.value <= 0.5f);
        }
    }

    public void DoMoveFloor()
    {
        if (Random.value <= 0.3f)
        {
            gameObject.GetComponent<FloorMoveControl>().enabled = true;
            gameObject.tag = "DynamicFloor";
        }
        else if (Random.value > 0.3f)
        {
            gameObject.GetComponent<FloorMoveControl>().enabled = false;
            gameObject.tag = "StaticFloor";
            
        }
    }

}
