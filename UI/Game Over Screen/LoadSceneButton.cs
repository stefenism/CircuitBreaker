using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour {

	/*
	22 Jan 2017
	Nicholas Pumper
	*/

	public string nameOfSceneToLoad;

	public void ButtonPress ()
	{
		SceneManager.LoadScene (nameOfSceneToLoad);
	}
}
