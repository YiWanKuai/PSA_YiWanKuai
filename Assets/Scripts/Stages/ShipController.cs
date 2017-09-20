using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    private Rigidbody2D rb;
    private GameManager gameManager;
    private Animator anim;

    public float moveSpeed;
    public bool toTheLeft;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.Unpaused()) {
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
        anim.SetTrigger("TurnLeft");
        toTheLeft = true;
    }
}
