using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public bool isDie;		//죽음 체크
	public bool isJumped;	//점프 체크
	public bool isClimbed;	//사다리위 체크
	private float PlayerHP;
	private int Damage;


	// Use this for initialization
	void Start () {
		isDie = false;
		isJumped = false;
		isClimbed = false;
		PlayerHP = 10;
		Damage = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= -4.0f && !isDie ) {
			Camera.main.transform.position = new Vector3( 0.0f, 0.0f, Camera.main.transform.position.z );
			isDie = true;
		}

		if (isClimbed) {
			GetComponent<Rigidbody2D> ().gravityScale = 0;
		} else {
			Debug.Log( "HERE" );
			GetComponent<Rigidbody2D> ().gravityScale = 1;
		}

		if (GetComponent<PlayerItem> ().CurrentIntensity == 0)
		{
			PlayerHP -= Damage * Time.deltaTime;
		}
	}
}