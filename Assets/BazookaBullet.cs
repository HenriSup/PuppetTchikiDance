using UnityEngine;
using System.Collections;

public class BazookaBullet : MonoBehaviour  {
	
	public float startspeed = 800f;
	float lifeTime =10f;
	float startTime;
	public float speed = 40f;
	int damage = 5;
	Rigidbody2D rb2d;
	Vector2 movement;
	string InstantiateBy;
	public GameObject explosionPrefab;
	public bool isActivated = false;

	// Use this for initialization
	void Start () {

		startTime = Time.time;
		rb2d = this.GetComponent<Rigidbody2D> ();
		float x = Mathf.Cos ((rb2d.rotation+90)*Mathf.Deg2Rad);
		float y = Mathf.Sin ((rb2d.rotation+90)*Mathf.Deg2Rad);
		movement.Set (x, y);
		movement = movement.normalized * startspeed;
		rb2d.AddForce (movement);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if ((Time.time - startTime) > lifeTime) {
			Explode();
		}
		if (isActivated) {
			float x = Mathf.Cos ((rb2d.rotation+90)*Mathf.Deg2Rad);
			float y = Mathf.Sin ((rb2d.rotation+90)*Mathf.Deg2Rad);
			movement.Set (x, y);
			movement = movement.normalized * speed;
			rb2d.AddForce (movement);
		}

	}
	
	void destroy() {

		Destroy (this.gameObject);
	}

	void Explode() {
		Quaternion id = Quaternion.identity * Quaternion.Euler(new Vector3 (0,0,Random.Range (-20f, 20f)));
		GameObject bullet = Instantiate (explosionPrefab, this.transform.position, id)  as GameObject;
		Destroy (this.gameObject);
	}

	void Activate() {
		isActivated = true;
	}
	
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Base") {
			ContactPoint2D contact = coll.contacts[0];
			Vector2 pos = contact.point;
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal) * Quaternion.Euler(new Vector3 (0,0,Random.Range (-20f, 20f)));
			GameObject bullet = Instantiate (explosionPrefab, pos, rot)  as GameObject;
			//coll.gameObject.SendMessage("ApplyDamage", 10);
			Debug.DrawRay(contact.point, contact.normal , Color.yellow);
			destroy();
		}
		if (coll.gameObject.tag == "Player") {
			ContactPoint2D contact = coll.contacts[0];
			//coll.gameObject.SendMessage("ApplyDamage", 10);
			Debug.DrawRay(contact.point, contact.normal , Color.red);
			//destroy();
		}
		
	}
	
	
}
