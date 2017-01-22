using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

	/*
	22 Jan 2017
	Nicholas Pumper

	Makes a Game Over Screen.
	*/

	public GameObject   gameOverScreen;
	public Text			gameOverText;

	void Start ()
	{
		gameOverScreen.SetActive(false);
	}

	public void StartGameOver (int numberOfPlayerWhoWon)
	{
		gameOverScreen.SetActive(true);

		if (numberOfPlayerWhoWon == 1)
		{
			gameOverText.text = "Edison Won!";
		} 
		else 
		{
			gameOverText.text = "Tesla Won!";
		} // else
		
	} // public void StartGameOver () 
} // class
