using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool isPaused;
    public bool isCleared;
    public bool isTimeUp;
    public int timeLeft;
	public string contSource = null;
    public GameObject canvas;
    public GameObject timeUpScreen;
    public GameObject musicManager;
	public GameObject cargoLarge;
	public GameObject cargoMedium;

    private int currCargo;

	private int scoreToClear;
	private int currentScore;


    Ray ray;
    RaycastHit rayHit;

    void Start() {
		currentScore = 0;
		scoreToClear = Statics.stageNumber * 1;
        StartCoroutine(StartCountdown());
    }

    void Update() {
        if(timeLeft <= 0 && !isTimeUp) {
            isTimeUp = true;
            StartCoroutine(TimeUp());
        }
        if (Input.GetKeyDown(KeyCode.Backslash)) {
            PlayerPrefs.DeleteAll();
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
		if (currentScore >= scoreToClear) {
			PlayerPrefs.SetInt ("lastClearedStage", Statics.stageNumber + 1);
			Statics.updateLastClearedStage ();
		}
        StartCoroutine(musicManager.GetComponent<MusicManager>().playLose());
        yield return null;
    }

    public void setCargo(int cargo)
    {	
      	currCargo = cargo;
		Debug.Log ("current cargo" + currCargo);
    }

    public GameObject getCargo()
    {	
		GameObject cargo = null;
		switch (currCargo) {
		case 0:
			break;
		case 1:
			cargo = cargoMedium;
			break;
		case 2:
			cargo = cargoLarge;
			break;
		}
		return cargo;
    }

	public int getCargoType() {
		return currCargo;
	}

    public void resetCargo()
    {
        currCargo = -1;
		Debug.Log ("current cargo" + currCargo);
    }

	public void addScore(int score) {
		currentScore += score;
		Debug.Log (currentScore);
	}

	public int getCurrScore(){
		return currentScore;
	}
}
