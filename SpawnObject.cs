using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

	/*
		22 Jan 2017
		Last Modified: 22 Jan 2017
		Stefen Menzel

		A class that spawns a miniGames

		Instance Variables
			public GameObject[] miniGames
				an array of all the minigames available
			private GameObject clone;
				a placeholder for instantiated miniGames

			public GameObject type
				type of minigame to spawn

				public PlayerController player
					reference to the player



	*/

	public GameObject[] miniGames;
	public GameObject clone;
	public GameObject type;
	public PlayerController player;
	public GameObject[] spawnPoint;

	// Use this for initialization
	void Start () {
		spawnPoint[0] = GameObject.Find("SpawnPoint1");
		spawnPoint[1] = GameObject.Find("SpawnPoint2");
	}

	// Update is called once per frame
	void Update () {

	}

	public void Spawn()
	{
		InteractObject interactObject;

		clone = Instantiate(type, spawnPoint[player.playerNumber - 1].transform.position, Quaternion.identity) as GameObject;

		if(clone.tag == "maze")
		{
			clone.transform.position = new Vector3(0f,0f,0f);
		}

		interactObject = clone.GetComponent(typeof(InteractObject)) as InteractObject;

		interactObject.player = player;
		//player.interactObject = interactObject;
		interactObject.StartInteract();
	}

}
