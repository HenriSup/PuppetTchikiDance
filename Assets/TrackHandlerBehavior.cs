using UnityEngine;
using System.Collections;

public class TrackHandlerBehavior : MonoBehaviour {

	// Use this for initialization
	string[] partition;
	public GameObject note;
	public Transform noteSpawnerTransform;
	public Transform noteCursorTransform;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		bool triangleButtonPressed = Input.GetKeyDown("[8]"); //Triangle
		bool crossButtonPressed = Input.GetKeyDown("[2]"); //Croix
		bool squareButtonPressed = Input.GetKeyDown("[4]"); //Carré
		bool circleButtonPressed = Input.GetKeyDown("[6]"); //Rond
		this.spawnSomeShit(triangleButtonPressed,crossButtonPressed,squareButtonPressed,circleButtonPressed);
	}

	void spawnSomeShit(bool triangleButtonPressed,bool crossButtonPressed,bool squareButtonPressed,bool circleButtonPressed) {
		if(triangleButtonPressed){
			GameObject newNote = (GameObject)Instantiate(this.note, noteSpawnerTransform.position, transform.rotation);
			newNote.GetComponent<NoteBehavior>().init(Time.time+3,5f,(Vector2)this.noteSpawnerTransform.position,(Vector2)this.noteCursorTransform.position,NoteBehavior.Buttons.triangle);
		}		
		if(circleButtonPressed){
			GameObject newNote = (GameObject)Instantiate(this.note, noteSpawnerTransform.position, transform.rotation);
			newNote.GetComponent<NoteBehavior>().init(Time.time+3,5f,(Vector2)this.noteSpawnerTransform.position,(Vector2)this.noteCursorTransform.position,NoteBehavior.Buttons.circle);
		}
		if(crossButtonPressed){
			GameObject newNote = (GameObject)Instantiate(this.note, noteSpawnerTransform.position, transform.rotation);
			newNote.GetComponent<NoteBehavior>().init(Time.time+3,5f,(Vector2)this.noteSpawnerTransform.position,(Vector2)this.noteCursorTransform.position,NoteBehavior.Buttons.cross);	
		}		
		if(squareButtonPressed){
			GameObject newNote = (GameObject)Instantiate(this.note, noteSpawnerTransform.position, transform.rotation);
			newNote.GetComponent<NoteBehavior>().init(Time.time+3,5f,(Vector2)this.noteSpawnerTransform.position,(Vector2)this.noteCursorTransform.position,NoteBehavior.Buttons.square);
		}
	}
}
