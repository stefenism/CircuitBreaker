using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{

	/*
	22 Jan 2017
	Nicholas Pumper

	Fades the GameObject it is attached to.
	*/

	public float timeUntilFade;
	
	// Update is called once per frame
	void Update () {
		if (timeUntilFade < Time.time)
		{
			this.gameObject.SetActive(false);
		} // if
	} //void Update () {
} // public class Fade : MonoBehaviour