using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderBall : MonoBehaviour {

	public bool collided;
	public Rigidbody2D rb;
	public float speed = 1;
	public bool go;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(go)
		{
			MoveBalls();
		}
	}

	void MoveBalls()
	{
		rb.velocity = new Vector2(0f, speed);

		if(Mathf.Abs(rb.velocity.y) > speed)
		{
			rb.velocity = new Vector2(0f, speed);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "slider1")
		{
			collided = true;
		}

		if(collision.gameObject.tag == "rebound")
		{
			speed *= -1;
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		collided = false;
	}
}
