using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	float timeStart;
	public float lifeTime = 3f;
	AudioSource[] sounds;
	// Use this for initialization
	void Start () {
		timeStart = Time.time;
		sounds = GetComponents <AudioSource> ();
		PlayRandomSound ();
		//float size = Random.Range (1f, 1.2f);
		this.transform.localScale = new Vector3 (2, 2, 1);
	}
	
	// Update is called once per frame
	void Update () {
	 	if (Time.time > (timeStart + lifeTime)) {
			Destroy (this.gameObject);
		}
	}

	void PlayRandomSound(){
		int maxRange = sounds.Length;
		//print (maxRange);
		int number = Random.Range (0, maxRange);

		sounds [number].pitch = Random.Range (0.8f, 1.1f);
		sounds[number].Play ();
	}
	

}
