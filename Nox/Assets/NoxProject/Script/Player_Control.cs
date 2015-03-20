using UnityEngine;
using System.Collections;

public class Player_Control : MonoBehaviour {

	public int Player_Speed = 0;
	public int Player_JumpPower = 0;
	private Rigidbody2D rgBody = null;
	private bool isJumped = false;

	// Use this for initialization
	void Start ()
	{
		rgBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//float move =Input.GetAxisRaw("Horizontal");
		//rgBody.velocity = new Vector2(move * Player_Speed, rgBody.velocity.y );
		transform.FindChild ("match1").transform.position = new Vector3( transform.position.x, transform.position.y, 1.0f );
		transform.FindChild ("match2").transform.position = new Vector3( transform.position.x, transform.position.y, -1.0f );
		Moving ();
		Jump ();
	}

	void Moving()
	{
		if (Input.GetKey (KeyCode.D))
		{
			transform.Translate( Vector2.right * Player_Speed * Time.deltaTime );
			transform.eulerAngles = new Vector2( 0.0f, 0.0f );
		}
		if (Input.GetKey (KeyCode.A))
		{
			transform.Translate( Vector2.right * Player_Speed * Time.deltaTime );
			transform.eulerAngles = new Vector2( 0.0f, 180.0f );
		}
	}

	void Jump()
	{
		if (rgBody.velocity.y != 0)
		{
			isJumped = true;
		}

		if (isJumped && rgBody.velocity.y == 0)
		{
			isJumped = false;
		}

		if (Input.GetKeyDown (KeyCode.Space) && !isJumped)
		{
			rgBody.AddForce( new Vector2( 0.0f, Player_JumpPower ) );
			isJumped = true;
		}
	}
}