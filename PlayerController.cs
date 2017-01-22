using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	/*

	Catches controls.
	Moves Player.
	Sets animations.
	*/

	public float speed;
	public float climbSpeed;

	[HideInInspector]
	public bool canControl;
	private bool facingRight;
	private float move;
	private float climb;
	private bool climbing;
	private bool canClimb;
	public bool smashing;


	public int playerNumber;
	public SpriteRenderer pressa;
	public GameObject mazeSpawnPoint;

	[HideInInspector]
	public InteractObject interactObject;
	private Rigidbody2D rb;
	private Animator anim;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

		canControl = true;
		climbing = false;
		canClimb = false;
		facingRight = true;
	} // Awake

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


		anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
		anim.SetBool("climbing", (climbing && canClimb));
		anim.SetBool("smashing", smashing);
    anim.SetFloat("vspeed", Mathf.Abs(rb.velocity.y));

	} // Update()

	void Run()
	{
	    move		= (Input.GetAxis("Player" + playerNumber + "Horizontal") + Input.GetAxis("Player" + playerNumber + "Horizontal2"));
	    rb.velocity = new Vector2(speed * move, rb.velocity.y);

		if(Mathf.Abs(rb.velocity.x) > speed)
		{
			rb.velocity = new Vector2((speed ), rb.velocity.y);

		} // if

	    if(move > 0 && !facingRight)
		{
			Flip();
		} // if

		else if(move < 0 && facingRight)
		{
			Flip();
		} //else if
	} // Run()

	void Climb()
	{
		climb = (Input.GetAxis("Player" + playerNumber + "Vertical") + Input.GetAxis("Player" + playerNumber + "Vertical2"));
		rb.velocity = new Vector2(rb.velocity.x, climbSpeed * climb);

		if(Mathf.Abs(rb.velocity.y) > climbSpeed)
		{
			rb.velocity = new Vector2((speed), climbSpeed);
		} // if
	} // void Climb()

	/*
	void Mash()
	{
		if(Input.GetButtonDown("Player" + playerNumber+ "Action") || Input.GetButton("Player" + playerNumber + "Action2"))
		{
			// interactObject.mashValue += .1f;
		} // if
	} // void Mash()
	*/

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
  	} // void GroundCheck()

	void Flip()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	} //  void Flip()

	void OnTriggerStay2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "ladder")
		{
			if(Mathf.Abs(rb.velocity.y) > 0f)
			{
				canClimb = true;
			}
			else
			{
				canClimb = false;
			}
			climbing = true;
			rb.gravityScale = 0;
			/*
			if(climb > 0)
			{
				rb.gravityScale = 0;

			} // if(climb > 0)*/
			//and pressing "up or down"
			//gravity = 0
			//velocity = up or down * climbspeed
		} // if(collider.gameObject.tag == "ladder")

		if(collider.gameObject.tag == "button" || collider.gameObject.tag == "mash")
		{
			//and pressing button button (action button?)
			//assign collided gameobject to interact object
			//press switch I.E. set bool to switch being pressed

			pressa.GetComponent<Animator>().SetBool("on", true);//enabled = true;

			// Catch controls
			/*
			if(Input.GetButtonDown("Player" + playerNumber+ "Action") || Input.GetButton("Player" + playerNumber + "Action2"))
	   		{
				interactObject.enabled = true;
				interactObject.player = this.gameObject.GetComponent<PlayerController>();
				canControl = false;
				mashing = true;
			} // if(Input.GetButtonDown("Player" + playerNumber+ "Action") || Input.GetButton("Player" + playerNumber + "Action2"))
			*/
		} // if(collider.gameObject.tag == "button" || collider.gameObject.tag == "mash")
	} // void OnTriggerStay2D(Collider2D collider)

	void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "ladder")
		{
			rb.gravityScale = 5;
			climbing = false;
		} // if(collider.gameObject.tag == "ladder")

		if(collider.gameObject.tag == "button" || collider.gameObject.tag == "mash")
		{
				pressa.GetComponent<Animator>().SetBool("on", false);//pressa.enabled = false;

				/*
				interactObject.mashValue = 0;
				interactObject = null;
				//canControl = true;
				*/
		} // if(collider.gameObject.tag == "button" || collider.gameObject.tag == "mash")
	} // void OnTriggerExit2D(Collider2D collider)

	public InteractObject InteractObject
	{
		get
		{
			return interactObject;
		}
		set
		{
			interactObject = value;
		}
	} // public InteractObject interactObject

	public bool CanControl
	{
		get
		{
			return canControl;
		}
		set
		{
			canControl = value;
		}
	} // public bool canControl
} // public class PlayerController : MonoBehaviour
