using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public float Alpha;
	public float Speed;

	// Use this for initialization
	void Start () {
		Alpha = 0.0f;
		Speed = 0.5f;
		GetComponent<SpriteRenderer> ().color = new Vector4 ( 255.0f, 255.0f, 255.0f, Alpha );
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<SpriteRenderer> ().color.a < 1.0f)
		{
			Alpha += Speed * Time.deltaTime;
			GetComponent<SpriteRenderer> ().color = new Vector4 ( 255.0f, 255.0f, 255.0f, Alpha );
		}
	}
}