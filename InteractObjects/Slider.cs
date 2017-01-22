using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : InteractObject {

	/*
		21 Jan 2017
		Last Modified: 21 Jan 2017
		Stefen Menzel

		A subclass of InteractObject
		Hit the button when the slider reaches the correct point
		OR FAIL!

		Instance Variables
		public float slider speed
		public GameObject (slider)ball1
		public GameObject (slider)ball2

	*/

	[Header("Slider Variables")]
	public float speed;
	public SliderBall ball1;
	public SliderBall ball2;

	private GameObject clone;
	public GameObject slider;



	// Required by InteractObject
	override public void ResetPuzzle()
	{

	}

	//Required by InteractObject
	override public void Completed()
	{
		Debug.Log("succeeded");
	}

	//Required by InteractObject
	override public void Failed()
	{
		Debug.Log("failed");
	}

	//Required by InteractObject
	override public void RunInteraction()
	{
		enabled = false;
		this.gameObject.tag = "Untagged";
		StartSlider();
	}

	private void StartSlider()
	{

		clone = Instantiate(slider, player.mazeSpawnPoint.transform.position, Quaternion.identity) as GameObject;
		player.canControl = false;

		/*
		ball1.rb.velocity = new Vector2(0f, -speed + Random.Range(0f, 3f));
		ball2.rb.velocity = new Vector2(0f, speed + Random.Range(-3f, -1f));
		*/
		ball1.speed = -speed + Random.Range(0f, 2f);
		ball1.go = true;

		ball2.speed = speed + Random.Range(-2f, -1f);
		ball2.go = true;

		if(ball1.collided && ball2.collided)
		{
			if(Input.GetButtonDown("Player" + player.playerNumber+ "Action") || Input.GetButton("Player" + player.playerNumber + "Action2"))
			{
				Completed();
			} // if
		}

		else
		{
			if(Input.GetButtonDown("Player" + player.playerNumber+ "Action") || Input.GetButton("Player" + player.playerNumber + "Action2"))
			{
				//Failed();
			} // if
		}
	}
}
