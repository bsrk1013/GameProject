using UnityEngine;
using System.Collections;

public class DieRange : MonoBehaviour {

	void OnTriggerEnter2D( Collider2D _Other )
	{
		if (_Other.tag == "Player") {
			GameObject.Find ("Player(Clone)").GetComponent<PlayerState> ().isDied = true;
		}
	}
}