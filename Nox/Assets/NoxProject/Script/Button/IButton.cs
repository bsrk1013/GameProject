using UnityEngine;
using System.Collections;

public abstract class IButton : MonoBehaviour {

	protected SpriteRenderer rd;
	public Sprite DownButton;
	public Sprite MouseOver;
	public Sprite Idle;
	public bool isClick;

	// Use this for initialization
	protected void Start (){}
	
	protected void OnMouseDown (){}
	
	protected void OnMouseUp (){}
	
	protected void OnMouseOver (){}
	
	protected void OnMouseExit (){}
}