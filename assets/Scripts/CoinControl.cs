using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour {

    public AudioClip coin;
    AudioSource audioSource;

    private void Start()
    {    
        // olutşrduğumuz değişkene AudioSource componentini atıyor
        audioSource = GetComponent<AudioSource>();
    }

    // Scriptin ait olduğu objede 2d Collider'lardan herhangi biri varsa ve "isTrigger" özelliği açık ise objenin collider'i başka bir objeninki ile çarpıştığı anda çalışır ve tek seferliktir
    private void OnTriggerEnter2D(Collider2D collision){
        // çarpışma olan objenin tag değeri girilen değere eşit ise alttaki kod bloğunu çalıştırır
        if (collision.gameObject.tag == "King")
        {
            // objenin görünmemesini ama hala sahnede var olmasını sağlar
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            // coin isimli oluşturulan sesin bir kez çalınmasını sağlar
            audioSource.PlayOneShot(coin);
            // girilen objenin girilen süre sonunda sahneden tamamen siler 
            Destroy(this.gameObject,0.7f);
        }
    }





}
