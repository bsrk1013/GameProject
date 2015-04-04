using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	enum MENU
	{
		MAIN = 0,
		PLAY,
		DIE,
		COUNT
	}

	public int CurrentStage = 0;
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
	}

	void ChangeMenu( GameObject obj )
	{
		if (MenuArray [(int)MENU.MAIN] == obj) {
			if (GameObject.Find ("PlayButton").GetComponent<PlayButton> ().isClick) {
				Destroy (GameObject.Find ("MainBackGround(Clone)"));
				Main = MenuArray [(int)MENU.PLAY];
				Instantiate (Main);
				GetComponent<TileManager>().CreateStage( CurrentStage );
			}
		}

		if (MenuArray [(int)MENU.PLAY] == obj) {
			if( GameObject.Find("Player(Clone)").GetComponent<PlayerState>().isDied ){
				Main = MenuArray [(int)MENU.DIE];
				Instantiate (Main);
			} else if( CurrentStage > GetComponent<StageManager>().Stage1.Count )
			{
				Destroy( GameObject.Find( "PlayBackGround(Clone)" ) );
				GetComponent<TileManager>().DeleteStage();
				GetComponent<TileManager>().isLantern = false;
				Destroy( GameObject.Find( "DieBackGround(Clone)" ) );
				Main = MenuArray [(int)MENU.MAIN];
				Instantiate (Main);
			}
		}

		if (MenuArray [(int)MENU.DIE] == obj) {
			if( GameObject.Find ("MainMenuButton").GetComponent<MainMenuButton> ().isClick ) {
				Destroy( GameObject.Find( "PlayBackGround(Clone)" ) );
				GetComponent<TileManager>().DeleteStage();
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