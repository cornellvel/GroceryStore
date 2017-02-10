using UnityEngine;
using System.Collections;

public class RH_Orientation_Debug : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Head position: " + transform.position);
        Debug.Log("Right hand orientation: " + transform.localEulerAngles);
    }
}
