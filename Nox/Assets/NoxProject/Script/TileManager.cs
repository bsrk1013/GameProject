using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {

	enum OBJECTNUMBER
	{
		PLAYER = 1,
		TILE,
		WALL,
		DOOR,
		COUNT,
	};

	public List<GameObject> ObjectList;
	public GameObject[] ObjectArray = new GameObject[ (int)OBJECTNUMBER.COUNT ] ;
	private Vector2 [ , ] TilePos = new Vector2[12,16];

	// Use this for initialization
	void Start () {
		ObjectList = new List<GameObject>();
		;

		SetStage (GameObject.Find ("GameManager").GetComponent<StageManager> ().Stage1 [GameObject.Find ("GameManager").GetComponent<GameManager> ().CurrentStage]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetStage( int[ , ] _TileMap )
	{
		// 오브젝트가 배치될 위치를 배열에 저장함
		for( int a = 0; 12 > a; ++a )
		{
			for( int b = 0; 16 > b; ++b )
			{
				TilePos[ a, b ] = new Vector2( -5.12f + ( b * 0.64f ), 3.84f + ( -a * 0.64f ) );
			}
		}
		
		for( int a = 0; 12 > a; ++a )
		{
			for( int b = 0; 16 > b; ++b )
			{
				CreateObject( _TileMap[a, b], a, b );
			}
		}
	}

	void CreateObject( int _Number, int _a, int _b )
	{

		if (_Number == (int)OBJECTNUMBER.PLAYER) {
			ObjectList.Add(Instantiate (ObjectArray [_Number], new Vector3 (TilePos [_a, _b].x + 0.32f, TilePos [_a, _b].y - 0.32f, 0.0f), Quaternion.identity) as GameObject);
		} else if (_Number == (int)OBJECTNUMBER.TILE) {
			ObjectList.Add(Instantiate (ObjectArray [_Number], new Vector3 (TilePos [_a, _b].x + 0.32f, TilePos [_a, _b].y - 0.32f, 1.0f), Quaternion.identity) as GameObject);
		} else if (_Number == (int)OBJECTNUMBER.DOOR) {
			ObjectList.Add(Instantiate (ObjectArray [_Number], new Vector3 (TilePos [_a, _b].x + 0.32f, TilePos [_a, _b].y - 0.32f, 1.0f), Quaternion.identity) as GameObject);
		} else if (_Number == (int)OBJECTNUMBER.WALL) {
			ObjectList.Add(Instantiate (ObjectArray [_Number], new Vector3 (TilePos [_a, _b].x + 0.32f, TilePos [_a, _b].y - 3.84f, 1.0f), Quaternion.identity) as GameObject);
		}
	}
}