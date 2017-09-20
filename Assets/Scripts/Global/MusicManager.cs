using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    private AudioSource[] audioSources;
    private AudioSource BGM;
    private AudioSource clearClip;
    private AudioSource loseClip;

	// Use this for initialization
	void Start () {
        audioSources = GetComponents<AudioSource>();
        BGM = audioSources[0];
        if (audioSources.Length > 1) {
            loseClip = audioSources[1];
        }
        if (audioSources.Length > 2) {
            clearClip = audioSources[2];
        }
        BGM.Play();
	}
	
	public void playLose () {
        BGM.Stop();
        loseClip.Play();
	}

    public void playClear() {
        BGM.Stop();
        clearClip.Play();
    }
}
