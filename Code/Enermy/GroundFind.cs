using UnityEngine;
using System.Collections;

public class GroundFind : MonoBehaviour {

void OnTriggerStay2D( Collider2D _Other )
{
	if (_Other.tag == "Player")
	{
			this.GetComponentInParent<GroundEnermyMoving>().isCollied = true;
	}
}

void OnTriggerExit2D ( Collider2D _Other )
{
		this.GetComponentInParent<GroundEnermyMoving>().isCollied = false;
}
}