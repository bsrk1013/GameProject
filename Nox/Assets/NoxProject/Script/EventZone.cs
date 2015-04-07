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
			transform.position = new Vector3( 0.0f, 0.0f, -3.0f );
			Camera.main.transform.position = new Vector3( 0.0f, 0.0f, Camera.main.transform.position.z );
		}

		if (isEventOn) {
			PlayTime -= 1 * Time.deltaTime;
		}

		if ( PlayTime < 0 ) {
			GameObject.Find( "Player(Clone)" ).GetComponent<PlayerState>().isMovable = true;
			Camera.main.transform.position = new Vector3( GameObject.Find( "Player(Clone)" ).transform.position.x - 2.60f, 0, Camera.main.transform.position.z );
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