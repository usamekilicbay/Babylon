using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//bunu player objesine ekleyeceğiz
public class PlatformManager : MonoBehaviour {

    public static PlatformManager instance;

    public GameObject[] platforms;

    bool isRunning;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        isRunning = false;
    }

    private IEnumerator OnCollisionExit2D(Collision2D collision)
    {


        if (isRunning == true)
        {
            yield break;
        }

        if (collision.gameObject.tag == "StaticFloor" || collision.gameObject.tag == "DynamicFloor")
        {

            //önemli olan bu scripting tek bir objede çalışması
            //player herhangi bir objeye iniş yaptığında en alttaki platformu en üste taşımalıyızanladım
            //en alttaki objeyi nasıl buluruz

            yield return new WaitForSeconds(1.0f);

            //en alt objeyi 18 unit yukarıya taşı
            var enAlt = platforms.OrderBy(i => i.transform.position.y).FirstOrDefault();

            //en üste taşı
            enAlt.transform.Translate(Random.Range(-10f, 10f), 4.0f * platforms.Length, 0f);
            enAlt.GetComponent<FloorScoreControl>().getScore = false;
            enAlt.transform.localScale = new Vector3(Random.Range(1f, 1.5f), 1, 1);

            //içine rasgele coin ve tuzak spawnla
            var floorMaterialControlScript = enAlt.GetComponent<FloorMaterialControl>();
            floorMaterialControlScript.CoinCreateMT();
            floorMaterialControlScript.TrapCreateMT();
            floorMaterialControlScript.MonsterCreateMT();
            floorMaterialControlScript.DoMoveFloor();


            /*var j = 0;//debug için doğrumu sıralıyor bakmak için yaptım silicez sonra bu kısmı
            foreach (var i in platforms.OrderBy(i => i.transform.position.y))
            {
                i.name = j.ToString();
                j++;
            }*/
        }
    }

}
