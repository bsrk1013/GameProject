using UnityEngine;
using System.Collections;

public class EnermyMoving : MonoBehaviour {

	public float EnermySpeed;
	private bool PlayerCollision;

	// Use this for initialization
	void Start () {
		PlayerCollision = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (PlayerCollision)
		{
			return;
		}

		if (GameObject.Find ("Player").transform.position.x > transform.position.x) {
			transform.eulerAngles = new Vector2 (0.0f, 0.0f);
			transform.position = new Vector3 (transform.position.x, transform.position.y, 0.0f);
		} else {
			transform.eulerAngles = new Vector2( 0.0f, 180.0f );;
			transform.position = new Vector3( transform.position.x, transform.position.y, 0.0f );
		}

		transform.Translate( EnermySpeed * Time.deltaTime, 0.0f, 0.0f );
	}

	void OnTriggerEnter2D ( Collider2D _Other )
	{
		Debug.Log( _Other.tag );
		if (_Other.tag == "Player")
		{
			PlayerCollision = true;
		}
	}

	void OnTriggerExit2D ( Collider2D _Other )
	{
		if (_Other.tag == "Player")
		{
			PlayerCollision = false;
		}
	}
}