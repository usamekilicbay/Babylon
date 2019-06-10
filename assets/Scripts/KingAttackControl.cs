using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingAttackControl : MonoBehaviour{

    private static KingAttackControl _instance;
    public static KingAttackControl instance
    {
        get { return _instance; }
    }

    CircleCollider2D collider;
    AudioSource audioSource;
    public AudioClip attackSound;

    ScoreControl scoreControlScript;

    private void Start()
    {
        // collider değişkenine ait olduğu nesnenin CircleCollider2D componentini atıyor
        collider = this.gameObject.GetComponent<CircleCollider2D>();
        // oyun başladığında aktif olmamasını sağlıyor çünkü sadece atak butonuna basınca çalışması gerek
        collider.enabled = false;

        scoreControlScript = ScoreControl.instance;

        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            // belirtilen tuşa basıp koşul sağlanırsa atadığımız CircleCollider2d componentini aktif ediyor 
            collider.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.L))
        {

            // belirtilen tuşa basmayı bırakıp koşul sağlanırsa atadığımız CircleCollider2d componentini de-aktif ediyor 
            collider.enabled = false;
        }
    }

    public void AttackMT()
    {
        // yukarıda yaptığımız aktif etme olayını tekrar yapıyoruz çünkü bu metod mobil de kullanılabilmesi için dokunmatik butonlara atanacak
        collider.enabled = true;
        audioSource.PlayOneShot(attackSound);
    }

    public void NonAttackMT()
    {
        // yukarıda yaptığımız de-aktif etme olayını tekrar yapıyoruz çünkü bu metod mobil de kullanılabilmesi için dokunmatik butonlara atanacak
        collider.enabled = false;

    }

}