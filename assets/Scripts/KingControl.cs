using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class KingControl : MonoBehaviour {

    private static KingControl _instance;
    public static KingControl instance
    {
        get { return _instance; }
    }

    public float moveSpeed;
    public static int coin;
    Rigidbody2D kingRgbd2;
    AudioSource audio;
    public AudioClip step;
    float inputControlHorizontal;

    public float stepInterval = 0.5f;
    private float stepTimer = 0;

    private void Awake()
    {
        _instance = this;
    }

    void Start ()
    {
        audio = GetComponent<AudioSource>();
        kingRgbd2 = gameObject.GetComponent<Rigidbody2D>();
    }

    


    void FixedUpdate()
    {

        inputControlHorizontal = InputControl.horizontalValue;

        kingRgbd2.velocity = new Vector2(inputControlHorizontal * moveSpeed, kingRgbd2.velocity.y);

        if (inputControlHorizontal != 0)
        {
            WalkLeftNRightMT();
        }
        else
        {
            return;
        }

        if (kingRgbd2.transform.position.x <= -17f)
        {
            transform.position = new Vector2(17f,transform.position.y);            
        }
        else if (kingRgbd2.transform.position.x >= 17f)
        {
            transform.position = new Vector2(-17f,transform.position.y);
        }
        
    }


    void WalkLeftNRightMT() {


        if (inputControlHorizontal < 0)
        {
            if (stepTimer <= 0)
            {
                audio.PlayOneShot(step);
                stepTimer = stepInterval;
            }
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * -1;
            transform.localScale = scale;
        }
        else if (inputControlHorizontal > 0)
        {
            if (stepTimer <= 0)
            {
                audio.PlayOneShot(step);
                stepTimer = stepInterval;
            }
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else
            stepTimer = 0;

        if (stepTimer > 0)
            stepTimer -= Time.fixedDeltaTime;

    }

    void MoveStopMT()
    {
        audio.Stop();
    }


}
