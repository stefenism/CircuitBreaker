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
	public float currentCharge;
	[Header("Animation Parameters")]
	public float levelOneMinCharge;
	public float levelTwoMinCharge;
	public float levelThreeMinCharge;
	public float levelFourMinCharge;

	// Private Instance Variables
	private bool 	isDead			= false;
	private bool 	coilHasStarted = false;
	private float 	maxCharge; // Set by GameController in SetUpCoil()
	
	private GameController gameController; // A reference to the GameController.
	
	void Update ()
	{
		if (coilHasStarted && !isDead)
		{
			CheckIfDead();
		} // if
	} // void Update ()

	public void SetUpCoil(float maxChargeInput, GameController gameControllerInput)
	{
		maxCharge 		= maxChargeInput;
		gameController 	= gameControllerInput;

		coilHasStarted 	= true;
	} // public void StartCoil()

	public void AddCharge (float amount)
	{
		currentCharge = currentCharge + amount;
	} // public void AddCharge (float amount)

	private void CheckIfDead()
	{
		if (currentCharge >= maxCharge)
		{
			// Tell the game this coil is dead.
			gameController.CoilOverCharged(this);

			// Tell this coil that it is dead.
			isDead = true;
		} // if
	} // private void CheckIfDead()
} // public class TeslaCoil : MonoBehaviour 
