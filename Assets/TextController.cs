using UnityEngine;
using UnityEngine.UI; //To bring in the user UI elements.
using System.Collections;

public class TextController : MonoBehaviour {

	//To get access to the text, have to publicly expose it.
	public Text text; //In order to connect the UI element with the script, have to drag the element (Canvas -> Text in the hierarchy) down to the script area where it has Text.
	//The script text element is under inspector when you highlight the Text element in hiearchy.
	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;	
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == States.cell) {
			StateCell();
		} else if (myState == States.sheets_0) {
			StateSheetsZero();
		} else if (myState == States.sheets_1) {
			StateSheetsOne();
		} else if (myState == States.lock_0) {
			StateLockZero();
		} else if (myState == States.lock_1) {
			StateLockOne();
		} else if (myState == States.mirror) {
			StateMirror();
		} else if (myState == States.cell_mirror) {
			StateCellMirror();
		} else if (myState == States.freedom) {
			StateFreedom();
		}
	}

	void StateCell() {
		text.text = 
			"You have awoken in your prison cell. You have no recollection on how you got here. You want to escape. " +
			"There are some dirty sheets on the bed, a mirror on the wall and the door is locked from the outside.\n\n" +
			"Press S to view Sheets, M to view Mirror and L to view Lock";
		
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_0;
		}
	}

	void StateSheetsZero() {
		text.text = 
			"This bed looks like it has seen many bodies. Might even be a favorite destination for cockroaches.\n\n" +
			"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void StateSheetsOne() {
		text.text = 
			"Holding a mirror in your hand doesn't make the sheets look " +
			"any better.\n\n" +
			"Press R to Return to roaming your cell" ;
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}

	void StateLockZero() {
		text.text = 
			"This is one of those button locks. You have no idea what the combination is. " +
			"You wish you could see somehow where the dirty fingerpritns were, maybe that would help.\n\n" +
			"Press R to Return to roaming your cell.";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void StateLockOne() {
		text.text = 
			"You carefully put the mirror through the bars, and turn it round " +
			"so you can see the lock. You can just make out fingerprints around " +
			"the buttons. You press the dirty buttons, and hear a click.\n\n" +
			"Press O to Open, or R to Return to your cell" ;
		
		if (Input.GetKeyDown(KeyCode.O)) {
			myState = States.freedom;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}

	void StateMirror() {
		text.text = 
			"The dirty old mirror on the wall seems loose.\n\n" +
			"Press T to Take the mirror, or R to Return to cell" ;
		
		if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.cell_mirror;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void StateCellMirror() {
		text.text = 
			"You are still in your cell, and you STILL want to escape! There are " +
			"some dirty sheets on the bed, a mark where the mirror was, " +
			"and that pesky door is still there, and firmly locked!\n\n" +
			"Press S to view Sheets, or L to view Lock" ;
		
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_1;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1;
		}
	}

	void StateFreedom() {
		text.text = 
			"You are FREE!\n\n" +
			"Press P to Play again";
		
		if (Input.GetKeyDown(KeyCode.P)) {
			myState = States.cell;
		}
	}
}
