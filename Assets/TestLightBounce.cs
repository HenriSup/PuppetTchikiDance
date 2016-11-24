using UnityEngine;
using System.Collections;

public class TestLightBounce : MonoBehaviour {

	SpriteRenderer lightSpriteRenderer;
	public float bpm = 11 ;
	public float decallage = 0;
	// Use this for initialization
	void Start () {
		lightSpriteRenderer = this.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		lightSpriteRenderer.color = new Color (1f, 1f, 1f, Mathf.Cos ((Time.time+decallage)*bpm));
	}
}
