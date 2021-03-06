using UnityEngine;
using System.Collections;

public class ScaleHeight : MonoBehaviour {

	public GameObject followedObject;
    public float holdHeight;

    // Use this for initialization
    void Start () {
		transform.parent = followedObject.transform;
        //get height of avatar set as variable
        holdHeight = followedObject.transform.position.y;
    }

	void followPosition() { 
		Vector3 _tmp = followedObject.transform.position;
        //at some point these should be a percentage of the avatar height
		_tmp.x = (followedObject.transform.position.x - .14f);
		_tmp.y = (followedObject.transform.position.y - .7f);
		_tmp.z = followedObject.transform.position.z;
		this.transform.position = _tmp; 
	}
    void followRotation()
    {
        //this doesn't seem to be working
        Vector3 _tmp2 = followedObject.transform.eulerAngles;
        _tmp2.x = 0;
        //if we want to be fancy we could have the body turn as a percentage of the head...later
        _tmp2.y = followedObject.transform.eulerAngles.y;
        _tmp2.z = 0;
        this.transform.eulerAngles = _tmp2;
        print(this.transform.eulerAngles);
    }
    // Update is called once per frame

    void Update()
    {
        followPosition();
        followRotation();
        if (Input.GetKeyDown("space"))
        {
            var a = holdHeight - 1.82f; //The height of the avatar is 1.82, which is 5.97 feet
            //Is this true?  Because I sized it up to 1.3
            var b = a / 1.82f;
            //don't know how to make c a float so that it can be input intpo the Scale transformation
            //should be like this:
            float c = 1.3f + (1.3f * b);
            //var c = 1.3f + (1.3f * b); 

            if (c > 0)
            {
                transform.localScale += new Vector3(0, c, 0); //or (c, c, c) if we want to scale all dimensions
                //Definitely scale all dimensions
            } else { transform.localScale -= new Vector3(0, c, 0); }
        }
            
    }
}
