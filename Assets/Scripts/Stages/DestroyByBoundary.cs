using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

	private GameManager gameManager;

	void Start() {
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}

    void OnTriggerExit2D(Collider2D other) {
        Destroy(other.gameObject);
    }
}
