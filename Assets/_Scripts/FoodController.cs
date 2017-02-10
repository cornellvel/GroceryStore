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

    public FixedJoint joint;

    // Use this for initialization
    void Start () {

        //rightTrackedObject = GameObject.Find("[CameraRig]/Controller (right)").GetComponent<SteamVR_TrackedObject>();

        if (joint == null)
        {
            joint = gameObject.AddComponent<FixedJoint>();
        }

    }

    void OnCollisionStay(Collision collisionInfo)
    {

        rightTrackedObject = GameObject.FindWithTag("Right Controller").GetComponent<SteamVR_TrackedObject>();
        Debug.Log("coliision happening");
        rightDevice = SteamVR_Controller.Input((int)rightTrackedObject.index);

        if (collisionInfo.gameObject.tag == "Right Controller")
        {
            Debug.Log("right controller");
            if (rightDevice.GetPressDown(trigger))
            {
                Debug.Log("trigger press down");
                this.gameObject.transform.parent = rightTrackedObject.transform;
               // joint.connectedBody = collisionInfo.gameObject.GetComponent<Rigidbody>();
                Debug.Log(this.gameObject.name + " picked up");
            }
            if (rightDevice.GetPressUp(trigger))
            {
                Debug.Log("trigger press up");
                this.gameObject.transform.parent = null;
                //joint.connectedBody = null;
                Debug.Log("using gravity");
                Debug.Log("using kinematics");
                this.GetComponent<Rigidbody>().useGravity = true;
                this.GetComponent<Rigidbody>().isKinematic = false;
                Debug.Log(this.gameObject.name + " dropped off");
            }
        }
        else
        {
            if (this.GetComponent<Rigidbody>().useGravity)
            {
                Debug.Log("take away gravity");
                this.GetComponent<Rigidbody>().useGravity = false;
            }
            if (!this.GetComponent<Rigidbody>().isKinematic)
            {
                Debug.Log("take away kinematics");
                this.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    // Update is called once per frame
    void Update () {

    }
}