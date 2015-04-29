using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public bool isDied;	//죽음 체크
	public static bool isDamaged;	//피해받고 있는지 체크
	public bool isJumped;	//점프 체크
	public bool isClimbed;	//사다리위 체크
	public bool isMovable;
	public static float PlayerHP;
	private float Damage;

	// Use this for initialization
	void Start () {
		isDied = false;
		isJumped = false;
		isClimbed = false;
		isDamaged = false;
		isMovable = true;
		PlayerHP = 10;
		Damage = 0.6f;
	}
	
	// Update is called once per frame
	void Update () {

		Die ();

		if (isClimbed) {
			if( isJumped && Input.GetKeyDown( KeyCode.Space ) )
			{
				GetComponent<Rigidbody2D> ().gravityScale = 1;
				return;
			}
			GetComponent<Rigidbody2D> ().gravityScale = 0;
		} else {
			GetComponent<Rigidbody2D> ().gravityScale = 1;
		}

		if ( PlayerItem.CurrentIntensity == 0)
		{
			PlayerHP -= Damage * Time.deltaTime;

			if( !isDamaged )
			{
				GetComponent<AudioSource>().Play();
				GameObject.Find( "PlayBackGround(Clone)" ).GetComponent<AudioSource>().volume = 0.3f;
			}

			isDamaged = true;
		}
	}

	void Die()
	{
		if (transform.position.y <= -4.0f && !isDied) {
			isDied = true;
		} else if (PlayerHP <= 0.0f) {
			isDied = true;
		}

		if( isDied )
		{
			Camera.main.transform.position = new Vector3( 0.0f, 0.0f, Camera.main.transform.position.z );
		}
	}
}