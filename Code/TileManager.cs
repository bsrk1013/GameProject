using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {

	enum OBJECTNUMBER
	{
		EMPTY,
		PLAYER,
		TILE,
		WALL,
		RAT,
		MATCHITEM,
		DOOR1,
		DOOR2,
		DOOR3,
		BACKDOOR1,
		BACKDOOR2,
		BACKDOOR3,
		LADDER,
		LADDERTOP,
		EVENTZONE,
		ENDED,
		BATMAN,
		SWARM,
		COUNT,
	};

	public List<GameObject> ObjectList;
	public GameObject[] ObjectArray = new GameObject[ (int)OBJECTNUMBER.COUNT ] ;
	public float MaxWidth;
	public bool isLantern;

	// Use this for initialization
	void Start () {
		isLantern = false;
		ObjectList = new List<GameObject>();
	}

	public void DeleteStage()
	{
		Camera.main.transform.position = new Vector3( 0.0f, 0.0f, Camera.main.transform.position.z );
		
		foreach( GameObject obj in ObjectList )
		{
			Destroy( obj );
		}
		ObjectList.Clear();
	}

	//새로운 스테이지를 생성한다.
	void SetStage( int[ , ] _TileMap )
	{
		Vector2 [ , ] TilePos = new Vector2[12, _TileMap.Length / 12];

		// 오브젝트가 배치될 위치를 배열에 저장함
		for( int a = 0; 12 > a; ++a )
		{
			for( int b = 0; _TileMap.Length / 12 > b; ++b )
			{
				TilePos[ a, b ] = new Vector2( -5.12f + ( b * 0.64f ), 3.84f + ( -a * 0.64f ) );
			}
		}

		MaxWidth = (TilePos.Length / 12) / 2 * 0.64f;

		MaxWidth = MaxWidth + MaxWidth - 5.12f;
		
		for( int a = 0; 12 > a; ++a )
		{
			for( int b = 0; _TileMap.Length / 12 > b; ++b )
			{
				CreateObject( _TileMap[a, b], TilePos[ a, b ] );
			}
		}
	}
	//스테이지 변경 함수
	public void CreateStage( int NewStageNum )
	{
		DeleteStage ();
		SetStage( GameObject.Find ("GameManager").GetComponent<StageManager> ().Stage1[ NewStageNum ] );
	}
	//스테이지를 생성하면서 필요한 오브젝트를 만든다.
	void CreateObject( int _Number, Vector2 _Pos )
	{
		if ( NoneObject( _Number ) ) {
			return;
		}

		if (_Number == (int)OBJECTNUMBER.PLAYER) {
			ObjectList.Add (Instantiate (ObjectArray [_Number], new Vector3 (_Pos.x + 0.32f, _Pos.y - 0.32f, 0.0f), Quaternion.identity) as GameObject);
		} else if (_Number == (int)OBJECTNUMBER.WALL) {
			ObjectList.Add (Instantiate (ObjectArray [_Number], new Vector3 (_Pos.x + 0.32f, _Pos.y - 3.84f, 1.0f), Quaternion.identity) as GameObject);
		} else if( _Number == (int)OBJECTNUMBER.MATCHITEM ) {
			ObjectList.Add (Instantiate (ObjectArray [_Number], new Vector3 (_Pos.x + 0.16f, _Pos.y - 0.32f, 1.0f), Quaternion.identity) as GameObject );
		} else if( _Number == (int)OBJECTNUMBER.RAT || _Number == (int)OBJECTNUMBER.BATMAN || _Number == (int)OBJECTNUMBER.SWARM )
		{
			ObjectList.Add (Instantiate (ObjectArray [_Number], new Vector3 (_Pos.x + 1.28f, _Pos.y - 0.64f, 1.0f), Quaternion.identity) as GameObject );
		}
		else {
			if( ObjectArray [_Number] == null )
			{
				return;
			}
			ObjectList.Add(Instantiate (ObjectArray [_Number], new Vector3 (_Pos.x + 0.32f, _Pos.y - 0.32f, 1.0f), Quaternion.identity) as GameObject);
		}
	}
	//생성하지 않는 오브젝트를 걸러냄
	bool NoneObject( int _Number )
	{
		if (_Number == (int)OBJECTNUMBER.EMPTY) {
			return true;
		}

		return false;
	}
}