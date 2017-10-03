using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool isPaused;
    public bool isCleared;
    public bool isTimeUp;
    public int timeLeft;
    public GameObject canvas;
    public GameObject timeUpScreen;
    public GameObject musicManager;

	private int scoreToClear;
	private int currentScore;

    void Start() {
		currentScore = 0;
		scoreToClear = Statics.stageNumber * 0;
        StartCoroutine(StartCountdown());
    }

    void Update() {
        if(timeLeft <= 0 && !isTimeUp) {
            isTimeUp = true;
            StartCoroutine(TimeUp());
        }
    }

    public bool Unpaused() {
        return (!isPaused && !isTimeUp && !isCleared);
    }

    IEnumerator StartCountdown() {
        while (!isTimeUp) {
            if (!isPaused && !isCleared) {
                yield return new WaitForSeconds(1.0f);
                timeLeft--;
            }
            yield return null;
        }
    }

    IEnumerator TimeUp() {
        GameObject newCanvas = Instantiate(canvas) as GameObject;
        GameObject createImage = Instantiate(timeUpScreen) as GameObject;
        createImage.transform.SetParent(newCanvas.transform, false);
		PlayerPrefs.SetInt("lastClearedStage", Statics.stageNumber + 1);
		Statics.updateLastClearedStage ();
        StartCoroutine(musicManager.GetComponent<MusicManager>().playLose());
        yield return null;
    }
}
