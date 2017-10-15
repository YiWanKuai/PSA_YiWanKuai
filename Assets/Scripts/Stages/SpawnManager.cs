﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    private GameManager gm;
    public GameObject[] ships; // for diff type of ships. ship[0] will be the normal ship, 2 is for boss ship
    public Transform[] leftSpawnPoints;
    public Transform[] rightSpawnPoints;

	// Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        SetTime();
        StartCoroutine("Spawn");
    }
	
    void Update() {
        if(gm.isTimeUp) {
            StopCoroutine("Spawn");
        }
    }

	void SetTime() {
        if(Statics.stageNumber < 10) {
            gm.timeLeft = 10 * Statics.stageNumber;
        }
    }

    IEnumerator Spawn() {
        GameObject go;
		if (Statics.stageNumber < 5) {  //Stages 1 to 5
			go = Instantiate (ships [0], leftSpawnPoints [0]) as GameObject;
			go.SendMessage ("SetDockTime", 5);
			yield return new WaitForSeconds (1f);
			go = Instantiate (ships [1], rightSpawnPoints [0]) as GameObject;
			go.SendMessage ("SetDockTime", 5);
			yield return new WaitForSeconds (10f);
			go = Instantiate (ships [0], leftSpawnPoints [0]) as GameObject;
			go.SendMessage ("SetDockTime", 5);
			yield return new WaitForSeconds (1f);
			go = Instantiate (ships [1], rightSpawnPoints [0]) as GameObject;
			go.SendMessage ("SetDockTime", 2);
			yield return new WaitForSeconds (10f);
			go = Instantiate (ships [0], leftSpawnPoints [0]) as GameObject;
			go.SendMessage ("SetDockTime", 5);
			yield return new WaitForSeconds (1f);
			go = Instantiate (ships [1], rightSpawnPoints [0]) as GameObject;
			go.SendMessage ("SetDockTime", 2);
			yield return new WaitForSeconds (10f);
			go = Instantiate (ships [0], leftSpawnPoints [0]) as GameObject;
			go.SendMessage ("SetDockTime", 5);
			yield return new WaitForSeconds (1f);
			go = Instantiate (ships [1], rightSpawnPoints [0]) as GameObject;
			go.SendMessage ("SetDockTime", 2);
		} else if (Statics.stageNumber % 5 == 0) {
			go = Instantiate (ships [2], leftSpawnPoints [0]) as GameObject;
			go.SendMessage ("SetDockTime", 10);
			yield return new WaitForSeconds (1f);

		}
        else {
            while (true) {
                go = Instantiate(ships[0], leftSpawnPoints[0]) as GameObject;
                go.SendMessage("SetDockTime", 5);
                yield return new WaitForSeconds(1f);
                go = Instantiate(ships[1], rightSpawnPoints[0]) as GameObject;
                go.SendMessage("SetDockTime", 5);
                yield return new WaitForSeconds(10f);
            }
        }
        yield return null;
    }
}
