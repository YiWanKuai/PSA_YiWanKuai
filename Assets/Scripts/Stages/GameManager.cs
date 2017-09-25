using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool isPaused;
    public bool isCleared;
    public bool isTimeUp;
    public int timeLeft;
    public GameObject canvas;
    public GameObject timeUpScreen;
    public GameObject musicManager;

    private GameObject currCargo;

    Ray ray;
    RaycastHit rayHit;

    void Start() {
        StartCoroutine(StartCountdown());
    }

    void Update() {
        if(timeLeft <= 0 && !isTimeUp) {
            isTimeUp = true;
            StartCoroutine(TimeUp());
        }
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out rayHit))
            {
                currCargo = rayHit.collider.gameObject;
                Debug.Log("Im out");
                if(currCargo != null)
                {
                    print(currCargo.name);
                    Debug.Log("Im in");
                }
            }
        }
    }

    public bool Unpaused() {
        return (!isPaused && !isTimeUp && !isCleared);
    }

    IEnumerator StartCountdown() {
        while (!isTimeUp) {
            if (!isPaused && !isCleared) {
                yield return new WaitForSeconds(1.0f);
                timeLeft--;
            }
            yield return null;
        }
    }

    IEnumerator TimeUp() {
        GameObject newCanvas = Instantiate(canvas) as GameObject;
        GameObject createImage = Instantiate(timeUpScreen) as GameObject;
        createImage.transform.SetParent(newCanvas.transform, false);
        StartCoroutine(musicManager.GetComponent<MusicManager>().playLose());
        yield return null;
    }

    public void setCargo(GameObject cargo)
    {
        if (cargo.tag.Equals("Cargo"))
        {
            currCargo = cargo;
        }
        
        if (currCargo != null)
        {
            Debug.Log(cargo.gameObject.name);
        }
    }

    public GameObject getCargo()
    {
        return currCargo;
    }

    public void resetCargo()
    {
        currCargo = null;
    }
}
