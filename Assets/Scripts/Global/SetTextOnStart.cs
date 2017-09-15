using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextOnStart : MonoBehaviour {

    public string toShow;
    private Text text;


    void Awake() {
        text = GetComponent<Text>();
    }
	// Use this for initialization
	void Start () {
        text.text = toShow;
	}
}
