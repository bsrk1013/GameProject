using UnityEngine;
using System.Collections;

public class TileManager : MonoBehaviour {

	public GameObject Tile;
	public GameObject Player;
	private int[ , ] TileMap =
	{{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
	{0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
	{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};
	private Vector2 [ , ] TilePos = new Vector2[12,16];

	// Use this for initialization
	void Start () {
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
				if( TileMap[a, b] == 1 )
				{
					Instantiate( Tile, new Vector3( TilePos[ a, b ].x + 0.32f, TilePos[ a, b ].y - 0.32f, 0.0f ), Quaternion.identity );
				}
				if( TileMap[a, b] == 2 )
				{
					Instantiate( Player, new Vector3( TilePos[ a, b ].x + 0.32f, TilePos[ a, b ].y - 0.32f, 0.0f ), Quaternion.identity );
				}
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}