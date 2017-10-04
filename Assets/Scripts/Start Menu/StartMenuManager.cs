using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : MonoBehaviour {

	void Awake() {
        Statics.stageNumber = PlayerPrefs.GetInt("lastClearedStage");
        Statics.stageNumber = Statics.stageNumber == 0 ? 1 : Statics.stageNumber;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Backslash)) {
            PlayerPrefs.DeleteAll();
        }
    }
}
