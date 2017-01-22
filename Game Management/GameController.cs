using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	/*
	21 Jan 2017
	Last Modifed: 21 Jan 2017
	Nick Pumper

	Runs the game!

	Instance Variables
		public float maxCharge;
			If this is reached by any Tesla Coil, they explode.
	*/

	[Header("Gameplay Variables")]
	public float maxCharge;
	[Header("Tesla Coils")]
	public TeslaCoil playerOneCoil;
	public TeslaCoil playerTwoCoil;

	//Private Instance Variables
	private bool isGameFinished = false;

	// Use this for initialization
	void Start () 
	{
		// Set up each of the Tesla Coils
		playerOneCoil.SetUpCoil(maxCharge, this);
		playerTwoCoil.SetUpCoil(maxCharge, this);
	} // void Start () 
	
	// Update is called once per frame
	void Update () 
	{
		

	} // Update();

	// A Coil calls this once it's overloaded (dead)
	public void CoilOverCharged (TeslaCoil coilThatDied)
	{
		if (isGameFinished == false)
		{
			int numberOfPlayerThatDied;

			// First stop the game.
			isGameFinished = true;

			//Find out which coil died.
			if (Object.ReferenceEquals(coilThatDied, playerOneCoil))
			{
				numberOfPlayerThatDied = 1;
			}  // if
			else 
			{
				numberOfPlayerThatDied = 2;
			} // else

			// Do things saying that the game is over!
			Debug.Log("[GameController] CoilOverCharged(): Coil of player " + numberOfPlayerThatDied + " has died! Game Over!");
		} // if
	}// public void CoilOverCharged ()

	public bool IsGameFinished
	{
		get
		{
			return isGameFinished;
		} // 
	} // public bool IsGameFinished()
} // public class GameController : MonoBehaviour 
