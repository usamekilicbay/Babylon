using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMoveControl : MonoBehaviour {

	public float floorSpeed,xPosition, aspect, firstAspect;
    public static float xMove;
   

    void Start () {
      
        // değikene belirlenen sayılar arasında rastgele bir değer atıyor 
        firstAspect = Random.Range(0, 2);

        // oyun başladığında zeminler hep ilk olarak aynı gitmesin diye Start metodu içinde ilk ve tek seferlik kullanılacak yönü belirliyoruz
        if (firstAspect == 0)
        {
            aspect = -1;
        }
        else if (firstAspect == 1)
        {
            aspect = 1;
        }

	}

    private void OnEnable()
    {
        floorSpeed = Random.Range(2f, 6f);  
    }

    void Update () {
     
        // bu koşulda atandığı zemin objesinin konumu x ekseninde belirtilen değerden küçük yada eşitse geri dönmesini sağlıyor
        if (transform.position.x <= -15.0f)
        {
            aspect = 1;
        }
        // bu koşulda atandığı zemin objesinin konumu x ekseninde belirtilen değerden büyük yada eşitse geri dönmesini sağlıyor
        else if (transform.position.x >= 15.0f)
        {
            aspect = -1;
        }

        // XMove değişkenine belirtlen zemin hızı * zeminin yönü (-1 veya 1) ve time.deltatime(bu her frame de değil her saniyeye göre hesaplanmasını sağlıyor) ile çarpılarak atanıyor 
        xMove = aspect * floorSpeed * Time.deltaTime;

        // alttaki metodu çağırıyor
        GoLeftAndRigth();

       
    }

    void GoLeftAndRigth() {
        // nesnenin transform.translate özelliği sayesinde parantez içine girilen x-y-z değerlerine göre hareket etmesini sağlıyor ama bizde y ve z boş çünkü zemin sadece sağa ve sola gidebilmeli
        transform.Translate(xMove, 0, 0);

    }
}
