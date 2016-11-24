using UnityEngine;
using System.Collections;

public class MachingGunBehavior : MonoBehaviour {

	private Animator animator;
	private string[] joystick;
	public GameObject isAttachedTo;
	private Rigidbody2D shiprb2d;
	private float speed;
	private AudioSource shot;
	private AudioSource rotating;
	public float rotatingspeed =0f;
	public GameObject bulletPrefab;
	public Transform[] Output;
	public int ammo = 100;
    private int output = 0;
	// Use this for initialization
	void Start () {
		isAttachedTo = this.transform.parent.gameObject;
		shiprb2d = GetComponentInParent<Rigidbody2D> ();
		animator = this.GetComponent<Animator>();
		shot = this.GetComponents<AudioSource> ()[0];
		rotating = this.GetComponents<AudioSource> ()[1];
		rotating.pitch = 0f;
		joystick = GameObject.Find("GameDirector").GetComponent<GameDirector>().JoystickInitialisation (1);
		Output = this.GetComponentsInChildren<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton(joystick[13]) || Input.GetKey ("i")) {
			animator.SetBool ("isShooting", true);
		} else {
			animator.SetBool ("isShooting", false);
		}

	}

	void Shoot(){
		float pitch = Random.Range (0.9f, 1.1f);
		shot.pitch=pitch*Time.timeScale;
		shot.Play ();
		float rotationX =- Mathf.Cos((shiprb2d.rotation+90)*Mathf.Deg2Rad);
		float rotationY =- Mathf.Sin((shiprb2d.rotation+90)*Mathf.Deg2Rad);
		//Vector2 recul = new Vector2 (rotationX*30, rotationY*30);
		//shiprb2d.AddForce (recul);
		//float angle = Random.Range (-5f, 5f);
		float angle = 0f;
		Quaternion theangle = transform.rotation;
		theangle= theangle * Quaternion.Euler(new Vector3(0,0,angle));
        //theangle.eulerAngles(
        
		GameObject bullet = Instantiate (bulletPrefab, Output [output].position, theangle)  as GameObject ;
        nextShotOutput();
		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), isAttachedTo	.GetComponent<Collider2D>());
		ammo--;
	}

    void nextShotOutput(){
        if (output >= 3)
        {
            output = 1;
        }
        else
            output += 1;
    }





}
