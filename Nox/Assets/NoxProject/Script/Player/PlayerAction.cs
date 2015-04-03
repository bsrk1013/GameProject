using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	}

	void OnTriggerStay2D( Collider2D _Other )
	{
		if (Input.GetKeyDown (KeyCode.W))
		{
			if ( _Other.tag == "Door1" )
			{
				GameObject.Find ("GameManager").GetComponent<GameManager>().CurrentStage += 1;
				GameObject.Find ("GameManager").GetComponent<TileManager>().CreateStage( GameObject.Find ("GameManager").GetComponent<GameManager>().CurrentStage );
			} else if( _Other.tag == "Door2" )
			{
				GameObject.Find ("GameManager").GetComponent<GameManager>().CurrentStage += 2;
				GameObject.Find ("GameManager").GetComponent<TileManager>().CreateStage( GameObject.Find ("GameManager").GetComponent<GameManager>().CurrentStage );
			} else if( _Other.tag == "Door3" )
			{
				GameObject.Find ("GameManager").GetComponent<GameManager>().CurrentStage += 3;
				GameObject.Find ("GameManager").GetComponent<TileManager>().CreateStage( GameObject.Find ("GameManager").GetComponent<GameManager>().CurrentStage );
			} else if( _Other.tag == "BackDoor1" )
			{
				GameObject.Find ("GameManager").GetComponent<GameManager>().CurrentStage -= 1;
				GameObject.Find ("GameManager").GetComponent<TileManager>().CreateStage( GameObject.Find ("GameManager").GetComponent<GameManager>().CurrentStage );
			} else if( _Other.tag == "BackDoor2" )
			{
				GameObject.Find ("GameManager").GetComponent<GameManager>().CurrentStage -= 2;
				GameObject.Find ("GameManager").GetComponent<TileManager>().CreateStage( GameObject.Find ("GameManager").GetComponent<GameManager>().CurrentStage );
			} else if( _Other.tag == "BackDoor3" )
			{
				GameObject.Find ("GameManager").GetComponent<GameManager>().CurrentStage -= 3;
				GameObject.Find ("GameManager").GetComponent<TileManager>().CreateStage( GameObject.Find ("GameManager").GetComponent<GameManager>().CurrentStage );
			} else if( _Other.tag == "Match" )
			{
				GetComponent<PlayerItem>().SetDefaultIntensity();
				Destroy( GameObject.Find( "MatchItem(Clone)" ) );
			}
		}
		if( _Other.tag == "Ladder" || _Other.tag == "LadderTop" )
		{
			GetComponent<PlayerState>().isClimbed = true;
		}
	}

	void OnTriggerExit2D( Collider2D _Other )
	{
		if (_Other.tag == "Ladder" || _Other.tag == "LadderTop" )
		{
			GetComponent<PlayerState>().isClimbed = false;
		}
	}
}