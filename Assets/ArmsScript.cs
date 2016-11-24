using UnityEngine;
using System.Collections;

public class ArmsScript : MonoBehaviour {
	
	private Transform shoulderTransform;
	private Transform elbowTransform;
	private Transform handTransform;
	
	private LineRenderer ArmLineRenderer;
	private LineRenderer ForeArmLineRenderer;

	private Vector3 handTransformOrigin;
	private float handsStickSensivityX;
	private float handsStickSensivityY;

	public bool rightArm = false;

	private string[] joystick;

	// Use this for initialization
	void Start () {
		Transform[] ArmTransforms = this.GetComponentsInChildren<Transform>();
		shoulderTransform = ArmTransforms[1];
		elbowTransform = ArmTransforms[2];
		handTransform = ArmTransforms[3];

		handsStickSensivityX = 2f;
		handsStickSensivityY = 5f;

		LineRenderer[] ArmsLineRenderer = this.GetComponentsInChildren<LineRenderer> ();
		ForeArmLineRenderer = ArmsLineRenderer[1];
		ArmLineRenderer = ArmsLineRenderer[0];

		joystick = GameObject.Find("PuppetChikiDanceDirector").GetComponent<PuppetChikiDanceDirector>().JoystickInitialisation (1);

		handTransformOrigin = new Vector3 (handTransform.localPosition.x, handTransform.localPosition.y, handTransform.localPosition.z);
	}
	
	// Update is called once per frame
	void Update () {
		RenderArms ();
		float stickX = Input.GetAxis (joystick [0]);
		float stickY = Input.GetAxis (joystick [1]);

		if (rightArm) {
			stickX = Input.GetAxis (joystick [2]);
			stickY = Input.GetAxis (joystick [5]);
		}

		MoveHand (stickX,stickY);
	}

	void RenderArms(){

		ForeArmLineRenderer.SetPosition(0,shoulderTransform.localPosition+new Vector3(0,0,1));
		ForeArmLineRenderer.SetPosition(1,elbowTransform.localPosition+new Vector3(0,0,1));

		ArmLineRenderer.SetPosition(0,elbowTransform.localPosition+new Vector3(0,0,1));
		ArmLineRenderer.SetPosition(1,handTransform.localPosition+new Vector3(0,0,1));

	}

	void MoveHand(float stickX,float stickY){
		handTransform.localPosition = new Vector3 ((stickX*handsStickSensivityX)+handTransformOrigin.x, (stickY*handsStickSensivityY)+handTransformOrigin.y, handTransform.localPosition.z);

	}
}
