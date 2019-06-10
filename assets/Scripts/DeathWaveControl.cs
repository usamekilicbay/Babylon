using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWaveControl : MonoBehaviour {

    public float waveSpeed;
	
	void Update () {

        StartCoroutine(DeathWaveMoveMT());

        waveSpeed += 0.00001f*Time.deltaTime;

	}

    private IEnumerator DeathWaveMoveMT() {

        yield return new WaitForSeconds(4.0f);
        transform.position += new Vector3(0, waveSpeed * Time.deltaTime, 0);

    }
}
