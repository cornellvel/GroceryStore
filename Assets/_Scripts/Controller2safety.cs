using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using Valve.VR;

public class Controller2safety : MonoBehaviour
{

    private SteamVR_TrackedObject rightTrackedObject;
    private SteamVR_Controller.Device rightDevice;
    private EVRButtonId trigger = EVRButtonId.k_EButton_SteamVR_Trigger;

    // Use this for initialization
    void Start () {
        rightTrackedObject = GameObject.Find("[CameraRig]/Controller (right)").GetComponent<SteamVR_TrackedObject>();
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        Debug.Log("coliision happening");
        if (rightDevice.GetPressDown(trigger)) 
            {
            Debug.Log("trigger happening");
            if (collisionInfo.gameObject.tag == "food")
            {
                collisionInfo.gameObject.transform.parent = rightTrackedObject.transform;
                Debug.Log("food happening");
             }
        }
    }

    // Update is called once per frame
    void Update () {

        rightDevice = SteamVR_Controller.Input((int)rightTrackedObject.index);
        //if (rightDevice.GetPressDown(trigger)) //
        //{
        //        if OnCollisionEnter(Collision other) 
        //        Debug.Log("colliding happening");
        //        rightDevice = SteamVR_Controller.Input((int)rightTrackedObject.index);
        //        if (other.gameObject.tag == "food")
        //        {
        //            other.transform.parent = rightTrackedObject.transform;
        //            Debug.Log("food happening");
        //        }
        //    }
        //    Debug.Log("trigger is pressed");
        //}
	}
}





           