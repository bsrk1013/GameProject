using UnityEngine;
using System.Collections;

public class FindPlayer : MonoBehaviour {

void OnTriggerStay2D( Collider2D _Other )
{
	if (_Other.tag == "Player")
	{
			GameObject.Find( "Rat(Clone)" ).GetComponent<EnermyMoving>().isCollied = true;
	}
}

void OnTriggerExit2D ( Collider2D _Other )
{
		GameObject.Find( "Rat(Clone)" ).GetComponent<EnermyMoving>().isCollied = false;
}
}