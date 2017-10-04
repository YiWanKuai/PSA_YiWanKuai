﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
    
    private GameManager gameManager;

    private Animator anim;
    private Rigidbody2D rb;
    private bool isDocked;
	private bool isOffloading;
	private int currCargo;
	private int cargoCount;
	private Stack<int> containers = new Stack<int> ();

    public GameObject timer;
    public float moveSpeed;
    public bool toTheLeft;
    public float dockTime = 10f;

    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
		if (transform.position.x > 0) {
			isOffloading = false;
			anim.SetTrigger ("TurnLeft");
			cargoCount = 0;
			toTheLeft = true;
		} else {
			cargoCount = Random.Range (1, 5);
			//0 is small container, 1 is medium container, 2 is large container
			currCargo = generateNextCargo ();
			isOffloading = true;

		}
        GetComponent<SpriteRenderer>().sortingOrder = toTheLeft ? 0 : -3;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameManager.isPaused) {
            anim.enabled = true;
            if (!isDocked) {
                if (toTheLeft) {
                    rb.velocity = -moveSpeed * Statics.axis;
                }
                else {
                    rb.velocity = moveSpeed * Statics.axis;
                }
            }
            else {
                rb.velocity = Vector2.zero;
            }
        }
        else {
            anim.enabled = false;
        }
	}

    public void SetDockTime(float f) {
        dockTime = f;
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag.Equals("Port")) {
            isDocked = true;
            if (!toTheLeft) { // collided when moving right
                StartCoroutine(StartUnloading());
            }
            else {
                StartCoroutine(StartLoading());
            }
        }
    }

    IEnumerator StartUnloading() {
        GameObject newTimer = (GameObject) Instantiate(timer, transform, false);
        ShipTimer timerScript = newTimer.GetComponent<ShipTimer>();
        timerScript.time = dockTime;
        yield return new WaitForSeconds(dockTime + 0.2f);
        toTheLeft = true;
        anim.SetTrigger("TurnLeft");
        yield return new WaitForSeconds(0.5f);
        isDocked = false;
        yield return new WaitForSeconds(2f);
    }

    IEnumerator StartLoading() {
        GameObject newTimer = (GameObject)Instantiate(timer, transform, false);
        ShipTimer timerScript = newTimer.GetComponent<ShipTimer>();
        timerScript.time = dockTime;
        yield return new WaitForSeconds(dockTime + 0.2f);
        toTheLeft = false;
        anim.SetTrigger("TurnRight");
        yield return new WaitForSeconds(0.5f);
        isDocked = false;
		gameManager.addScore(getScore());
        yield return new WaitForSeconds(2f);
    }
		

    private void OnMouseDown()
    {
		if (isDocked && isOffloading && (cargoCount > 0)) {
			getCargo ();
		} else if (isDocked && !isOffloading && (gameManager.getCargo() != null) && (gameManager.contSource != "Ship")) {
			addCargo (gameManager.getCargoType());
			gameManager.resetCargo ();
		}
    }

    private void getCargo()
    {
        gameManager.setCargo(currCargo);
		gameManager.contSource = "Ship";
		cargoCount--;
		if (cargoCount > 0) {
			currCargo = generateNextCargo ();
		} else {
			currCargo = -1;
		}
    }

	private int generateNextCargo() {
		return Random.Range (1, 3);
	}

	private void addCargo(int cargo) {
		containers.Push (cargo);
	}

	public int getScore() {
		int sum = 0;
		while (containers.Count != 0) {
			sum += containers.Pop ();
		}
		Debug.Log (sum);
		return sum;
	}
}
