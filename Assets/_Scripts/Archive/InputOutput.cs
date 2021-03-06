using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class InputOuput : MonoBehaviour {
	public GameObject input1dropdown;
	public GameObject output1dropdown;
	public GameObject input2dropdown;
	public GameObject output2dropdown;

	public GameObject leftController;
	public GameObject leftHand; 
	public GameObject rightController;
	public GameObject rightHand; 
	public GameObject leftFoot; 
	public GameObject rightFoot;

	public GameObject firstInpDropResult;
	public GameObject firstOutDropResult; 
	public GameObject secondInpDropResult;
	public GameObject secondOutDropResult; 



	//Initialize listener as soon as your object loads into the scene; set default values for inputs and outputs
	void Awake () {
		AddListenerToDropdown (); 
		firstInpDropResult = leftController;
		firstOutDropResult = leftHand; 
		secondInpDropResult = rightController;
		secondOutDropResult = rightHand; 
	}

	//Adds a listener to the Dropdown's OnValueChange event
	void AddListenerToDropdown() {

		//Grab a reference to your Dropdown component
		Dropdown dropdown_inp1 = input1dropdown.GetComponent<Dropdown>();
		Dropdown dropdown_out1 = output1dropdown.GetComponent<Dropdown> (); 
		Dropdown dropdown_inp2 = input2dropdown.GetComponent<Dropdown>();
		Dropdown dropdown_out2 = output2dropdown.GetComponent<Dropdown> (); 

		//Add a listener to the event
		dropdown_inp1.onValueChanged.AddListener(delegate {OnDropdownSelectFirst(dropdown_inp1);}); 
		dropdown_out1.onValueChanged.AddListener (delegate {OnOutputDropdownSelectFirst(dropdown_out1);}); 
		dropdown_inp2.onValueChanged.AddListener(delegate {OnDropdown2Select(dropdown_inp2);}); 
		dropdown_out2.onValueChanged.AddListener (delegate {OnOutputDropdown2Select(dropdown_out2);}); 
	}

	/**When a dropdown option is selected, firstInpDropResult is set to the corresponding value.
		The leftController is the parent if either the default or first option is chosen while
		the rightController is the parent if the second option is chosen. **/
	void OnDropdownSelectFirst(Dropdown drop){
		switch (drop.value) {
		case 0: 
			firstInpDropResult = leftController;
			break;

		case 1:
			firstInpDropResult = rightController;
			break;

		//Same as case 0
		default:
			firstInpDropResult = leftController;
			break;
		}
	}

	/**When a dropdown option is selected, firstOutDropResult is set to the corresponding value.
		The leftHand is the child if either the default or first option is chosen while
		the rightHand is the child if the second option is chosen. The leftFoot is the child
		if the third option is chosen. The rightFoot is the child if the fourth option 
		is chosen. **/
	void OnOutputDropdownSelectFirst(Dropdown drop) {
		switch (drop.value) {

		case 0: 
			firstOutDropResult = leftHand; 
			break;
		
		case 1: 
			firstOutDropResult = rightHand; 
			break;

		case 2:
			firstOutDropResult = leftFoot; 
			break;

		case 3:
			firstOutDropResult = rightFoot;
			break;

		default:
			firstOutDropResult = leftHand; 
			break; 
		}
	}

	/**When a dropdown option is selected, secondInpDropResult is set to the corresponding value.
		The rightController is the parent if either the default or first option is chosen while
		the leftController is the parent if the second option is chosen. **/
	void OnDropdown2Select(Dropdown drop){
		switch (drop.value) {
		case 0: 
			secondInpDropResult = rightController;
			break;

		case 1:
			secondInpDropResult = leftController;
			break;

			//Same as case 0
		default:
			secondInpDropResult = rightController;
			break;
		}
	}

	/**When a dropdown option is selected, secondOutDropResult is set to the corresponding value.
		The rightHand is the child if either the default or first option is chosen while
		the leftHand is the child if the second option is chosen. The leftFoot is the child 
		if the third option is chosen. The rightFoot is the child if the fourth option is 
		chosen. **/
	void OnOutputDropdown2Select(Dropdown drop) {
		switch (drop.value) {

		case 0: 
			secondOutDropResult = rightHand; 
			break;

		case 1: 
			secondOutDropResult = leftHand; 
			break;

		case 2:
			secondOutDropResult = leftFoot;
			break;

		case 3: 
			secondOutDropResult = rightFoot;
			break; 

		default:
			secondOutDropResult = rightHand; 
			break; 
		}
	}
}
