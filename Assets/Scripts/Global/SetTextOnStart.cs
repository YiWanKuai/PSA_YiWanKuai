using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextOnStart : MonoBehaviour {

    public string textToSet;
    private Text text;
    
	void Awake () {
        text = GetComponent<Text>();
	}
    
    void Start() {
        switch (textToSet) {
            default:
                text.text = textToSet;
                break;
        }
	}
}
