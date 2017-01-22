using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
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

	// references
	private Animator		anim;
	private GameController 	gameController; // A reference to the GameController.
	
	void Awake ()
	{
		anim = GetComponent<Animator>();
	} // void Start ()

	void Update ()
	{
		if (coilHasStarted && !isDead)
		{
			CheckIfDead();
			ManageAnimations();
		} // if
	} // void Update ()

	public void SetUpCoil(float maxChargeInput, GameController gameControllerInput)
	{
		maxCharge 		= maxChargeInput;
		gameController 	= gameControllerInput;

		coilHasStarted 	= true;
		anim.SetBool("IsDead", false);
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
			anim.SetBool("IsDead", true);
		} // if
	} // private void CheckIfDead()

	private void ManageAnimations()
	{
		// If we are in the range for a level one charge Animation
		if (currentCharge >= levelOneMinCharge /* && currentCharge < levelTwoMinCharge*/)
		{
			anim.SetBool("LevelOne", true);
		} // if

		// If we are in the range for a level two charge Animation
		if (currentCharge >= levelTwoMinCharge/* && currentCharge < levelThreeMinCharge*/)
		{
			anim.SetBool("LevelTwo", true);
		} // if

		// If we are in the range for a level three charge Animation
		if (currentCharge >= levelThreeMinCharge/* && currentCharge < levelFourMinCharge*/)
		{
			anim.SetBool("LevelThree", true);
		} // if

		// If we are in the range for a level four charge Animation
		if (currentCharge >= levelFourMinCharge/* && currentCharge < maxCharge*/)
		{
			anim.SetBool("LevelFour", true);
		} // if
	} // private void ManageAnimations()
} // public class TeslaCoil : MonoBehaviour 
