using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer: MonoBehaviour {

		float speed = 1F;
		Rigidbody rb;


	void Start()
		{
			rb = GetComponent<Rigidbody>();
		}

		void Update ()
		{
			Vector3 acc = Input.acceleration;
		if(acc.x * speed<Screen.width/2&& acc.y * speed<Screen.height/2&& acc.x * speed>-Screen.width/2&& acc.y * speed>-Screen.height/2)
		rb.AddForce(acc.x * speed, acc.y * speed,0 );
		}
	//TODO:limits to the canvas


	}

