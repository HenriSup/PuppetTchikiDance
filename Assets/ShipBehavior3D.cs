using UnityEngine;
using System.Collections;

public class ShipBehavior3D : MonoBehaviour {
    private Rigidbody2D ShipRB2D;
	// Use this for initialization
	void Start () {
        ShipRB2D = GetComponentInParent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        print(ShipRB2D.angularVelocity/60);

        Vector3 pitch = new Vector3(transform.eulerAngles.x, transform.localEulerAngles.y+ 10, transform.eulerAngles.z);
        //transform.eulerAngles = pitch;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, ShipRB2D.velocity.x, ShipRB2D.transform.rotation.z);
    }
}
