using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMoverControl : MonoBehaviour {

    FloorMaterialControl floorMaterialControlScript;

    bool isRunning;

    private void Start()
    {
        floorMaterialControlScript = GetComponentInChildren<FloorMaterialControl>();
        floorMaterialControlScript.CoinCreateMT();
        floorMaterialControlScript.TrapCreateMT();
        floorMaterialControlScript.DoMoveFloor();
    }

    private void OnEnable()
    {
        isRunning = false;
    }

    //bu script şuan 2 tane objeye ekli(father of obhjects mi ne doğru mu evet ve bundan önce de her zemine ekliydi)
    //şimdi player platforma dolunduğunda burası çalışıyor (e/h)e
    //bulunduğumuz platformu 3 saniye sonra yerini değiştiriyor ?e
    //bu mantık pek iyi değil bu şekilde olmaz bitane boş sahne aç

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (isRunning == true)
        {
            yield break;
        }

        isRunning = true;

        if (collision.gameObject.tag == "King")
        {
            yield return new WaitForSeconds(3.0f);

            collision.transform.parent = null;

            transform.position = new Vector2(Random.Range(-10.0f, 10.0f),transform.position.y + 12);
            GameObject.Find("Floor").transform.localScale = new Vector2(Random.Range(1f, 1.51f), 1);
            isRunning = false;
        }
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "King")
    //    {           
    //        StartCoroutine(FloorMoverMT());
    //        //floorMaterialControlScript.CoinCreateMT();
    //        //floorMaterialControlScript.TrapCreateMT();
    //    }
    //}
    ////maksat ne burda bastığın gibi giderse zemin yere düşersin :D 3saniye gecikme veriyor işte 
    //private IEnumerator FloorMoverMT()
    //{
    //    yield return new WaitForSeconds(3.0f);
    //    float random = Random.Range(-12.0f, 12.0f);
    //    this.gameObject.transform.position = new Vector2(random, transform.position.y + 12);
    //}
}
