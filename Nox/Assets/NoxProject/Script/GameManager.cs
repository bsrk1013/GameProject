﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	enum MENU
	{
		MAIN = 0,
		PLAY,
		DIE,
		PRODUCE,
		END,
		STORY,
		COUNT
	}

	public GameObject Example;
	public int CurrentStage = 0;
	public bool isEnded = false;
	public GameObject[] MenuArray = new GameObject[( int )MENU.COUNT];
	private GameObject Main;

	// Use this for initialization
	void Start () {
		Main = MenuArray [( int )MENU.MAIN];
		Instantiate ( Main );
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		ChangeMenu ( Main );

		if (Input.GetKeyDown (KeyCode.Escape) && Main == MenuArray [(int)MENU.PRODUCE]) {
			Destroy (GameObject.Find ("ProductBackGround(Clone)"));
			Main = MenuArray [(int)MENU.MAIN];
			Instantiate (Main);
		} else if (Input.GetKeyDown (KeyCode.Escape) && Main == MenuArray [(int)MENU.END]) {
			isEnded = false;
			Destroy (GameObject.Find ("EndBackGround(Clone)"));
			Main = MenuArray [(int)MENU.STORY];
			Instantiate (Main);
		} else if (Input.GetKeyDown (KeyCode.Escape) && Main == MenuArray [(int)MENU.STORY]) {
			Destroy (GameObject.Find ("StoryBackGround(Clone)"));
			Main = MenuArray [(int)MENU.MAIN];
			Instantiate (Main);
		}
	}

	void ChangeMenu( GameObject obj )
	{
		if (MenuArray [(int)MENU.MAIN] == obj) {
			if (GameObject.Find ("PlayButton").GetComponent<PlayButton> ().isClick) {
				Destroy (GameObject.Find ("MainBackGround(Clone)"));
				Main = MenuArray [(int)MENU.PLAY];
				Instantiate (Main);
				GetComponent<TileManager>().CreateStage( CurrentStage );
				Instantiate( Example );
			} else if( GameObject.Find ("ProducerButton").GetComponent<ProducerButton> ().isClick )
			{
				Destroy (GameObject.Find ("MainBackGround(Clone)"));
				Main = MenuArray [(int)MENU.PRODUCE];
				Instantiate (Main);
			}
		}

		else if (MenuArray [(int)MENU.PLAY] == obj) {
			if( GameObject.Find("Player(Clone)").GetComponent<PlayerState>().isDied ){
				Main = MenuArray [(int)MENU.DIE];
				Instantiate (Main);
			} else if( isEnded )
			{
				PlayerItem.CurrentIntensity = 1.0f;
				Destroy( GameObject.Find( "PlayBackGround(Clone)" ) );
				GetComponent<TileManager>().DeleteStage();
				Main = MenuArray [(int)MENU.END];
				Instantiate (Main);
			}
		}

		else if (MenuArray [(int)MENU.DIE] == obj) {
			if( GameObject.Find ("MainMenuButton").GetComponent<MainMenuButton> ().isClick ) {
				Destroy( GameObject.Find( "PlayBackGround(Clone)" ) );
				PlayerItem.CurrentIntensity = 1.0f;
				GetComponent<TileManager>().DeleteStage();
				CurrentStage = 0;
				GetComponent<TileManager>().isLantern = false;
				Destroy( GameObject.Find( "DieBackGround(Clone)" ) );
				Main = MenuArray [(int)MENU.MAIN];
				Instantiate (Main);
			} else if(GameObject.Find ("RePlayButton").GetComponent<RePlayButton>().isClick){
				Destroy( GameObject.Find( "DieBackGround(Clone)" ) );
				GetComponent<TileManager>().CreateStage( CurrentStage );
				PlayerItem.CurrentIntensity = GameObject.Find( "Player(Clone)" ).GetComponent<PlayerItem>().DefaultIntensity / 2;
				Main = MenuArray [(int)MENU.PLAY];
			}
		}
	}
}