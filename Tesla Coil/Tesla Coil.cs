using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaCoil : MonoBehaviour 
{
	/*
	21 Jan 2017
	Last Mod: 21 Jan 2017
	Nicholas Pumper

	WOrks a Tesla Coil, which is constantly managed by GameController.
	*/

	[Header("Game Instance Variables")]
	public float 	currentCharge;
	[Header("Animation Parameters")]
	public float levelOneMinCharge;
	public float levelTwoMinCharge;
	public float levelThreeMinCharge;
	public float levelFourMinCharge;

	// Private Instance Variables
	private bool isDead			= false;
	private bool coilHasStarted = false;

	void Update ()
	{
		if (coilHasStarted && !isDead)
		{
			CheckIfDead();
		} // if
	} // void Update ()

	public void StartCoil()
	{

	} // public void StartCoil()

	private void CheckIfDead()
	{
		
	} // private void CheckIfDead()
} // public class TeslaCoil : MonoBehaviour 
