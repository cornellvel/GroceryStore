﻿using UnityEngine;
using System.Collections;

public class LH_Gain : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject headset;
    //the coordinates (x, y, z) in output, z appears to be the variable that would be affected by mirroring in our world. 
    //when the participant is facing the balloons, with both hands at her side, RHz < Headz < LHz
    //So, when RHz > Headz, that means that the right hand has crossed the midline and the left hand will have to cross the midline the other way.

    void Update()
    {
        //if RHz < Headz
        if (rightHand.transform.position.z < headset.transform.position.z)
        {
            //set a temporary variable because you can't set one GameObject's position to the position of another GameObject 
            Vector3 _tmp = leftHand.transform.position;
            //LH(x)=RH(x)
            _tmp.x = rightHand.transform.position.x;
            //LH(y)=RH(y)
            _tmp.y = rightHand.transform.position.y;
            //LH(z)=((absolute value(Headz-RHz))+Headz)
            _tmp.z = Mathf.Abs(headset.transform.position.z - rightHand.transform.position.z) + headset.transform.position.z;
            leftHand.transform.position = _tmp;
          
            //if RHz > Headz
            if (rightHand.transform.position.z > headset.transform.position.z)
            {
                //LH(x)=RH(x)
                _tmp.x = rightHand.transform.position.x;
                //LH(y)=RH(y)
                _tmp.y = rightHand.transform.position.y;
                //LH(z)=(Headz-(absolute value(RHz-Headz)))
                _tmp.z = Mathf.Abs(rightHand.transform.position.z - headset.transform.position.z);
                leftHand.transform.position = _tmp; 
            }


        }
    }
}