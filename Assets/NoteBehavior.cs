using UnityEngine;
using System.Collections;

public class NoteBehavior : MonoBehaviour {

	float arrivalTime;
	float spawnTime;
	float length; //not used yet, will be used for longer notes
	float lifeTime;
	public Sprite[] buttonSprites;
	Vector2 spawnPoint = new Vector2(0,0);
	Vector2 arrivalPoint = new Vector2(0,0);
	public enum Buttons {triangle, circle, cross, square};
	Buttons noteButton;
	SpriteRenderer noteSpriteRenderer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		move();
	}

	void setButton(Buttons button){
		this.noteButton = button;
	}

	public void init(float arrivalTime,float length,Vector2 spawnPoint,Vector2 arrivalPoint,Buttons button) {
		this.noteSpriteRenderer = this.GetComponent<SpriteRenderer>();
		this.arrivalTime = arrivalTime;
		this.length = length;
		this.spawnTime = Time.time;
		this.lifeTime = 0;
		this.spawnPoint = spawnPoint;
		this.arrivalPoint = arrivalPoint;
		this.noteButton = button;
		this.noteSpriteRenderer.sprite = this.buttonSprites[(int)this.noteButton];
	}

	void move(){
		float distanceBetweenSpawnAndArrival = spawnPoint.x - arrivalPoint.x;
		float timeBetweenSpawnAndArrival = arrivalTime - spawnTime;
		this.lifeTime = Time.time - spawnTime;
		float percentageOfLifeTime = this.lifeTime/timeBetweenSpawnAndArrival;
		if (percentageOfLifeTime>=1f){
			Destroy(this.gameObject);
		}
		this.transform.position = Vector2.Lerp(spawnPoint, arrivalPoint, percentageOfLifeTime);
	}
}

