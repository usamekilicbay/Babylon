using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeManager : MonoBehaviour {

    public Slider slider;

    public void VolumeManagerMT()
    {
        AudioListener.volume = slider.value;
    }
}
