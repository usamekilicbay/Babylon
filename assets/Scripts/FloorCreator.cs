using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCreator : MonoBehaviour {

    public GameObject floorDynamicPrefab, floorStaticPrefab, floorLongPrefab;
    GameObject lastFloor;
    int floorKind,randomDynamicFloor,randomStaticFloor,prefabCount;
    float spawnTimer, floorX, staticFloorVergeX;
    public List<Object> dynamicPREFABSList,staticPREFABSList;

 
    void Start () {
     
        // foreach döngüsünde ResurcesLoadAll fonksiyonunu kullanarak Resources Klasörü içinde ki DynamicFloorPrefabs Klasöründe bulunan bütün objeleri tarıyoruz
        foreach (var item in Resources.LoadAll<Object>("DynamicFloorPrefabs"))
        {   // yukarıda tanımladığımız dynamicPREFABSList değişkenine döngü her döndüğünde belirtilen klasör içindeki bir objeyi sırayla atıyoruz
            dynamicPREFABSList.Add(item);
        }
        // foreach döngüsünde ResurcesLoadAll fonksiyonunu kullanarak Resources Klasörü içinde ki StaticFloorPrefabs Klasöründe bulunan bütün objeleri tarıyoruz
        foreach (var item in Resources.LoadAll<Object>("StaticFloorPrefabs"))
        {   // yukarıda tanımladığımız staticPREFABSList değişkenine döngü her döndüğünde belirtilen klasör içindeki bir objeyi sırayla atıyoruz
            staticPREFABSList.Add(item);
        }

        // tanımladığımız değişkene  belirtilen iki değer arasında bir değeri otomatik olarak atıyoruz ki aşağıda yeni zeminleri random oluşturuken x ekseninde hep aynı yerde oluşmamalarını sağlayabilelim
        floorX = Random.Range(-8.3f, 8.3f);
        
        // lastFloor değişkenine Instantiate ile oluşturduğumuz nesneyi atıyoruz ki her seferinde son objeyi otomatik belirlersek y ekseninde bir sonraki objenin istediğimiz kadar birim yukarı çıkmasını kolayca ayarlayabilelim 
        lastFloor = Instantiate(floorStaticPrefab, new Vector3(floorX, transform.position.y + 10.0f, transform.position.z), transform.rotation);
        
        // float türünde ki değişkenimize atadığımız değer aşağıda o belirttiğimiz fonsikonun ne kadar süre arayla tekrar çağrılacağını ayarlamamızı sağlıyor
        spawnTimer = 0.5f;


        // Bu fonksiyon belirlenen metodu istenilen sürede sürekli çağırmaya yarıyor böylece oyun hızlandıkça objeleri daha hızlı oluşturalım ki oyuncu boşta kalmasın
        InvokeRepeating("FloorCreatorMT", 0, spawnTimer);
    }
	
	
	void Update () {
   
        // tanımladığımız değişkene  belirtilen 0 ile belirtilen listenin eleman sayısı arasında bir değeri otomatik olarak atıyoruz
        randomDynamicFloor = Random.Range(0, dynamicPREFABSList.Count);

        // tanımladığımız değişkene  belirtilen 0 ile belirtilen listenin eleman sayısı arasında bir değeri otomatik olarak atıyoruz
        randomStaticFloor = Random.Range(0, staticPREFABSList.Count);

        // tanımladığımız değişkene  belirtilen iki değer arasında bir değeri otomatik olarak atıyoruz
        floorX = Random.Range(-8.3f, 8.3f);
 
        // oluşturulan değişken ile son oluşturulmuş objenin x eksenindeki konumu alınıyor 
        staticFloorVergeX = lastFloor.transform.position.x;

    }

    void FloorCreatorMT()
    {

        // bu değişken ise 0-1 değerlerinden birini alıyor ki aşağıdaki koşullara göre oluşturulacak objenin statik mi dinamik mi olduğunu belirleniyor
        floorKind = Random.Range(0, 2);

        // sorguda değişkenin değeri 0 ise parantez içindeki yap diyoruz
        if (floorKind == 0)
        {   // yeni bir dinamik zemin objesi oluşturutoruz
            floorDynamicPrefab = (GameObject)Instantiate(dynamicPREFABSList[randomDynamicFloor], new Vector3(floorX, lastFloor.transform.position.y + 5.0f, transform.position.z), transform.rotation);
            // oluşturduğumuz zemini lastFloor değişkenine atıyoruz ki statik de olsa dinamik de olsa son obje ortak olabilsin ona göre son objenin konumundan belli bir yükseklikte yenisini oluşturabilelim
            lastFloor = floorDynamicPrefab;
        }
        // sorguda değişkenin değeri 1 ise parantez içindeki yap diyoruz
        if (floorKind == 1)
        {
            // lastPrefab nesnesinin x değerini aldığı için bu değerin  girilen değerden küçük veya eşit olup olmadığını kontrol ediyor
            if (staticFloorVergeX <= -5.2f)
            {
                // yeni bir statik zemin objesi oluşturutor ama bu sefer verilen x değeri random olmuyor 
                floorStaticPrefab = (GameObject)Instantiate(staticPREFABSList[randomStaticFloor], new Vector3(lastFloor.transform.position.x + 3.2f, lastFloor.transform.position.y + 5.0f, transform.position.z), transform.rotation);
                // oluşturduğumuz zemini lastFloor değişkenine atıyoruz ki statik de olsa dinamik de olsa son obje ortak olabilsin ona göre son objenin konumundan belli bir yükseklikte yenisini oluşturabilelim
                lastFloor = floorStaticPrefab;
            }
            // lastPrefab nesnesinin x değerini aldığı için bu değerin  girilen değerden küçük veya eşit olup olmadığını kontrol ediyor
            else if (staticFloorVergeX >= 5.2f)
            {
                // yeni bir dinamik zemin objesi oluşturutor ama bu sefer verilen x değeri random olmuyor
                floorStaticPrefab = (GameObject)Instantiate(staticPREFABSList[randomStaticFloor], new Vector3(lastFloor.transform.position.x - 3.2f, lastFloor.transform.position.y + 5.0f, transform.position.z), transform.rotation);
                // oluşturduğumuz zemini lastFloor değişkenine atıyoruz ki statik de olsa dinamik de olsa son obje ortak olabilsin ona göre son objenin konumundan belli bir yükseklikte yenisini oluşturabilelim
                lastFloor = floorStaticPrefab;
            }
            // eğer yukarıdaki şartlar uymuyorsa x ekseninin herhangi bir yerinde verilen random değerleri aşmayacak şekilde yeni bir zemin oluşturuyor 
            else
            {   // yeni bir dinamik zemin objesi oluşturutor ama bu sefer verilen x değeri random belirleniyor
                floorStaticPrefab = (GameObject)Instantiate(staticPREFABSList[randomStaticFloor], new Vector3(lastFloor.transform.position.x + Random.Range(-3.2f, 3.2f), lastFloor.transform.position.y + 5.0f, transform.position.z), transform.rotation);
                // oluşturduğumuz zemini lastFloor değişkenine atıyoruz ki statik de olsa dinamik de olsa son obje ortak olabilsin ona göre son objenin konumundan belli bir yükseklikte yenisini oluşturabilelim
                lastFloor = floorStaticPrefab;
            }
        }
        // lastFloor objesinde FloorScoreControl isimli script ekli değilse kontrol amacı taşıyor
        if (lastFloor.GetComponent<FloorScoreControl>() == null)
        {
            // eğer sart sağlanıyorsa bahsi geçen scripti objenin komponentlerinden biri olarak ekliyor
            lastFloor.AddComponent<FloorScoreControl>();
        }
    }
}
