using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour {

	public int Player_Speed = 0;
	public int Player_JumpPower = 0;
	private Rigidbody2D rgBody = null;

	// Use this for initialization
	void Start ()
	{
		rgBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.A))
		{
			transform.position += new Vector3(  )
		}
	}
}