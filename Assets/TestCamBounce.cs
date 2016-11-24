using UnityEngine;
using System.Collections;

public class TestCamBounce : MonoBehaviour {

	Camera sceneCamera;
	float originSize;

	// Use this for initialization
	void Start () {
		sceneCamera = this.GetComponent<Camera> ();
		originSize = sceneCamera.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		//sceneCamera.orthographicSize = originSize + (Mathf.Cos(Time.time*3f))*1f;
		//sceneCamera.transform.Rotate(new Vector3(0f,0f,(Mathf.Cos(Time.time*2f))*0.05f));
	
	}
}
