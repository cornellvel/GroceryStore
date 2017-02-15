using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using Valve.VR;

public class FoodController : MonoBehaviour {

    private SteamVR_TrackedObject rightTrackedObject;
    private SteamVR_Controller.Device rightDevice;
    private EVRButtonId trigger = EVRButtonId.k_EButton_SteamVR_Trigger;

    public bool InCart = false;
    public double Price;

    // value to track if the trigger was pressed; initialized to zero
    int pressed = 0;

    // Use this for initialization
    void Start () {

        //rightTrackedObject = GameObject.Find("[CameraRig]/Controller (right)").GetComponent<SteamVR_TrackedObject>();

    }

    void OnCollisionStay(Collision collisionInfo)
    {

        rightTrackedObject = GameObject.FindWithTag("Right Controller").GetComponent<SteamVR_TrackedObject>();
        //Debug.Log("coliision happening");
        rightDevice = SteamVR_Controller.Input((int)rightTrackedObject.index);

        if (collisionInfo.gameObject.tag == "Right Controller")
        {
            //Debug.Log("right controller");
            if (rightDevice.GetPressDown(trigger))
            {
                //Debug.Log("trigger press down");
                this.gameObject.transform.parent = rightTrackedObject.transform;

                // indicated that the trigger was pressed down
                pressed = 1;

                Debug.Log(this.gameObject.name + " picked up ON COLLISION STAY");
            }
            if (rightDevice.GetPressUp(trigger))
            {

                // indicates that at some point during the collision, the trigger was released
                pressed = 2;

                //Debug.Log("trigger press up");

                this.gameObject.transform.parent = null;

                Debug.Log("using gravity and kinematics with "+ this.gameObject.name+" ON COLLISION STAY");
                this.GetComponent<Rigidbody>().useGravity = true;
                this.GetComponent<Rigidbody>().isKinematic = false;
                Debug.Log(this.gameObject.name + " dropped off ON COLLISION STAY");
            }
        }
        else
        {
            if (this.GetComponent<Rigidbody>().useGravity)
            {
                Debug.Log("take away gravity from "+this.gameObject.name);
                this.GetComponent<Rigidbody>().useGravity = false;
            }
            if (!this.GetComponent<Rigidbody>().isKinematic)
            {
                Debug.Log("take away kinematics from " + this.gameObject.name);
                this.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        rightTrackedObject = GameObject.FindWithTag("Right Controller").GetComponent<SteamVR_TrackedObject>();
        rightDevice = SteamVR_Controller.Input((int)rightTrackedObject.index);

        // if (pressed == 2 || this.gameObject.transform.parent != null)
        if (pressed == 2 || rightDevice.GetPressUp(trigger))
        {
            //Debug.Log("No longer in contact with " + this.gameObject.name);
            this.gameObject.transform.parent = null;
            Debug.Log("using gravity and kinematics with " + this.gameObject.name+" ON COLLISION EXIT");
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log(this.gameObject.name + " dropped off ON COLLISION EXIT");
        }
    }

    // Update is called once per frame
    void Update () {

    }
}