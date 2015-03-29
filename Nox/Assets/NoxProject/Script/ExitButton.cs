﻿using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {
	
	private SpriteRenderer rd;
	public Sprite DownButton;
	public Sprite MouseOver;
	public Sprite Idle;
	
	// Use this for initialization
	void Start () {
		rd = GetComponent<SpriteRenderer> ();
	}
	
	void OnMouseDown()
	{
		GetComponent<AudioSource> ().Play ();
		rd.sprite = DownButton;
	}
	
	void OnMouseUp()
	{
		rd.sprite = Idle;
		Application.Quit ();
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