using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour {

    private static InputControl _instance;
    public static InputControl instance
    {
        get
        {
            return _instance;
        }
    }

    public static float horizontalValue = 0;
    public float currentHorizontal = 0;
    public float horizontalThreshold = 0.01f;
    public float horizontalForAnim;

    private void Awake()
    {
        StopMT();
    }

    void Update(){
       

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            currentHorizontal = Input.GetAxisRaw("Horizontal");

            if (currentHorizontal < -horizontalThreshold)
            {
                LeftMT();
            }
            else if (currentHorizontal > horizontalThreshold)
            {
                RightMT();
            }
            else
            {
                StopMT();
            }
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            currentHorizontal = 0;
            StopMT();
        }

       
    }

    public void LeftMT() {

        horizontalValue = -1;
        //Debug.Log(horizontalValue);
    }

    public void RightMT() {

        horizontalValue = 1;
        //Debug.Log(horizontalValue);
    }

    public void StopMT() {

        horizontalValue = 0;
        //Debug.Log(horizontalValue);
    }
    
}
