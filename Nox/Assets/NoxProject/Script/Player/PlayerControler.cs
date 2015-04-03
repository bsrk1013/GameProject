using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

	// 플레이어 상태
	private int STATE_IDLE = 0;
	private int STATE_JUMP = 1;
	private int STATE_MOVE = 2;
	public float Player_Speed = 0;		//플레이어 속도
	public int Player_JumpPower = 0;	//플레이어 점프력
	private Rigidbody2D rgBody = null;	
	private Animator ani = null;
	private float maxY;

	// Use this for initialization
	void Start ()
	{
		//리지드바디, 애니메이션 할당
		rgBody = GetComponent<Rigidbody2D> ();
		ani = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (GetComponent<PlayerState> ().isDie) {
			return;
		}

		if (!GetComponent<PlayerState>().isJumped)
		{	//평상시
			Change_State( STATE_IDLE );
		}

		Moving ();
		MoveCamera ();
	}

	void Update()
	{
		Jump ();
	}

	void MoveCamera()
	{  
		if (transform.position.x - 5.12f > -5.12f && transform.position.x + 5.12f < GameObject.Find ("GameManager").GetComponent<TileManager> ().MaxWidth)
			Camera.main.transform.position = new Vector3 (transform.position.x, 0.0f, Camera.main.transform.position.z);
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
			if( transform.eulerAngles.y != 180.0f )
			{
				//계속적인 회전을 막기위해
				transform.eulerAngles = new Vector3( 0.0f, 180.0f, 0.0f );
			}
			transform.position = new Vector3( transform.position.x, transform.position.y, 0.0f );
			Change_State( STATE_MOVE );
		}
		if (Input.GetKey (KeyCode.W) && GetComponent<PlayerState> ().isClimbed )
		{
			transform.Translate( Vector2.up * Player_Speed * Time.deltaTime );
			rgBody.velocity = new Vector2( 0.0f, 0.0f );
		}
		if (Input.GetKey (KeyCode.S) && GetComponent<PlayerState> ().isClimbed )
		{
			transform.Translate( -Vector2.up * Player_Speed * Time.deltaTime );
			rgBody.velocity = new Vector2( 0.0f, 0.0f );
		}
	}

	void Jump()
	{
		if (  Input.GetKey( KeyCode.Space ) && GetComponent<PlayerState> ().isClimbed)
		{
			transform.Translate( Vector2.up * Player_Speed * Time.deltaTime );
			return;
		}

		if (!Input.GetKey( KeyCode.Space ) && rgBody.velocity.y != 0)
		{
			Change_State( STATE_JUMP );
			GetComponent<PlayerState>().isJumped = true;
		}

		if (GetComponent<PlayerState>().isJumped && rgBody.velocity.y == 0 )
		{
			GetComponent<PlayerState>().isJumped = false;
		}

		if (Input.GetKeyDown (KeyCode.Space) && !GetComponent<PlayerState>().isJumped)
		{
			Change_State( STATE_JUMP );
			rgBody.AddForce( transform.up * Player_JumpPower );
			GetComponent<PlayerState>().isJumped = true;
		}
	}

	bool Change_State( int _State )
	{
		if (STATE_IDLE == _State) {
			ani.SetInteger ("State", STATE_IDLE);
		} else if (STATE_JUMP == _State) {
			ani.SetInteger( "State", STATE_JUMP );
		} else if( STATE_MOVE == _State ){
			if( GetComponent<PlayerState>().isJumped )
			{
				return false;
			}
			ani.SetInteger( "State", STATE_MOVE );
		}

		return true;
	}
}