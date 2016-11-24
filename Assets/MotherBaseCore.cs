using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotherBaseCore : MonoBehaviour {
	public bool ShouldBeUp;
	private Animator animator;
	private AudioSource[] musics;
	private int playingMusic = 0;
	List<GameObject> players = new List<GameObject>();

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		musics = this.GetComponents<AudioSource> ();
		ShouldBeUp = false;
		musics [0].Play ();

	}
	
	// Update is called once per frame
	void Update () {
		animator.SetBool ("ShouldBeUp", ShouldBeUp);
		foreach (GameObject player in players) {
			if (player.GetComponent<ShipMovement>().getContextActionValue()){
					NextMusic ();
			}
		}

	}


	void NextMusic() {
		int nextMusic = playingMusic + 1;
		if (nextMusic > musics.Length - 1) {
			nextMusic = 0;
		}
		musics [playingMusic].Stop ();
		musics [nextMusic].Play ();
		playingMusic = nextMusic;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			ShouldBeUp = true;
			other.gameObject.GetComponent<ShipMovement>().setContextButtonValue(true);
			players.Add(other.gameObject);
		}  
	}



	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			ShouldBeUp = false;
			other.gameObject.GetComponent<ShipMovement>().setContextButtonValue(false);
			players.Remove(other.gameObject);
		}  
	}
}
