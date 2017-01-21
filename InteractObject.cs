using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour 
{

	/*
	20 Jan 2017
	Last Modified: 21 Jan 2017
	Stefan

	Interacts with objects.

	Instance Variables

		public bool enabled;
			whether or not you can interact.

		
	*/

	[HideInInspector]
	public bool enabled;

	public float mashValue;
	public bool mazeFinish;

	public string objectType;

	public PlayerController player;
	// Use this for initialization
	void Start () {
		mazeFinish = false;
	} // Start

	// Update is called once per frame
	void Update () {

		if(enabled)
		{
			if(objectType == "mash")
			{
				StartMash();
			} // if

			if(objectType == "maze")
			{
				StartMaze();
			} // if
		} // if
	} // Update

	void StartMash()
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
} // InteractObject
