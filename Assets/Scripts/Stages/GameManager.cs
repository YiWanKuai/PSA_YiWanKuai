using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool isPaused;
    public bool isCleared;
    public bool isTimeUp;
    public int timeLeft;

    void Start() {
        StartCoroutine(StartCountdown());
    }

    void Update() {
        if(timeLeft <= 0) {
            isTimeUp = true;
        }
    }

    public bool Unpaused() {
        return (!isPaused && !isTimeUp && !isCleared);
    }

    public IEnumerator StartCountdown() {
        while (!isTimeUp) {
            if (!isPaused && !isCleared) {
                Debug.Log("Countdown: " + timeLeft);
                yield return new WaitForSeconds(1.0f);
                timeLeft--;
            }
            yield return null;
        }
    }
}
