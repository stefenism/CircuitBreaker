using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator anim;

	public float speed;
	public float climbSpeed;

	[HideInInspector]
	public bool canControl;
	private bool facingRight;
	private float move;
	private float climb;
	private bool climbing;
	[HideInInspector]
	public bool mashing;

	public int playerNumber;
	public SpriteRenderer pressa;
	public InteractObject interactObject;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

		canControl = true;
		climbing = false;
		mashing = true;


	}

	// Update is called once per frame
	void Update () {

		if(canControl)
		{
			Run();

			if(climbing)
			{
				Climb();
			}

		}

		GroundCheck();

		if(mashing)
		{
			Mash();
		}

		//anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    //anim.SetFloat("vspeed", rb.velocity.y);

	}

	void Run()
	{


	    move = (Input.GetAxis("Player" + playerNumber + "Horizontal") + Input.GetAxis("Player" + playerNumber + "Horizontal2"));
	    rb.velocity = new Vector2(speed * move, rb.velocity.y);

			if(Mathf.Abs(rb.velocity.x) > speed)
			{
				rb.velocity = new Vector2((speed ), rb.velocity.y);

			}

	    if(move > 0 && !facingRight)
			{
				Flip();
			}

			else if(move < 0 && facingRight)
			{
				Flip();
			}
	}

	void Climb()
	{
		climb = (Input.GetAxis("Player" + playerNumber + "Vertical") + Input.GetAxis("Player" + playerNumber + "Vertical2"));
		rb.velocity = new Vector2(rb.velocity.x, climbSpeed * climb);

		if(Mathf.Abs(rb.velocity.y) > climbSpeed)
		{
			rb.velocity = new Vector2((speed), climbSpeed);
		}
	}

	void Mash()
	{
		if(Input.GetButtonDown("Player" + playerNumber+ "Action") || Input.GetButton("Player" + playerNumber + "Action2"))
		{
			interactObject.mashValue += .1f;
		}
	}

	void GroundCheck()
  {
		/*
    if(grounded)
    {
      canJump = true;
      jumping = false;
      airJump = true;
      airJumpCount = 0;
    }
		*/

  }

	void Flip()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "ladder")
		{
			climbing = true;
			if(climb > 0)
			{
				rb.gravityScale = 0;

			}
			//and pressing "up or down"
			//gravity = 0
			//velocity = up or down * climbspeed
		}

		if(collider.gameObject.tag == "button" || collider.gameObject.tag == "mash")
		{
			//and pressing button button (action button?)
			//assign collided gameobject to interact object
			//press switch I.E. set bool to switch being pressed

			pressa.GetComponent<Animator>().SetBool("on", true);//enabled = true;

			interactObject = collider.gameObject.GetComponent<InteractObject>();


			if(Input.GetButtonDown("Player" + playerNumber+ "Action") || Input.GetButton("Player" + playerNumber + "Action2"))
	    {
				interactObject.enabled = true;
				interactObject.player = this.gameObject.GetComponent<PlayerController>();
				canControl = false;
				mashing = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "ladder")
		{
			rb.gravityScale = 5;
			climbing = false;
		}

		if(collider.gameObject.tag == "button" || collider.gameObject.tag == "mash")
		{
				pressa.GetComponent<Animator>().SetBool("on", false);//pressa.enabled = false;

				interactObject.mashValue = 0;
				interactObject = null;
				//canControl = true;
		}
	}


}
