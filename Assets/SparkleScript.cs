using UnityEngine;
using System.Collections;

public class SparkleScript : MonoBehaviour {
	Rigidbody2D rigidbody;
	float lifeTime = 6;
	float spawnTime;
	// Use this for initialization

	void Start () {
		spawnTime = Time.time;
		rigidbody = this.GetComponent<Rigidbody2D>();
		var x = Random.Range(-2f,2f);
		var y = Random.Range(8f,10f);
		var speed = 50;
		this.rigidbody.AddForce(new Vector2(x*speed,y*speed));
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > (this.spawnTime+this.lifeTime)){
			Destroy(this.gameObject);
		}
	}

	void StartingPush() {
		
	}
}
