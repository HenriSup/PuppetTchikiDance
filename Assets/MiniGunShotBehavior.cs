using UnityEngine;
using System.Collections;

public class MiniGunShotBehavior : MonoBehaviour  {

	public float speed = 1500;
	float lifeTime =5f;
	float startTime;
	int damage = 1;
	Rigidbody2D rb2d;
	Vector2 movement;
	string InstantiateBy;
	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		rb2d = this.GetComponent<Rigidbody2D> ();
		float x = Mathf.Cos ((rb2d.rotation+90)*Mathf.Deg2Rad);
		float y = Mathf.Sin ((rb2d.rotation+90)*Mathf.Deg2Rad);
		movement.Set (x, y);
		movement = movement.normalized * speed * 10 ;
		rb2d.AddForce (movement);
        
	}

	// Update is called once per frame
	void FixedUpdate () {
		if ((Time.time - startTime) > lifeTime) {
			destroy();
		}

        float x = Mathf.Cos((rb2d.rotation + 90) * Mathf.Deg2Rad);
        float y = Mathf.Sin((rb2d.rotation + 90) * Mathf.Deg2Rad);
        movement.Set(x, y);
        movement = movement.normalized * speed;
        rb2d.AddForce(movement);

    }

	void destroy() {
		Destroy (this.gameObject);
	}

	void Explode(float angle,Vector3 position) {
		Quaternion id = Quaternion.identity * Quaternion.Euler(new Vector3 (0,0,angle+180));

		GameObject bullet = Instantiate (explosionPrefab, position, id)  as GameObject;
		Destroy (this.gameObject);
	}
        

	void OnCollisionEnter2D(Collision2D coll) {

			ContactPoint2D contact = coll.contacts[0];
			//coll.gameObject.SendMessage("ApplyDamage", 10);
			Debug.DrawRay(contact.point, contact.normal , Color.yellow);
			Explode(Mathf.Atan2(contact.normal.y,contact.normal.x)*Mathf.Rad2Deg,contact.point);
	
		
	}


}
