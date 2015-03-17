using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour {

	public int Player_Speed = 0;
	public int Player_JumpPower = 0;
	private Rigidbody2D rgBody = null;
	private bool isGround = true;

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
		if (Input.GetKeyDown (KeyCode.Space) && isGround)
		{
			rgBody.AddForce( new Vector2( 0.0f, Player_JumpPower ) );
		}
	}
}