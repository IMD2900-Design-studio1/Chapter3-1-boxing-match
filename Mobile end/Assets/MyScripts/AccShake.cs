using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccShake : MonoBehaviour {
	
	//	public float speed = 10.0F;
	//	void Update() {
	//		Vector3 dir = Vector3.zero;
	//		dir.x = -Input.acceleration.y;
	//		dir.z = Input.acceleration.x;
	//		if (dir.sqrMagnitude > 1)
	//			dir.Normalize();
	//
	//		dir *= Time.deltaTime;
	//
	//		transform.Translate(dir * speed);
	//		//dir.x/Time.deltaTime

	public GameObject King;
	public GameObject bar;
    public Sprite myFirstImage; 
	public Sprite mySecondImage; 
	float m=0.1f;

	Vector2 accelerationDir;

	public void SetImage1(){
		King.GetComponent<SpriteRenderer>().sprite= myFirstImage;
	}
	public void SetImage2(){
		King.GetComponent<SpriteRenderer>().sprite= mySecondImage;
	}

	void Update(){
		accelerationDir = Input.acceleration;
		if (accelerationDir.sqrMagnitude < 30f && accelerationDir.sqrMagnitude > 15f) {
			SetImage1 ();
		}
		if (strengthBar.isWin==1) {
			SetImage2 ();	
		}
		//TODO:change isWin expression when we have more tasks
	}

}


