using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugSetTextLastCleared : MonoBehaviour {
    private Text gt;

    void Start() {
        gt = GetComponent<Text>();
    }

    void Update() {
        foreach (char c in Input.inputString) {
            if (c == '\b') // has backspace/delete been pressed?
            {
                if (gt.text.Length != 0) {
                    gt.text = gt.text.Substring(0, gt.text.Length - 1);
                }
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                int x = 0;
                int.TryParse(gt.text, out x);
                Debug.Log(x);
                PlayerPrefs.SetInt("lastClearedStage", x);
                Statics.updateLastClearedStage();
                gt.text = "";
            }
            else {
                gt.text += c;
            }
        }
    }
}