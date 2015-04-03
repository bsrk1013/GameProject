using UnityEngine;
using System.Collections;

public class PlayerItem : MonoBehaviour {

	public GameObject Light;
	private GameObject[] MatchLight = new GameObject[2];
	private int Lightz = -1;
	public int DefaultIntensity;
	public float CurrentIntensity;
	public float DecreaseIntensity;


	// Use this for initialization
	void Start () {
		CreateLight ();
	}

	void FixedUpdate()
	{
		if (GetComponent<PlayerState> ().isDie)
		{
			return;
		}

		for (int i = 0; i < MatchLight.Length; ++i)
		{
			MatchLight[i].GetComponent<Light>().intensity -= DecreaseIntensity * Time.deltaTime;
		}

		CurrentIntensity = MatchLight [0].GetComponent<Light> ().intensity;
	}

	void CreateLight()
	{
		for( int i = 0; i < MatchLight.Length; ++i )
		{
			MatchLight[i] = Instantiate( Light );
			MatchLight[i].transform.parent = this.transform;
			MatchLight[i].transform.localPosition = new Vector3( 0.0f, 0.0f, Lightz );
			MatchLight[i].GetComponent<Light>().intensity = 1.0f;
			Lightz *= -1;
		}
	}

	public void SetDefaultIntensity()
	{
		for (int i = 0; i < MatchLight.Length; ++i)
		{
			MatchLight[i].GetComponent<Light>().intensity = DefaultIntensity;
		}
	}
}