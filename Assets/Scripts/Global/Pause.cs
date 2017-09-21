using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    private GameManager gameManager;

    public GameObject canvas;
    public GameObject pauseMenu;
    public AudioMixer mixer;

	// Use this for initialization
	void Start () {
    }

    public void PauseGame() {
        GameObject newCanvas = Instantiate(canvas) as GameObject;
        GameObject createImage = Instantiate(pauseMenu) as GameObject;
        createImage.transform.SetParent(newCanvas.transform, false);
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if (!gameManager.isCleared && !gameManager.isTimeUp) {
            Time.timeScale = 0f;
        }
        gameManager.isPaused = true;
    }

    public void UnpauseGame() {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        GameObject pmenu = GameObject.FindGameObjectWithTag("PauseMenu");
        Destroy(pmenu.transform.parent.gameObject);
        Time.timeScale = 1f;
        float value;
        mixer.GetFloat("BGMVol", out value);
        PlayerPrefs.SetFloat("BGMVol", value);
        mixer.GetFloat("SFXVol", out value);
        PlayerPrefs.SetFloat("SFXVol", value);
        gameManager.isPaused = false;
    }
}
