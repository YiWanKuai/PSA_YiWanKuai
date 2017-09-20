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
        if (gameManager == null) {
            Debug.Log("canot find gameManager script");
        }
        if (gameManager.Unpaused()) {
            gameManager.isPaused = !gameManager.isPaused;
        }
	}
}
