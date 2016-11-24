using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	
	public GameObject target;
	public Vector3 specificVector;
	public float smoothSpeed;
	//private string[] joystick;
    private bool targetIsExploding = false;

	void Start () { 
		//joystick = GameObject.Find("GameDirector").GetComponent<GameDirector>().JoystickInitialisation (1);
        
	}
	
	void Update () {
        
		Vector3 speedScreenShake = Screenshake();
        Vector3 explosionScreenShake = new Vector3(0, 0, 0);
        targetIsExploding = target.GetComponent<ShipMovement>().IsExploding();
        /*if ((Mathf.Abs (Input.GetAxis (joystick[2])) > 0.1) || (Mathf.Abs (Input.GetAxis (joystick[5])) > 0.1)) 
		{
			aiming = new Vector3 (Input.GetAxis (joystick[2]), Input.GetAxis (joystick[5]),0)*3;
		}*/
        if (targetIsExploding)
        {
            explosionScreenShake = ExplosionScreenShake();
        }

        Vector3 targetposition = (new Vector3(target.transform.position.x,target.transform.position.y,transform.position.z))+ speedScreenShake+explosionScreenShake;
		Vector3 actualposition = this.transform.position;
		this.transform.position = Vector3.Lerp (actualposition, targetposition, smoothSpeed);
	}

	void FixedUpdate() {
	
	}

	Vector3 Screenshake() {
		Vector3 shakeVector = new Vector3 (0, 0, 0);
		Vector2 ShipSpeed = target.GetComponent<ShipMovement> ().GetSpeed();
		if (Mathf.Max (Mathf.Abs (ShipSpeed.x), Mathf.Abs (ShipSpeed.y)) > 15) {

			float ratio = Mathf.Max (Mathf.Abs (ShipSpeed.x), Mathf.Abs (ShipSpeed.y)) / 22.5f;
			//print (ratio);
			float shake = (Random.Range (-0.04f, 0.04f)) * ratio;
			shakeVector = new Vector3 (shake, shake, 0);
		}
		return shakeVector;
	}

    Vector3 ExplosionScreenShake()
    {
        float value = 0.15f;
        float shake1 = (Random.Range(-value, value));
        float shake2 = (Random.Range(-value, value));
        Vector3 shakeVector = new Vector3(shake1, shake2, 0);
        return shakeVector;
    }



}