using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour {

	public bool canControl;
	private float horiz;
	private float verts;
	private Rigidbody2D rb;

	[HideInInspector]
	public Maze maze;
	[HideInInspector]
	public PlayerController player;
	[HideInInspector]
	public float speed;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

		if(rb.velocity.x != 0 || rb.velocity.y != 0)
		{
			canControl = false;
		}
		else
		{
			canControl = true;
		}

		if(canControl)
		{
			horiz = (Input.GetAxis("Player" + player.playerNumber + "Horizontal") + Input.GetAxis("Player" + player.playerNumber + "Horizontal2"));
			verts	= (Input.GetAxis("Player" + player.playerNumber + "Vertical") + Input.GetAxis("Player" + player.playerNumber + "Vertical2"));
		}


		if(horiz > 0f)
		{
			rb.velocity = new Vector2(speed, 0f);
		}
		else if(horiz < 0)
		{
			rb.velocity = new Vector2(-speed, 0f);
		}
		if(verts > 0f)
		{
			rb.velocity = new Vector2(0f, speed);
		}
		if(verts < 0f)
		{
			rb.velocity = new Vector2(0f, -speed);
		}

		Debug.Log("velocity " + rb.velocity);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "goal")
		{
			maze.Completed();
		}
	}

}
