using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    private GameManager gm;
	private int dockTimer;
	private int intervalTimer;
    public GameObject[] ships; // for diff type of ships. ship[0] will be the normal ship, 2 is for boss ship
    public Transform[] leftSpawnPoints;
    public Transform[] rightSpawnPoints;
	private bool otherSpawnLoad = false;
	private bool otherSpawnUnload = false;

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
		if (Statics.stageNumber <= 7) {
			gm.timeLeft = 10 + (5 * (Statics.stageNumber - 1));
		} else if (Statics.stageNumber <= 10) {
			gm.timeLeft = 45;
		} else {
			gm.timeLeft = 60;
		}
			
    }

    IEnumerator Spawn() {
        GameObject go;
		if (Statics.stageNumber < 5) {  //Stages 1 to 5
			go = Instantiate (ships [0], leftSpawnPoints [1]) as GameObject;
			go.SendMessage ("SetDockTime", 5);
			yield return new WaitForSeconds (3f);
			go = Instantiate (ships [1], rightSpawnPoints [0]) as GameObject;
			go.SendMessage ("SetDockTime", 5);
			yield return new WaitForSeconds (3f);
			while (true) {
				go = Instantiate (ships [0], leftSpawnPoints [0]) as GameObject;
				dockTimer = Random.Range (3, 5);
				go.SendMessage ("SetDockTime", dockTimer);
				intervalTimer = Random.Range (4, 8);
				yield return new WaitForSeconds (intervalTimer);
				go = Instantiate (ships [0], leftSpawnPoints [1]) as GameObject;
				dockTimer = Random.Range (3, 5);
				go.SendMessage ("SetDockTime", dockTimer);
				intervalTimer = Random.Range (4, 8);
				yield return new WaitForSeconds (intervalTimer);
				go = Instantiate (ships [1], rightSpawnPoints [0]) as GameObject;
				dockTimer = Random.Range (3, 8);
				go.SendMessage ("SetDockTime", dockTimer);
				intervalTimer = Random.Range (3, 10);
				yield return new WaitForSeconds (intervalTimer);

			}
			/*go = Instantiate (ships [0], leftSpawnPoints [0]) as GameObject;
			go.SendMessage ("SetDockTime", 5);
			yield return new WaitForSeconds (3f);
			go = Instantiate (ships [1], rightSpawnPoints [0]) as GameObject;
			go.SendMessage ("SetDockTime", 5);
			yield return new WaitForSeconds (10f);
			go = Instantiate (ships [0], leftSpawnPoints [0]) as GameObject;
			go.SendMessage ("SetDockTime", 5);
			yield return new WaitForSeconds (3f);
			go = Instantiate (ships [0], leftSpawnPoints [1]) as GameObject;
			go.SendMessage ("SetDockTime", 5);
			yield return new WaitForSeconds (5f);
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
			*/
		} else if (Statics.stageNumber % 5 == 0) {
			go = Instantiate (ships [2], leftSpawnPoints [0]) as GameObject;
			go.SendMessage ("SetDockTime", gm.timeLeft);
			go.SendMessage ("SetBoss");
			yield return new WaitForSeconds (4f);
			while (true) {
				if (otherSpawnLoad) {
					go = Instantiate (ships [1], rightSpawnPoints [0]) as GameObject;
					otherSpawnLoad = !otherSpawnLoad;
				} else {
					go = Instantiate (ships [1], rightSpawnPoints [1]) as GameObject;
					otherSpawnLoad = !otherSpawnLoad;
				}
				go.SendMessage ("SetDockTime", 5);
				yield return new WaitForSeconds (12f);
			}
				

		}
        else {
            while (true) {
				go = Instantiate (ships [0], leftSpawnPoints [0]) as GameObject;
				dockTimer = Random.Range (2, 5);
				go.SendMessage ("SetDockTime", dockTimer);
				intervalTimer = Random.Range (4, 5);
				yield return new WaitForSeconds (intervalTimer);
				go = Instantiate (ships [0], leftSpawnPoints [1]) as GameObject;
				dockTimer = Random.Range (2, 5);
				go.SendMessage ("SetDockTime", dockTimer);
				intervalTimer = Random.Range (2, 8);
				if (intervalTimer > 5) {
					go = Instantiate (ships [1], rightSpawnPoints [1]) as GameObject;
					dockTimer = Random.Range (3, 6);
					go.SendMessage ("SetDockTime", dockTimer);
				}
				yield return new WaitForSeconds (intervalTimer);
				go = Instantiate (ships [1], rightSpawnPoints [0]) as GameObject;
				dockTimer = Random.Range (3, 6);
				go.SendMessage ("SetDockTime", dockTimer);
				intervalTimer = Random.Range (3, 8);
				if (intervalTimer > 5) {
					go = Instantiate (ships [0], leftSpawnPoints [0]) as GameObject;
					dockTimer = Random.Range (2, 5);
					go.SendMessage ("SetDockTime", dockTimer);
					yield return new WaitForSeconds (4f);
				}
				yield return new WaitForSeconds (intervalTimer);
            }
        }
        yield return null;
    }
}
