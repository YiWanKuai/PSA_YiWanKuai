using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStage : MonoBehaviour {

    private int latestStageCleared = 10;

	public void Previous() {
        if(Statics.stageNumber > 1) {
            Statics.stageNumber--;
        }
    }

    public void Next() {
        if (Statics.stageNumber < latestStageCleared) {
            Statics.stageNumber++;
        }
    }
}
