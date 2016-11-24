using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y+1f,-4);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = position;
		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y+1f,-4);
            
	
	}


}

