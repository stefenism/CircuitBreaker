﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMash : InteractObject
{
	/*
	21 Jan 2017
	Last Modified: 21 Jan 2017
	Nicholas Pumper

	A subclass of InteractObject.
	Mash a button to complete the puzzle!

	Instance Variables
		public int numberOfMashesNeeded;
			The number of button mashes needed to complete the puzzle.

		public float timeInBetweenMashes;
			The amount of time to space in between mashes.
	*/

	[Header("Button Mash Instance Variables")]
	public int 		numberOfMashesNeeded;
	public float	timeInBetweenMashes;
	public float mashValue;
	public GameObject fillBar;

	// Required by InteractObject
	override public void ResetPuzzle()
	{
		mashValue = 0f;
	} // public void StartInteract()

	// Required by InteractObject
	override public void Completed()
	{
		enabled = false;
		player.canControl = true;
		player.smashing = false;
		StartCoroutine(ResetWait(3f));
		Destroy(this.gameObject);
	} // public void Completed()

	// Required by InteractObject
	override public void Failed()
	{

	} // public void Failed()

	override public void RunInteraction()
	{
		enabled = false;
		StartMash();
	} // public void RunInteraction()

	void Update()
	{
		StartMash();
	}
	private void StartMash()
	{
		mashValue -= 0.005f;

		if(mashValue < 0)
		{
			mashValue = 0;
		} // if

		if(mashValue >= 1)
		{
			Completed();
		} // if

		//player INput
		if(Input.GetButtonDown("Player" + player.playerNumber+ "Action") || Input.GetButtonDown("Player" + player.playerNumber + "Action2"))
		{
			mashValue += .1f;

		} // if
		fillBar.transform.localScale = new Vector3(1f, mashValue, 1f);
	} // StartMash

	private IEnumerator ResetWait(float seconds)
	{
		yield return new WaitForSeconds(seconds);

		ResetPuzzle();
	}
} //public class ButtonMash : InteractObject
