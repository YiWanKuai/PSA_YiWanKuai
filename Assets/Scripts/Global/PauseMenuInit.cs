using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenuInit : MonoBehaviour {

    public AudioMixer mixer;

	// Use this for initialization
	void Start () {
        Slider[] sliders = GetComponentsInChildren<Slider>();
        float value;
        mixer.GetFloat("BGMVol", out value);
        sliders[0].value = value;
        mixer.GetFloat("SFXVol", out value);
        sliders[1].value = value;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
