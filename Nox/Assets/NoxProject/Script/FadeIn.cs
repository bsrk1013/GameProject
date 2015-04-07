using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	private float Alpha;
	public float Speed;
	public bool isAutoDel;

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
		}else {
			if( isAutoDel )
			{
				Destroy( this.gameObject );
			}
		}
	}
}