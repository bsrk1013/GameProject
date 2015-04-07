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
		PlayTime = 3.0f;
		MinusTime = 1;
		isEventOn = false;
	}

	void FixedUpdate()
	{
		if (!GetComponent<AudioSource> ().loop) {
			if( GameObject.Find( "Player(Clone)" ).transform.position.x - 5.12f < -5.12f )
			{
				transform.position = new Vector3( 0.0f, 0.0f, -3.0f);
			}else
			{
				transform.position = new Vector3( GameObject.Find( "Player(Clone)" ).transform.position.x, 0.0f, -3.0f);
			}
		}

		if (!GetComponent<AudioSource> ().isPlaying) {
			GameObject.Find( "Player(Clone)" ).GetComponent<PlayerState>().isMovable = true;
			Destroy( this.gameObject );
		}
	}

	void OnTriggerEnter2D( Collider2D _Other )
	{
		if (_Other.tag == "Player" && !isEventOn)
		{
			Debug.Log("HERE");
			GetComponent<AudioSource>().clip = Scrim;
			GetComponent<AudioSource>().loop = false;
			GetComponent<AudioSource>().Play();
			GetComponent<SpriteRenderer>().sprite = EventPhoto;
			GameObject.Find( "Player(Clone)" ).GetComponent<PlayerState>().isMovable = false;
			isEventOn = true;
		}
	}
}