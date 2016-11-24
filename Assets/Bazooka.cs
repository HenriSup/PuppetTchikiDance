using UnityEngine;
using System.Collections;

public class Bazooka : MonoBehaviour {
	
	private Animator animator;
	private string[] joystick;
	private GameObject isAttachedTo;
	private Rigidbody2D shiprb2d;
	private float speed;
	private AudioSource shot;
	private AudioSource rotating;
	public GameObject bulletPrefab;
	public Transform[] Output;
	public int ammo = 100;
	public int reculAmount = 100;

	// Use this for initialization
	void Start () {
		isAttachedTo = this.transform.parent.gameObject;
		shiprb2d = GetComponentInParent<Rigidbody2D> ();
		animator = this.GetComponent<Animator>();
		shot = this.GetComponents<AudioSource> ()[0];
		joystick = GameObject.Find("GameDirector").GetComponent<GameDirector>().JoystickInitialisation (1);
		Output = this.GetComponentsInChildren<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(joystick[13]) || Input.GetKey ("i")) {
			animator.SetBool ("isShooting", true);
		} else {
			animator.SetBool ("isShooting", false);
		}
		

	}
	
	void Shoot(){

		float startPitch = 1f;
		float pitch = Random.Range (startPitch-0.2f, startPitch+0.2f);
		shot.pitch=pitch*Time.timeScale;
		shot.Play ();
		float rotationX =- Mathf.Cos((shiprb2d.rotation+90)*Mathf.Deg2Rad);
		float rotationY =- Mathf.Sin((shiprb2d.rotation+90)*Mathf.Deg2Rad);
		Vector2 recul = new Vector2 (rotationX*reculAmount, rotationY*reculAmount);
		shiprb2d.AddForce (recul);
		float angle = Random.Range (0f, 0f);
		Quaternion theangle = transform.rotation;
		theangle= theangle * Quaternion.Euler(new Vector3(0,0,angle));
		//theangle.eulerAngles(
		GameObject bullet = Instantiate (bulletPrefab, Output [1].position, theangle)  as GameObject;
		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), isAttachedTo	.GetComponent<Collider2D>());
		ammo--;
	}



	
}
