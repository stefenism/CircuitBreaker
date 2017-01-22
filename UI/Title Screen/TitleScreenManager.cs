using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour 
{
	/*
	22 Jan 2017
	Nicholas Pumper

	Manages the Title Screen.
	*/

	[Header("Screens")]
	public Screen introScreen;
	[Header("Controller Check")]
	public bool 		playerOneWorks = false;
	public bool 		playerTwoWorks = false;
	public GameObject 	playerOneCheckGraphic;
	public GameObject 	playerTwoCheckGraphic;
	[Header("Level Management")]
	public string nameOfNextLevel;

	void Start ()
	{
		playerOneCheckGraphic.SetActive(false);
		playerTwoCheckGraphic.SetActive(false);
	} // Start

	// Update is called once per frame
	void Update () {

		if (introScreen.HasFaded)
		{
			DetectControllers();

			if (DoControllersWork())
			{
				SceneManager.LoadScene (nameOfNextLevel);
			} // if
		}
	} //Update

	private void DetectControllers ()
	{
		// Check for player one.
		if (Input.GetButtonUp("Player1Action"))
		{
			playerOneCheckGraphic.SetActive(true);
			playerOneWorks = true;
		}
		if (Input.GetButtonUp("Player2Action"))
		{
			playerTwoCheckGraphic.SetActive(true);
			playerTwoWorks = true;
		}
	} // private void DetectControllers ()

	public bool DoControllersWork ()
	{
		if (playerOneWorks && playerTwoWorks)
		{
			return true;
		} else
		{
			return false;
		}
	}// public bool DoControllersWork()
} // public class TitleScreenManager : MonoBehaviour 