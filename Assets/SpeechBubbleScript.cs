using UnityEngine;
using System.Collections;

public class SpeechBubbleScript : MonoBehaviour {

	private LineRenderer speechBubbleLineRenderer;
	private Vector3[] pointsCoordinates;

	// Use this for initialization
	void Start () {
		speechBubbleLineRenderer = this.GetComponent<LineRenderer> ();

		//for (int i = 0, i++, i<speechBubbleLineRenderer.
		    
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Mathf.Cos(Time.time));

	
	}
}
