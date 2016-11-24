using UnityEngine;
using System.Collections;

public class CharacterBehavior : MonoBehaviour {

	Animator animator ;
	float lastBlinkTime = 0f;
	float timeMinBlink = 2f;
	float timeMaxBlink = 10f;
	float timeBetweenBlinks = 0f;
	bool mustBlink = false;
	bool moving = false;
	Rigidbody2D shipRb2d;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		shipRb2d = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
		timeBetweenBlinks = getNextBlink ();

	}
	
	// Update is called once per frame
	void Update () {
		mustBlink = false;
		moving = false;
		if ((Mathf.Max(Mathf.Abs(shipRb2d.velocity.x),Mathf.Abs(shipRb2d.velocity.y))>10f)){
			moving = true;
		}
		if ((Time.time-lastBlinkTime)>timeBetweenBlinks){
			mustBlink = true;
			timeBetweenBlinks = getNextBlink ();
			lastBlinkTime = Time.time;
		}
		animator.SetBool ("MustBlink", mustBlink);	
		animator.SetBool ("Moving", moving);

	}

	float getNextBlink(){
		return Random.Range (timeMinBlink, timeMaxBlink);
	}


}
