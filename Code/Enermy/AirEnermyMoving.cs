using UnityEngine;
using System.Collections;

public class AirEnermyMoving : MonoBehaviour {
	public float EnermySpeed;
	public float MaxPos;
	public bool isCollied;
	private Vector3 DefaultPos;
	private int Up;
	
	// Use this for initialization
	void Start () {
		DefaultPos = transform.position;
		isCollied = false;
		MaxPos = 1.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (!isCollied)
		{
			transform.Translate (EnermySpeed * Time.deltaTime, 0.0f, 0.0f);
			
			if(  DefaultPos.x - MaxPos > transform.position.x )
			{
				transform.eulerAngles = new Vector2 (0.0f, 0.0f);
				transform.position = new Vector3 (transform.position.x, transform.position.y, 0.0f);
			} else if( DefaultPos.x + MaxPos  < transform.position.x )
			{
				
				transform.eulerAngles = new Vector2( 0.0f, 180.0f );;
				transform.position = new Vector3( transform.position.x, transform.position.y, 0.0f );
			}
			return;
		}

		if (transform.position.y - GameObject.Find ("Player(Clone)").transform.position.y > 0) {
			Up = -1;
		} else {
			Up = 1;
		}

		transform.Translate (EnermySpeed * Time.deltaTime, Up * EnermySpeed * Time.deltaTime, 0.0f);
		
		if (GameObject.Find ("Player(Clone)").transform.position.x > transform.position.x) {
			transform.eulerAngles = new Vector2 (0.0f, 0.0f);
			transform.position = new Vector3 (transform.position.x, transform.position.y, 0.0f);
		} else {
			transform.eulerAngles = new Vector2( 0.0f, 180.0f );;
			transform.position = new Vector3( transform.position.x, transform.position.y, 0.0f );
		}
	}
}
