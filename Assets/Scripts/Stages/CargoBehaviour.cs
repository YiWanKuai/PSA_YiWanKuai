using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoBehaviour : MonoBehaviour {

    public GameManager gm;

    private int currCount;
	// Use this for initialization
	void Start () {
        currCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
		if (gm.getCargo () != null && currCount < 10) {
			spawn ();
			gm.resetCargo ();
			shiftSP ();
		} else if (gm.getCargo () == null && currCount != 0) {
			shiftSPDown ();
			gm.setCargo (getTopContainer());
			removeTopContainer ();
		}
        
    }

    void spawn()
    {
        GameObject currCargo = Instantiate(gm.getCargo(), this.gameObject.transform.GetChild(0).transform.position, this.transform.GetChild(0).transform.rotation, this.transform);
		currCount++;
		currCargo.GetComponent<SpriteRenderer>().sortingOrder = currCount;
    }

    void shiftSP()
    {
        this.gameObject.transform.GetChild(0).transform.position = new Vector3(this.gameObject.transform.GetChild(0).transform.position.x, this.gameObject.transform.GetChild(0).transform.position.y + 0.21f, this.gameObject.transform.GetChild(0).transform.position.z);
    }

	private void shiftSPDown()
	{
		this.gameObject.transform.GetChild(currCount).transform.position = new Vector3(this.gameObject.transform.GetChild(currCount).transform.position.x, this.gameObject.transform.GetChild(currCount).transform.position.y - 0.21f, this.gameObject.transform.GetChild(currCount).transform.position.z);
	}

	private GameObject getTopContainer() {
		return this.gameObject.transform.GetChild (currCount).gameObject;
	}

	private void removeTopContainer() {
		Destroy (this.transform.GetChild (currCount).gameObject);
		currCount--;
	}
}
