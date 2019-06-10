using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingJumpControl : MonoBehaviour
{
    private static KingJumpControl _instance;
    public static KingJumpControl instance
    {
        get
        {
            return _instance;
        }
    }

    public float jumpPower; 
    Rigidbody2D kingJumpRgbd2;
    public GameObject floor;

    int jumpCount = 2;
    int lastJumpCount = 0;

   
    private void Start()
    {
        kingJumpRgbd2 = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            JumpContMT();
        }
    }

    public void JumpContMT()
    {
        if (lastJumpCount > 0)
        {
            lastJumpCount--;
            kingJumpRgbd2.velocity = Vector2.up * jumpPower;
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "StaticFloor")
        {

            lastJumpCount = jumpCount;
        }
        else if (collision.gameObject.tag == "DynamicFloor")
        {
            floor = collision.gameObject;
            transform.SetParent(floor.transform, true);

            lastJumpCount = jumpCount;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.SetParent(null);
    }



}
