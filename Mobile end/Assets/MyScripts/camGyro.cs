﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camGyro: MonoBehaviour {
	GameObject camParent;

	// Use this for initialization
	void Start () {
		camParent=new GameObject("CamParent");
		camParent.transform.position = this.transform.position;
		this.transform.parent = camParent.transform;
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		camParent.transform.Rotate (0, -Input.gyro.rotationRateUnbiased.y, 0);
		this.transform.Rotate (-Input.gyro.rotationRateUnbiased, 0, 0);
	}
}
