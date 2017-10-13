using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoBehaviour : MonoBehaviour {

    public GameManager gm;

    private int currCount;
	private Stack<int> containerStack = new Stack<int> ();
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
			if ((containerStack.Count == 0) || (gm.getCargoType () <= containerStack.Peek ())) {
				containerStack.Push (gm.getCargoType ());
				spawn ();
				gm.resetCargo ();
				shiftSP ();
			}
		} else if (gm.getCargo () == null && currCount > 0) {
			containerStack.Pop ();
			shiftSPDown ();
			gm.setCargo (getTopContainer ());
			gm.contSource = "Dock";
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
		this.gameObject.transform.GetChild(0).transform.position = new Vector3(this.gameObject.transform.GetChild(currCount).transform.position.x, this.gameObject.transform.GetChild(currCount).transform.position.y, this.gameObject.transform.GetChild(currCount).transform.position.z);
	}

	private int getTopContainer() {
		return this.gameObject.transform.GetChild (currCount).GetComponent<largeContainerBehaviour> ().sizeRef;
	}

	private void removeTopContainer() {
		Destroy (this.transform.GetChild (currCount).gameObject);
		currCount--;
	}
}
