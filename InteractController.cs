﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour {

	/*
	21 Jan 2017
	Last Mod: 21 Jan
	Stefan Menzel

	Determines target InteractObject.
	Configures controls to InteractObject type.

	Instance Variables
		private PlayerController player;
			Reference to the PlayerController

		private InteractObject targetInteractObject;
	*/

	private PlayerController player;
	private InteractObject targetInteractObject;

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update () {

	}
	
	void SetPlayerInteractTarget (InteractObject input)
	{
		player.InteractObject = input;
	} // void SetPlayerInteractTarget ()

	void OnTriggerStay2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "button" || collider.gameObject.tag == "mash")
		{
			//and pressing button button (action button?)
			//assign collided gameobject to interact object
			//press switch I.E. set bool to switch being pressed

		player.interactObject = collider.gameObject.GetComponent(typeof(InteractObject)) as InteractObject;

		} // if(collider.gameObject.tag == "button" || collider.gameObject.tag == "mash")
	} // void OnTriggerStay2D(Collider2D collider)

	void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "button" || collider.gameObject.tag == "mash")
		{
			//interactObject.mashValue = 0;
			player.interactObject = null;
				//canControl = true;
		} // if(collider.gameObject.tag == "button" || collider.gameObject.tag == "mash")
	} // void OnTriggerExit2D(Collider2D collider)
}
