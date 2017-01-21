using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : InteractObject 
{

	/*
	21 Jan 2017
	Last Modified: 21 Jan 2017
	Nicholas Pumper

	A subclass of InteractObject.
	Do a maze to complete the puzzle!

	Instance Variables
		public float speedOfMazePiece;
			How fast the maze piece moves.
	*/

	[Header("Maze Instance Variables")]
	public float speedOfMazePiece;

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


} // public class Maze : MonoBehaviour 