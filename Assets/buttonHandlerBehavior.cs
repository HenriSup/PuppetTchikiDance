using UnityEngine;
using System.Collections;

public class buttonHandlerBehavior : MonoBehaviour {

	private string[] joystick;
	private Animator[] buttonAnimators;
	public GameObject greenSparkle;
	public GameObject redSparkle;
	public GameObject blueSparkle;
	public GameObject pinkSparkle;
	public Transform[] buttonPosition;
	// Use this for initialization
	void Start () {
		buttonAnimators = this.GetComponentsInChildren<Animator>();
		buttonPosition = this.GetComponentsInChildren<Transform>();
		joystick = GameObject.Find("PuppetChikiDanceDirector").GetComponent<PuppetChikiDanceDirector>().JoystickInitialisation (1);
	}
	
	// Update is called once per frame
	void Update () {
		bool triangleButtonPressed = Input.GetButton (joystick [11]) || Input.GetKey("up"); //Triangle
		bool circleButtonPressed = Input.GetButton (joystick [10]) || Input.GetKey("right"); //Rond
		bool crossButtonPressed = Input.GetButton (joystick [9]) || Input.GetKey("down"); //Croix
		bool squareButtonPressed = Input.GetButton (joystick [8]) || Input.GetKey("left"); //Carré
		AnimateButtons(triangleButtonPressed,crossButtonPressed,squareButtonPressed,circleButtonPressed);
		AddEffects(triangleButtonPressed,crossButtonPressed,squareButtonPressed,circleButtonPressed);

	}
	void AnimateButtons(bool triangle,bool cross,bool square,bool circle) {
		this.buttonAnimators[0].SetBool("Active",triangle);
		this.buttonAnimators[1].SetBool("Active",square);
		this.buttonAnimators[2].SetBool("Active",cross);
		this.buttonAnimators[3].SetBool("Active",circle);
	}

	void AddEffects(bool triangle,bool cross,bool square,bool circle) {
		if (triangle) {
			Instantiate(greenSparkle, buttonPosition[1].position, transform.rotation);
		}if (square) {
			Instantiate(pinkSparkle, buttonPosition[2].position, transform.rotation);
		}if (cross) {
			Instantiate(blueSparkle, buttonPosition[3].position, transform.rotation);
		}if (circle) {
			Instantiate(redSparkle, buttonPosition[4].position, transform.rotation);
		}
	}
}
