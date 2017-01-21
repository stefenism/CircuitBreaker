using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractObject : MonoBehaviour 
{

	/*
	20 Jan 2017
	Last Modified: 21 Jan 2017
	Stefan

	The base class for Interact Objects.
	As an abstract class, we can't add one of these to a GameObject, but we can add it's subclasses.

	Instance Variables

		public bool enabled;
			whether or not you can interact.

		
	*/

	[Header("Base Interact Object State")]
	public float 	mashValue;
	public bool 	mazeFinish;
	public float 	chargeAmount;
	[HideInInspector] public bool enabled;

	[HideInInspector] public PlayerController player;

	// Required Functions
	public abstract void StartInteract();
	public abstract void Completed();
	public abstract void Failed();
	public abstract void RunInteraction();

	// Use this for initialization
	void Start () {
		mazeFinish = false;
	} // Start

	// Update is called once per frame
	void Update () {
		if(enabled)
		{
			RunInteraction();
		} // if
	} // Update
	
	void StartMaze()
	{
		//spawn maze
		//if maze finished
		//canControl = true
		//mazing = false
	} // StartMaze

	public bool Enabled
	{
		get
		{
			return enabled;
		} // get
		set
		{
			enabled = value;
		} // set
	} // public bool Enabled

	public float ChargeAmount
	{
		get
		{
			return chargeAmount;
		} // get
	} // public float chargeAmount
} // InteractObject
