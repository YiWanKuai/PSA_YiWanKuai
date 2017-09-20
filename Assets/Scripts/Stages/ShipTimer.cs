using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTimer : MonoBehaviour {
    // at speed 1.0 the thing finishes in one second
    private Animator anim;
    public float time;
    

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetFloat("Multiplier", convertToMultiplier(time));
        StartCoroutine(KillItself());
	}
	
	IEnumerator KillItself() {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    float convertToMultiplier(float input) {
        return 1f / input;
    }
}
