using UnityEngine;
using System.Collections;

public class PuppetCharBehavior : MonoBehaviour {
	
	//TodoBeforeEverything:
	//Create a function for Eyes movement instead of doing that in the Update like a pig
	private Transform bodyTransform;
	private Transform faceTransform;
	private Transform leftEyeTransform;
	private Transform rightEyeTransform;
	private Transform mouthTransform;
	//private Transform leftHandTransform;
	//private Transform rightHandTransform;
	
	//private LineRenderer leftArmLineRenderer;
	//private LineRenderer rightArmLineRenderer;
	
	private Vector3 leftHandTransformOrigin;
	private Vector3 rightHandTransformOrigin;
	private Vector3 leftElbowOrigin;
	private Vector3 rightElbowOrigin;
	
	private Animator mouthAnimator;
	
	private string[] joystick;
	
	private float eyesStickSensivity;
	private float handsStickSensivity;
	
	// Use this for initialization
	void Start () {
		//Init FaceTransforms
		Transform[] FaceTransforms = this.GetComponentsInChildren<Transform>();
		bodyTransform = FaceTransforms[0];
		faceTransform = FaceTransforms[1];
		mouthTransform = FaceTransforms[2];
		leftEyeTransform = FaceTransforms[3];
		rightEyeTransform = FaceTransforms[4];
		//leftHandTransform = FaceTransforms[5];
		//rightHandTransform = FaceTransforms[6];
		
		//Init HandsTransforms
		//leftHandTransformOrigin = new Vector3 (leftHandTransform.localPosition.x, leftHandTransform.localPosition.y, leftHandTransform.localPosition.z);
		//rightHandTransformOrigin = new Vector3 (rightHandTransform.localPosition.x, rightHandTransform.localPosition.y, rightHandTransform.localPosition.z);
		
		//Init Arms LineRenderer
		LineRenderer[] ArmsLineRenderer = this.GetComponentsInChildren<LineRenderer> ();
		//leftArmLineRenderer = ArmsLineRenderer [0];
		//rightArmLineRenderer = ArmsLineRenderer [1];
		
		//init Elbows origins
		leftElbowOrigin = new Vector3 (-2.8f, -2.7f, 0);
		rightElbowOrigin = new Vector3 (2.8f, -2.7f, 0);
		
		
		//Init FaceAnimators
		Animator[] FaceAnimators = this.GetComponentsInChildren<Animator> ();
		//Debug.Log(FaceAnimators[0].name);
		mouthAnimator = FaceAnimators[1];
		
		//Sensivity Init
		eyesStickSensivity = 0.5f;
		handsStickSensivity = 3f;
		
		//Init Joystick
		joystick = GameObject.Find("PuppetChikiDanceDirector").GetComponent<PuppetChikiDanceDirector>().JoystickInitialisation (1);
		
	}
	
	// Update is called once per frame
	void Update () {
		//LeftStickValues
		float leftStickX = Input.GetAxis (joystick[0]);
		float leftStickY = Input.GetAxis (joystick[1]);
		//RightStickValues
		float rightStickX = Input.GetAxis (joystick[2]);
		float rightStickY = Input.GetAxis (joystick[5]);
		
		float RightTrigger = Input.GetAxis (joystick[4]);
		
		bool ahButtonPressed = Input.GetButton (joystick [8]) || Input.GetKey("down");//croix
		bool ohButtonPressed = Input.GetButton (joystick [10]) || Input.GetKey("right");//Rond
		bool heyButtonPressed = Input.GetButton (joystick [9]) || Input.GetKey("left");//carré
		bool ihButtonPressed = Input.GetButton (joystick [11]) || Input.GetKey("up");//Triangle


		bodyTransform.position = new Vector3 (0, RightTrigger/2, 0);
		MoveEyes (leftStickX,leftStickY,rightStickX,rightStickY);
		MoveHands (leftStickX,leftStickY,rightStickX,rightStickY);
		RenderArms (leftStickX,leftStickY,rightStickX,rightStickY);
		AnimateMouth (ahButtonPressed,ohButtonPressed,heyButtonPressed,ihButtonPressed);
	}
	
	void AnimateMouth(bool ahButtonPressed,bool ohButtonPressed,bool heyButtonPressed,bool ihButtonPressed){
		mouthAnimator.SetBool("Ah",ahButtonPressed);
		mouthAnimator.SetBool("Oh",ohButtonPressed);
		mouthAnimator.SetBool("Hey",heyButtonPressed);
		mouthAnimator.SetBool("Ih",ihButtonPressed);
	}
	
	bool IsThereAMouthButtonPressed()
	{
		bool TrianglePressed = Input.GetButton (joystick [11]);
		bool CirclePressed = Input.GetButton (joystick [10]);
		bool CrossPressed = Input.GetButton (joystick [9]);
		bool SquarePressed = Input.GetButton (joystick [8]);
		bool result = false;
		if ( TrianglePressed | CirclePressed | CrossPressed | SquarePressed )
		{
			result=true;
		}
		return result;
	}
	
	void MoveEyes(float leftStickX,float leftStickY,float rightStickX,float rightStickY){
		leftEyeTransform.localPosition = new Vector3 (leftStickX*eyesStickSensivity, leftStickY*eyesStickSensivity, leftEyeTransform.localPosition.z);
		rightEyeTransform.localPosition = new Vector3 (rightStickX*eyesStickSensivity, rightStickY*eyesStickSensivity, rightEyeTransform.localPosition.z);
	}

	void MoveHands(float leftStickX,float leftStickY,float rightStickX,float rightStickY){
		//leftHandTransform.localPosition = new Vector3 ((leftStickX*handsStickSensivity)+leftHandTransformOrigin.x, (leftStickY*handsStickSensivity)+leftHandTransformOrigin.y, leftHandTransform.localPosition.z);
		//rightHandTransform.localPosition = new Vector3 ((rightStickX*handsStickSensivity)+rightHandTransformOrigin.x, (rightStickY*handsStickSensivity)+rightHandTransformOrigin.y, rightHandTransform.localPosition.z);
	}

	void RenderArms(float leftStickX,float leftStickY,float rightStickX,float rightStickY){
		
		//leftArmLineRenderer.SetPosition(1,new Vector3((leftStickX*handsStickSensivity/2)+leftElbowOrigin.x,(leftStickY*handsStickSensivity/2)+leftElbowOrigin.y,leftElbowOrigin.z));
		//leftArmLineRenderer.SetPosition(2,new Vector3((leftStickX*handsStickSensivity)+leftHandTransformOrigin.x,(leftStickY*handsStickSensivity)+leftHandTransformOrigin.y,leftHandTransformOrigin.z));
		//rightArmLineRenderer.SetPosition(1,new Vector3((rightStickX*handsStickSensivity/2)+rightElbowOrigin.x,(rightStickY*handsStickSensivity/2)+rightElbowOrigin.y,rightElbowOrigin.z));
		//rightArmLineRenderer.SetPosition(2,new Vector3((rightStickX*handsStickSensivity)+rightHandTransformOrigin.x,(rightStickY*handsStickSensivity)+rightHandTransformOrigin.y,rightHandTransformOrigin.z));

	}
	
}
