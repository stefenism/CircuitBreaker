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
	*/

	[HideInInspector]
	public bool enabled;

	public float mashValue;
	public string objectType;

	public PlayerController player;
	
	// Use this for initialization
	void Start () {
 
	} // Start

	// Update is called once per frame
	void Update () {

		if(enabled)
		{
			if(objectType == "mash")
			{
				StartMash();
			} // if
		}
	} // Update ()

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
	} // StartMash()

	public bool Enabled
	{
		get
		{
			return enabled;
		} // get
	} // public bool Enabled

	public string ObjectType
	{
		get
		{
			return objectType;
		} // get
	} // public string ObjectType

} // public class InteractObject : MonoBehaviour
