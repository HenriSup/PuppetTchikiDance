using UnityEngine;
using System.Collections;

public class WeaponHandler : MonoBehaviour {

	Animator minigunAnimator;
	Animator bazookaAnimator;
	bool minigunActivated;
	bool bazookaActivated;
	private string[] joystick;

	// Use this for initialization
	void Start () {
		joystick = GameObject.Find("GameDirector").GetComponent<GameDirector>().JoystickInitialisation (1);
		minigunActivated = true;
		bazookaActivated = false;
		bazookaAnimator = GetComponentsInChildren<Animator> ()[2];
		minigunAnimator = GetComponentsInChildren<Animator> ()[3];

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown (joystick [9]) ) {
			Activate ("minigun");
		} 
		if (Input.GetButtonDown (joystick [10]) ) {
			Activate ("bazooka");
		} 

		bazookaAnimator.SetBool ("isActivated", bazookaActivated);
		minigunAnimator.SetBool ("isActivated", minigunActivated);

	}

	void Activate(string weapon)
	{
		DesactivateAll ();
		if (weapon == "bazooka") {
			bazookaActivated = true;
		}
		if (weapon == "minigun") {
			minigunActivated = true;
		}
	}

	void DesactivateAll(){
		minigunActivated = false;
		bazookaActivated = false;
	}
}
