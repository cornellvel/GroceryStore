﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Remove :  MonoBehaviour {

	public void RemoveMe()
	{
		if (System.Int32.Parse (this.transform.Find ("Text").GetComponent<Text> ().text) > 1) 
		{
			int tcount = System.Int32.Parse (this.transform.Find ("Text").GetComponent<Text> ().text) - 1;
			this.transform.Find ("Text").GetComponent<Text> ().text = "" + tcount;
		} 
		else 
		{
			Destroy (this.gameObject);
		}

	}
}
