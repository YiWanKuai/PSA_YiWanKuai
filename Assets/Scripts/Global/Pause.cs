using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    private GameManager gameManager;

	// Use this for initialization
	void Start () {
    }
	
	public void TogglePauseGame () {

        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if (!gameManager.isCleared && !gameManager.isTimeUp) {
            if (gameManager.isPaused) {
                Time.timeScale = 1f;
            }
            else {
                Time.timeScale = 0f;
            }
            gameManager.isPaused = !gameManager.isPaused;
        }
	}
}
