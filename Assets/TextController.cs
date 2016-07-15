using UnityEngine;
using UnityEngine.UI; //To bring in the user UI elements.
using System.Collections;

public class TextController : MonoBehaviour {

	//To get access to the text, have to publicly expose it.
	public Text text; //In order to connect the UI element with the script, have to drag the element (Canvas -> Text in the hierarchy) down to the script area where it has Text.
	//The script text element is under inspector when you highlight the Text element in hiearchy.

	// Use this for initialization
	void Start () {
		text.text = "Hello world";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			text.text = 
				"You have awoken in your prison cell. You have no recollection on how you got here. You want to escape. " +
				"There are some dirty sheets on the bed, a mirror on the wall and the door is locked from the outside.\n\n" +
				"Press S to view Sheets, M to view Mirror and L to view Lock";
		}
	}
}
