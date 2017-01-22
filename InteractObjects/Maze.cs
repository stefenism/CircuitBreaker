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

	private GameObject clone;
	private GameObject runner;
	private bool mazing = false;

	public GameObject[] mazes;
	public GameObject mazeRunner;
	public GameObject[] spawnPoint;



	// Required by InteractObject
	override public void ResetPuzzle()
	{

	} // public void StartInteract()

	// Required by InteractObject
	override public void Completed()
	{
		Debug.Log("BLAAARRGGHGHGHGH!");
		Destroy(clone);
		Destroy(runner);
		this.gameObject.tag = "mash";
		player.canControl = true;
		player.smashing = false;
	} // public void Completed()

	// Required by InteractObject
	override public void Failed()
	{

	} // public void Failed()

	override public void RunInteraction()
	{

		enabled = false;
		this.gameObject.tag = "Untagged";
		StartMaze();
	} // public void RunInteraction()

	private void StartMaze()
	{

		//instantiate maze puzzle
		//instantiate maze runner at puzzle spawnpoint
		//take over player canControl
		//set player mazing to true
		clone = Instantiate(mazes[Random.Range(0, mazes.Length)], spawnPoint[player.playerNumber - 1].transform.position, Quaternion.identity) as GameObject;
		SpawnMazeRunner(clone);
		player.canControl = false;
		runner.GetComponent<RunnerController>().canControl = true;
		runner.GetComponent<RunnerController>().maze = GetComponent<Maze>();
		runner.GetComponent<RunnerController>().player = player;
		runner.GetComponent<RunnerController>().speed = speedOfMazePiece;
		//mazing = true;

	}//private void StartMaze()

	private void SpawnMazeRunner(GameObject spawnpoint)
	{


		runner = Instantiate(mazeRunner, spawnpoint.transform.GetChild(1).transform.position, Quaternion.identity) as GameObject;

	}


} // public class Maze : MonoBehaviour
