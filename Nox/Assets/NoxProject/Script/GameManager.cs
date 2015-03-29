using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int CurrentStage = 0;
	public GameObject[] MenuArray = new GameObject[3];
	private GameObject Main;

	// Use this for initialization
	void Start () {
		Main = MenuArray [0];
		Instantiate ( Main );
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		ChangeMenu ( Main );
	}

	void ChangeMenu( GameObject obj )
	{
		if (MenuArray [0] == obj)
		{
			if (GameObject.Find ("PlayButton").GetComponent<PlayButton> ().isClick)
			{
				GameObject.Find ("PlayButton").GetComponent<PlayButton> ().isClick = false;
				Destroy( GameObject.Find("MainBackGround(Clone)") );
				Main = MenuArray [1];
				Instantiate ( Main );
			}
		}
	}
}