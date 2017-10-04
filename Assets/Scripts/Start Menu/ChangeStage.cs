using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStage : MonoBehaviour {


	public void Previous() {
        if(Statics.stageNumber > 1) {
            Statics.stageNumber--;
        }
    }

    public void Next() {
        if (Statics.stageNumber < Statics.lastClearedStage) {
            Statics.stageNumber++;
        }
    }
}
