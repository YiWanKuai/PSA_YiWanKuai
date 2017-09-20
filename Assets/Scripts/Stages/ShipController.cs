using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
    
    private GameManager gameManager;

    private Animator anim;
    private Collider2D coll;
    private Rigidbody2D rb;
    private bool isDocked;

    public GameObject timer;
    public float moveSpeed;
    public bool toTheLeft;
    public float dockTime = 10f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.Unpaused() && !isDocked) {
            anim.enabled = true; 
            if (toTheLeft) {
                rb.velocity = -moveSpeed * Axis.axis;
            } else {
                rb.velocity = moveSpeed * Axis.axis;
            }
        } else {
            rb.velocity = Vector2.zero;
            anim.enabled = false;
        }
	}

    void OnTriggerEnter2D (Collider2D other) {
        isDocked = true;
        if(!toTheLeft) {
            StartCoroutine(StartUnloading());
        }

        coll.enabled = false;
    }

    IEnumerator StartUnloading() {
        GameObject newTimer = (GameObject) Instantiate(timer, transform, false);
        ShipTimer timerScript = newTimer.GetComponent<ShipTimer>();
        timerScript.time = dockTime;
        yield return new WaitForSeconds(dockTime + 0.2f);
        toTheLeft = true;
        anim.SetTrigger("TurnLeft");
        isDocked = false;
        yield return new WaitForSeconds(2f);
        coll.enabled = true;
    }
}
