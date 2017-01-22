using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{

	/*
	22 Jan 2017
	Nicholas Pumper

	A Screen for the TitleScreenManager
	*/

	public float timeUntilFade;

	private bool hasFaded = false;

	void Update ()
	{
		if (timeUntilFade < Time.time)
		{
			this.gameObject.SetActive(false);
			hasFaded = true;
		}
	} // Update

	public bool HasFaded 
	{
		get
		{
			return hasFaded;
		}	
	}

} // public class Screen : MonoBehaviour
