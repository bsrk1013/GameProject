using UnityEngine;
using System.Collections;

public class AirFind : MonoBehaviour {

	void OnTriggerStay2D( Collider2D _Other )
	{
		if (_Other.tag == "Player")
		{
			this.GetComponentInParent<AirEnermyMoving>().isCollied = true;
		}
	}
	
	void OnTriggerExit2D ( Collider2D _Other )
	{
		this.GetComponentInParent<AirEnermyMoving>().isCollied = false;
	}
}