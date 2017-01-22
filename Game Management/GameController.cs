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
			If the 
	*/

	[Header("Gameplay Variables")]
	public float maxCharge;
	[Header("Tesla Coils")]
	public TeslaCoil playerOneCoil;
	public TeslaCoil playerTwoCoil;

	//Private Instance Variables
	// Gameplay
	private bool isGameFinished = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	} // Update();

	// A Coil calls this once it's overloaded (dead)
	public void CoilOverCharged ()
	{
		if (isGameFinished == false)
		{
			isGameFinished = true;
		} // if
	}// public void CoilOverCharged ()

	public bool IsGameFinished()
	{
		get
		{
			return isGameFinished;
		} // 
	} // public bool IsGameFinished()
} // public class GameController : MonoBehaviour 
