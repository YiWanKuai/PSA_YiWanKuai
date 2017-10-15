using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool isPaused;
    public bool isTimeUp;
    public bool isFrozen;
	public bool isStandardized;
    public float timeLeft;
	public string contSource = null;
    public GameObject canvas;
    public GameObject timeUpScreen;
    public GameObject clearScreen;
    public GameObject musicManager;
	public GameObject cargoLarge;
	public GameObject cargoMedium;

    private int currCargo;

	public int scoreToClear;
	private int currentScore;


    Ray ray;
    RaycastHit rayHit;

    void Start() {
		currentScore = 0;
		scoreToClear = Statics.stageNumber * 2;
		if(Statics.stageNumber % 5 == 0 ){
			scoreToClear = 15 + ((Statics.stageNumber - 5));
		}
        Debug.Log(scoreToClear);
        StartCoroutine(StartCountdown());
		isFrozen = false;
		isStandardized = false;
    }

    void Update() {
        if(timeLeft <= 0 && !isTimeUp) {
            if (currentScore >= scoreToClear) {
                StartCoroutine(Clear());
            }
            else {
                StartCoroutine(TimeUp());
            }
            isTimeUp = true;
        }
        if (Input.GetKeyDown(KeyCode.Backslash)) {
            PlayerPrefs.DeleteAll();
        }
    }

    public bool Unpaused() {
        return (!isPaused && !isTimeUp);
    }

    IEnumerator StartCountdown() {
        while (!isTimeUp) {
            if (!isPaused && !isFrozen) {
                yield return new WaitForSeconds(0.1f);
                timeLeft -= 0.1f;
            }
            yield return null;
        }
    }

    IEnumerator TimeUp() {
        GameObject newCanvas = Instantiate(canvas) as GameObject;
        GameObject createImage = Instantiate(timeUpScreen) as GameObject;
        createImage.transform.SetParent(newCanvas.transform, false);
        StartCoroutine(musicManager.GetComponent<MusicManager>().playLose());
        yield return null;
    }

    IEnumerator Clear() {
        GameObject newCanvas = Instantiate(canvas) as GameObject;
        GameObject createImage = Instantiate(clearScreen) as GameObject;
        createImage.transform.SetParent(newCanvas.transform, false);
		if (Statics.stageNumber == Statics.lastClearedStage) {
			PlayerPrefs.SetInt ("lastClearedStage", Statics.stageNumber + 1);
			Statics.updateLastClearedStage ();

		}
		Statics.stageNumber++;
        StartCoroutine(musicManager.GetComponent<MusicManager>().playClear());
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
