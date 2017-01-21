using System.Collections;
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

	// Required by InteractObject
	override public void StartInteract()
	{

	} // public void StartInteract()

	// Required by InteractObject
	override public void Completed()
	{

	} // public void Completed()

	// Required by InteractObject
	override public void Failed()
	{

	} // public void Failed()

	override public void RunInteraction()
	{

	} // public void RunInteraction()

	private void StartMash()
	{
		mashValue -= 0.05f;

		if(mashValue < 0)
		{
			mashValue = 0;
		} // if

		if(mashValue >= 1)
		{
			enabled = false;
			player.canControl = true;
			player.mashing = false;
		} // if
	} // StartMash
} //public class ButtonMash : InteractObject 
