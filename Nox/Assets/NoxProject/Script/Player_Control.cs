using UnityEngine;
using System.Collections;

public class Player_Control : MonoBehaviour {

	// 플레이어 상태
	private int STATE_IDLE = 0;
	private int STATE_JUMP = 1;
	private int STATE_MOVE = 2;

	public int Player_Speed = 0;		//플레이어 속도
	public int Player_JumpPower = 0;	//플레이어 점프력
	private bool isJumped = false;		//점프체크
	private Rigidbody2D rgBody = null;	
	private Animator ani = null;
	private BoxCollider2D bc2D = null;

	// Use this for initialization
	void Start ()
	{
		//리지드바디, 애니메이션 할당
		rgBody = GetComponent<Rigidbody2D> ();
		ani = GetComponent<Animator> ();
		bc2D = GetComponent<BoxCollider2D> ();
		//케릭터의 회전에 의해 조명이 같이 회전하여 2개를 설치함
		transform.FindChild ("match1").transform.position = new Vector3( transform.position.x, transform.position.y, 1.0f );
		transform.FindChild ("match2").transform.position = new Vector3( transform.position.x, transform.position.y, -1.0f );
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (!isJumped)
		{	//평상시
			Change_State( STATE_IDLE );
		}

		//Debug.Log ( rgBody.velocity.y );
		Moving ();	
	}

	void Update()
	{
		Jump ();
	}

	void Moving()
	{
		if (Input.GetKey (KeyCode.D))
		{
			transform.Translate( Vector2.right * Player_Speed * Time.deltaTime );
			transform.eulerAngles = new Vector2( 0.0f, 0.0f );
			transform.position = new Vector3( transform.position.x, transform.position.y, 0.0f );
			Change_State( STATE_MOVE );
		}
		if (Input.GetKey (KeyCode.A))
		{
			transform.Translate( Vector2.right * Player_Speed * Time.deltaTime );
			transform.eulerAngles = new Vector2( 0.0f, 180.0f );
			transform.position = new Vector3( transform.position.x, transform.position.y, 0.0f );
			Change_State( STATE_MOVE );
		}
	}

	void Jump()
	{
		if (rgBody.velocity.y != 0)
		{
			Change_State( STATE_JUMP );
			isJumped = true;
		}

		if (isJumped && rgBody.velocity.y == 0 )
		{
			isJumped = false;
		}

		if (Input.GetKeyDown (KeyCode.Space) && !isJumped)
		{
			rgBody.AddForce( transform.up * Player_JumpPower );
			isJumped = true;
		}
	}

	bool Change_State( int _State )
	{
		if (STATE_IDLE == _State) {
			ani.SetInteger ("State", STATE_IDLE);
		} else if (STATE_JUMP == _State) {
			ani.SetInteger( "State", STATE_JUMP );
		} else if( STATE_MOVE == _State ){
			if( isJumped )
			{
				return false;
			}
			ani.SetInteger( "State", STATE_MOVE );
		}

		return true;
	}
}