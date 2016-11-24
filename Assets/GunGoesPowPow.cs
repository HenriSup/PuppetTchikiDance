using UnityEngine;
using System.Collections;

public class GunGoesPowPow : MonoBehaviour {
	private string[] joystick;
	private AudioSource gunSound;
	private Animator[] Animators;
	private Animator gunAnimator;
	private Animator shootAnimator;
	public bool isRightGun;
	// Use this for initialization
	void Start () {
		joystick = GameObject.Find("PuppetChikiDanceDirector").GetComponent<PuppetChikiDanceDirector>().JoystickInitialisation (1);
		gunSound = this.GetComponent<AudioSource> ();
		Animators = this.GetComponentsInChildren<Animator> ();
		gunAnimator = Animators [0];
		shootAnimator = Animators [1];
		Debug.Log(gunAnimator.name);
	}
	
	// Update is called once per frame
	void Update () {
		bool ObjectButtonPressed = Input.GetButtonDown (joystick [12]);
		if (isRightGun) {
			ObjectButtonPressed = Input.GetButtonDown (joystick [13]);
		}

		if (ObjectButtonPressed) {
			gunSound.Play();
		} 
		AnimateGun (ObjectButtonPressed);
	}

	void AnimateGun(bool Shoot) {
		gunAnimator.SetBool("Shoots",Shoot);
		shootAnimator.SetBool("Shoots",Shoot);
	}
}
