using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpdatableText : MonoBehaviour {

    public string textToSet;
    private Text text;

    void Awake() {
        text = GetComponent<Text>();
    }

    void Update() {
        switch (textToSet) {
            case "Timer":
                text.text = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().timeLeft.ToString();
                break;
            case "StageNumber":
                text.text = Statics.stageNumber.ToString();
                break;
            default:
                text.text = textToSet;
                break;
        }
    }
}
