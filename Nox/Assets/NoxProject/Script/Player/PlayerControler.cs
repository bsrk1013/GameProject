using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

	// 플레이어 상태
	enum STATE
	{
		IDLE,
		JUMP,
		MOVE,
		CLIMBUP,
		CLIMBDOWN,
	};

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
		if (GetComponent<PlayerState> ().isDied || !GetComponent<PlayerState> ().isMovable) {
			return;
		}

		if (!GetComponent<PlayerState>().isJumped)
		{	//평상시
			Change_State( STATE.IDLE );
		}

		Moving ();
		MoveCamera ();
	}

	void Update()
	{
		Jump ();
	}

	public void MoveCamera()
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
			Change_State( STATE.MOVE );
		}
		else if (Input.GetKey (KeyCode.A))
		{
			transform.Translate( Vector2.right * Player_Speed * Time.deltaTime );
			if( transform.eulerAngles.y != 180.0f )
			{
				//계속적인 회전을 막기위해
				transform.eulerAngles = new Vector3( 0.0f, 180.0f, 0.0f );
			}
			transform.position = new Vector3( transform.position.x, transform.position.y, 0.0f );
			Change_State( STATE.MOVE );
		}
		if (Input.GetKey (KeyCode.W) && GetComponent<PlayerState> ().isClimbed )
		{
			rgBody.gravityScale = 0;
			transform.Translate( Vector2.up * Player_Speed * Time.deltaTime );
			rgBody.velocity = new Vector2( 0.0f, 0.0f );
			Change_State( STATE.CLIMBUP );
		}
		else if (Input.GetKey (KeyCode.S) && GetComponent<PlayerState> ().isClimbed )
		{
			rgBody.gravityScale = 0;
			transform.Translate( -Vector2.up * Player_Speed * Time.deltaTime );
			rgBody.velocity = new Vector2( 0.0f, 0.0f );
			Change_State( STATE.CLIMBDOWN );
		}
	}

	void Jump()
	{
		/*
		if (  Input.GetKey( KeyCode.Space ) && GetComponent<PlayerState> ().isClimbed)
		{
			transform.Translate( Vector2.up * Player_Speed * Time.deltaTime );
			return;
		}
		*/
		if (Input.GetKeyDown (KeyCode.Space) && GetComponent<PlayerState> ().isClimbed && Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.Space) && GetComponent<PlayerState> ().isClimbed && Input.GetKeyDown (KeyCode.D) )
		{
			Change_State( STATE.JUMP );
			rgBody.AddForce( transform.up * Player_JumpPower );
			GetComponent<PlayerState>().isJumped = true;
			return;
		}

		if (!Input.GetKey( KeyCode.Space ) && rgBody.velocity.y != 0)
		{
			Change_State( STATE.JUMP );
			GetComponent<PlayerState>().isJumped = true;
		}

		if (GetComponent<PlayerState>().isJumped && rgBody.velocity.y == 0 )
		{
			GetComponent<PlayerState>().isJumped = false;
		}

		if (Input.GetKeyDown (KeyCode.Space) && !GetComponent<PlayerState>().isJumped)
		{
			Change_State( STATE.JUMP );
			rgBody.AddForce( transform.up * Player_JumpPower );
			GetComponent<PlayerState>().isJumped = true;
		}
	}

	bool Change_State( STATE _State )
	{
		if (STATE.IDLE == _State) {
			ani.SetInteger ("State", (int)STATE.IDLE);
		} else if (STATE.JUMP == _State) {
			if (GetComponent<PlayerState> ().isClimbed) {
				return false;
			}
			ani.SetInteger ("State", (int)STATE.JUMP);
		} else if (STATE.MOVE == _State) {
			if (GetComponent<PlayerState> ().isJumped) {
				return false;
			}
			ani.SetInteger ("State", (int)STATE.MOVE);
		} else if (STATE.CLIMBUP == _State) {
			ani.SetInteger ("State", (int)STATE.CLIMBUP);
		} else if (STATE.CLIMBDOWN == _State) {
			ani.SetInteger ("State", (int)STATE.CLIMBDOWN);
		}

		return true;
	}
}