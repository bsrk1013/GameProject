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
			if (_Other.tag == "Door")
			{
				foreach( GameObject obj in GameObject.Find ("TileManager").GetComponent<TileManager>().ObjectList )
				{
					Destroy( obj );
				}
				GameObject.Find ("TileManager").GetComponent<TileManager>().ObjectList.Clear();
				++GameObject.Find ("GameManager").GetComponent<GameManager>().CurrentStage;
				GameObject.Find ("TileManager").GetComponent<TileManager>().SetStage( GameObject.Find ("GameManager").GetComponent<StageManager> ().Stage1[GameObject.Find ("GameManager").GetComponent<GameManager>().CurrentStage] );
			}
		}
	}
}