using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour {

    private GameManager gm;

    // Use this for initialization
    void Start () {

        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void FreezeGame() {
        StartCoroutine(StartFreezeGame());
    }
	
	// Update is called once per frame
	IEnumerator StartFreezeGame () {
        gm.isFrozen = true;
        yield return new WaitForSeconds(PlayerPrefs.GetInt("freezeLevel") + 5f);
        gm.isFrozen = false;
	}
}
