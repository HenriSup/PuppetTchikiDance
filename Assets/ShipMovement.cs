using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	public float speed = 20f;
	Vector2 movement;
	Rigidbody2D rb2d;
	private Animator animator;
	private string[] joystick;
	private bool contextAction;
	private Animator contextButtonAnimator;
	private bool superFast;
    public GameObject explosionPrefab;
    private bool isExploding = false;

	//bool isMoving;

	// Use this for initialization
	void Start () {

        isNotExploding();
		contextAction = false;
		superFast = false;
		//isMoving = false;
		animator = this.GetComponent<Animator>();
		rb2d = this.GetComponent<Rigidbody2D> ();
		//contextButtonAnimator = GameObject.Find ("ContextButton").GetComponent<Animator> ();
		joystick = GameObject.Find("GameDirector").GetComponent<GameDirector>().JoystickInitialisation (1);
	}	

	// Update is called once per frame
	void Update(){

		if (Input.GetButtonDown (joystick [9]) || Input.GetKeyDown ("x")) {
			contextAction = true;
		} else {
			contextAction = false;
		}
        if (Input.GetButtonDown (joystick[11]) || Input.GetKeyDown("v"))
        {
            Explode();
        }

        //print(isExploding);
	}

	void FixedUpdate(){
		//isMoving = false;
		superFast = false;
		float x = Input.GetAxis (joystick[0]);
		float y = Input.GetAxis (joystick[1]);
		if (Input.GetKey ("q")) {
			x=-1;
		}
		if (Input.GetKey ("d")) {
			x=1;
		}
		if (Input.GetKey ("s")) {
			y=-1;
		}
		if (Input.GetKey ("z")) {
			y=1;
		}

		if (Input.GetKey ("a")) {
			Rotate (rb2d.rotation+40);

		}
		if (Input.GetKey ("e")) {
			Rotate (rb2d.rotation-40);

        }
		if (SameAngle()) {
			superFast = true;
		}

			//isMoving=true;
		Animate (x, y);
		Move (x, y);

		if ((Mathf.Abs (Input.GetAxis (joystick[2])) > 0.2) || (Mathf.Abs (Input.GetAxis (joystick[5])) > 0.2)) 
		{
			float angle = Mathf.Atan2 (-Input.GetAxis (joystick[2]), Input.GetAxis (joystick[5])) * Mathf.Rad2Deg;
			Rotate (angle);
		}
	}

	void Move(float x,float y){
		// Set the movement vector based on the axis input.
		movement.Set (x, y);
		float multiplicator = 1;
		if (superFast) {
			multiplicator=1.5f;
		}
		// Normalise the movement vector and make it proportional to the speed per second.

		movement = movement.normalized * speed * multiplicator * Time.deltaTime;
		
		// Move the player to it's current position plus the movement.

		rb2d.AddForce (movement);
	}

	void Animate (float x, float y){
		bool isMoving = false;
		bool isMovingBack = false;
		bool isMovingRight = false;
		bool isMovingLeft = false;
		if (x != 0 || y != 0) {
			float rightAngle = rb2d.rotation;
			float leftAngle = Mathf.Atan2 (y,x) * Mathf.Rad2Deg;
			float angDiff = Mathf.DeltaAngle(leftAngle,rightAngle);

			if (Mathf.Abs(angDiff)>20 && Mathf.Abs(angDiff)<160){
				if (angDiff<0){
					isMoving= true;
				}
				else{
					isMovingBack= true;
				}
			}
			if (Mathf.Abs(angDiff)<70){
				isMovingRight= true;
			}
			if (Mathf.Abs(angDiff)>110){
				isMovingLeft= true;
			}

		}
		animator.SetBool ("isBoosting", superFast);
		animator.SetBool ("isMoving", isMoving);
		animator.SetBool ("isMovingBack", isMovingBack);
		animator.SetBool ("isMovingLeft", isMovingLeft);
		animator.SetBool ("isMovingRight", isMovingRight);
	}

	public bool getContextActionValue () {
		return contextAction;
	}

	public void setContextButtonValue (bool activate) {
		//contextButtonAnimator.SetBool ("On",activate);
	}


	void Rotate(float angle){
		float smoothAngle = Mathf.LerpAngle(this.rb2d.rotation,angle,0.2f);


		var rotationVector = transform.rotation.eulerAngles;
		rotationVector.z = smoothAngle;
		transform.rotation = Quaternion.Euler(rotationVector);
	}

	bool SameAngle(){
		bool result = false;
		float rSAngle=0;
		float lSAngle = 180;
		if ((Mathf.Abs (Input.GetAxis (joystick [2])) > 0.5) || (Mathf.Abs (Input.GetAxis (joystick [5])) > 0.5)) {
			if ((Mathf.Abs (Input.GetAxis (joystick [0])) > 0.5) || (Mathf.Abs (Input.GetAxis (joystick [1])) > 0.5)) {
				rSAngle = Mathf.Atan2 (Input.GetAxis (joystick[5]), Input.GetAxis (joystick[2])) * Mathf.Rad2Deg;
				lSAngle = Mathf.Atan2 (Input.GetAxis (joystick[1]), Input.GetAxis (joystick[0])) * Mathf.Rad2Deg;
			}
		}

		//rSAngle + " " + lSAngle
		float difference = Mathf.Abs(Mathf.DeltaAngle(rSAngle,lSAngle));
		if (difference <= 45) {
			result=true;
		}
		//print (result);
		return result;
	}

    void Explode()
    {

        //for (int i = 0; i < 1;i++)
        //{
        float randX = Random.Range(-0.2f, 0.2f);
        float randY = Random.Range(-0.2f, 0.2f);
        GameObject explosion = Instantiate(explosionPrefab, transform.position + new Vector3(randX, randX, -2), transform.rotation) as GameObject;
        explosion.transform.parent = transform;

        //explosion.GetComponent<ParticleSystem>().startRotation = transform.rotation.z;
        isExploding = true;
        Invoke("isNotExploding", 3);
        //}
    }

    void isNotExploding()
    {
        isExploding = false;
    }

	public bool GetSuperFast(){
		return superFast;
	}

	public Vector2 GetSpeed(){
		return rb2d.velocity;
	}

    public bool IsExploding()
    {
        return isExploding;
    }


}
