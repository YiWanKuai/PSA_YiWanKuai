using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtTimeUp : MonoBehaviour {

    private GameManager gm;
    // Use this for initialization
    void Start () {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

    }
	
	// Update is called once per frame
	void Update () {
        if (gm.isTimeUp) {
            Destroy(gameObject);
        }
	}
}
