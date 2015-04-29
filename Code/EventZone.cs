using UnityEngine;
using System.Collections;

public class EventZone : MonoBehaviour {
	public AudioClip Scrim;
	public Sprite[] EventPhoto = new Sprite[2];
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
			transform.position = new Vector3( Camera.main.transform.position.x, 0.0f, -3.0f );
			//Camera.main.transform.position = new Vector3( 0.0f, 0.0f, Camera.main.transform.position.z );
		}

		if (isEventOn) {
			PlayTime -= 1 * Time.deltaTime;
		}

		if ( PlayTime < 0 ) {
			GameObject.Find( "Player(Clone)" ).GetComponent<PlayerState>().isMovable = true;
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
			GetComponent<SpriteRenderer>().sprite = EventPhoto[Random.Range( 0, 2 )];
			GameObject.Find( "Player(Clone)" ).GetComponent<PlayerState>().isMovable = false;
			isEventOn = true;
		}
	}
}