using UnityEngine;
using System.Collections;

public class EventZone : MonoBehaviour {
	public AudioClip Scrim;
	public Sprite EventPhoto;
	private float PlayTime;
	private int MinusTime;
	private bool isEventOn;

	void Start()
	{
		PlayTime = 2.0f;
		MinusTime = 1;
		isEventOn = false;
	}

	void FixedUpdate()
	{
		if (!GetComponent<AudioSource> ().loop) {
			/*
			if( GameObject.Find( "Player(Clone)" ).transform.position.x - 5.12f < -5.12f )
			{
				transform.position = new Vector3( 0.0f, 0.0f, -3.0f);
			}else if( GameObject.Find( "Player(Clone)" ).transform.position.x + 5.12f > GameObject.Find ( "GameManager" ).GetComponent<TileManager>().MaxWidth )
			{
				transform.position = new Vector3( 0.0f, 0.0f, -3.0f);
			}else
			{
				transform.position = new Vector3( GameObject.Find( "Player(Clone)" ).transform.position.x, 0.0f, -3.0f);
			}
			*/
			transform.position = new Vector3( 0.0f, 0.0f, -3.0f );
			Camera.main.transform.position = new Vector3( 0.0f, 0.0f, Camera.main.transform.position.z );
		}

		if (isEventOn) {
			PlayTime -= 1 * Time.deltaTime;
		}

		if ( PlayTime < 0 ) {
			GameObject.Find( "Player(Clone)" ).GetComponent<PlayerState>().isMovable = true;
			GameObject.Find( "Player(Clone)" ).GetComponent<PlayerControler>().MoveCamera();
			Destroy( this.gameObject );
		}
	}

	void OnTriggerEnter2D( Collider2D _Other )
	{
		if (_Other.tag == "Player" && !isEventOn)
		{
			GetComponent<AudioSource>().clip = Scrim;
			GetComponent<AudioSource>().loop = false;
			GetComponent<AudioSource>().Play();
			GetComponent<SpriteRenderer>().sprite = EventPhoto;
			GameObject.Find( "Player(Clone)" ).GetComponent<PlayerState>().isMovable = false;
			isEventOn = true;
		}
	}
}