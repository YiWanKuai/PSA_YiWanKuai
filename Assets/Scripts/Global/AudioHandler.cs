using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour {
    
    public AudioMixer master;

    public void UpdateBGMVol(float newVol) {
        master.SetFloat("BGMVol", newVol);
    }
    public void UpdateSFXVol(float newVol) {
        master.SetFloat("SFXVol", newVol);
    }
}
