using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour 
{
	/*
	22 Jan 2017
	Nicholas Pumper

	Blinks the thingToBlink.
	*/

	public GameObject 	thingToBlink;
	public float 		timeInBetweenBlinks;
	
	public float nextBlink;

	// Update is called once per frame
	void Update () {
		if (nextBlink < Time.time)
		{
			// If this is showing, make it not show.
			if (thingToBlink.gameObject.activeSelf)
			{
				thingToBlink.gameObject.SetActive(false);
			} // if
			else
			{
				thingToBlink.gameObject.SetActive(true);
			} // else

			// Allow for the next blink.
			nextBlink = Time.time + timeInBetweenBlinks;
		} //if
	} // Update()
} // class
