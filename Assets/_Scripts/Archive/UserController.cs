﻿using UnityEngine;
using System.Collections;
using System.Text;
using System.IO; 

public class UserController : MonoBehaviour {

	private Rigidbody rb; 
	private float speed = 10;
	public int inputNumber; 

	/***** CONSTANTS *****/
	public Vector3 origin { get { return new Vector3(0, 0.5f, 0); } } 


	void Start () {
		//set reference to Rigidbody component on the same GameObject
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		ClearCSV (); 
		//var controller = SteamVR_Controller.Input (inputNumber); 
	}

	//Called just before performing any Physics operations [will move by applying forces to Rigidbody]
	void FixedUpdate () {
		//record input from keypad 
		float horizontalMove = Input.GetAxis ("Horizontal");
		float verticalMove = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove); 

		rb.AddForce (movement * speed); 
		SaveCSV (); 
	}
		
	//Creates a new CSV file and saves the date, time, and current position of the ball on a new line 
	void SaveCSV () {
		StringBuilder csvcontent = new StringBuilder ();
		Vector3 currPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Quaternion currRot = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); 
		csvcontent.AppendLine (System.DateTime.Now.ToString() + "  Position: " + currPos.ToString() + "  Rotation: " + currRot.ToString()); 
		System.IO.File.AppendAllText ("CSVData.csv", csvcontent.ToString());

	}

	//If the space button is pressed, previous log of time, movement, and rotation is deleted. 
	void ClearCSV () { 
		if (Input.GetKeyDown(KeyCode.Space))  
			System.IO.File.WriteAllText ("CSVData.csv", string.Empty);
	}

	void OnTriggerEnter(Collider other)  {
		if (other.gameObject.CompareTag ("CollideObject")) {
			other.gameObject.SetActive (false); 
			System.IO.File.AppendAllText ("Events.csv", "Collided with object"); 
		}
	}

		
		
}
