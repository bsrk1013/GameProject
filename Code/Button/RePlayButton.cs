using UnityEngine;
using System.Collections;

public class RePlayButton : IButton {
	// Use this for initialization
	void Start () {
		rd = GetComponent<SpriteRenderer> ();
		isClick = false;
	}
	
	void OnMouseDown()
	{
		GetComponent<AudioSource> ().Play ();
		rd.sprite = DownButton;
	}
	
	void OnMouseUp()
	{
		rd.sprite = Idle;
		isClick = true;
	}
	
	void OnMouseOver()
	{
		rd.sprite = MouseOver;
	}
	
	void OnMouseExit()
	{
		rd.sprite = Idle;
	}
}