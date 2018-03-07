using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour {
	private Vector3 offset;
	public Transform cameraTransform;

	public Transform cubeTransform;

	void Start()
	{
		
		offset = cubeTransform.position - cameraTransform.position;
	}

	void Update()
	{


		cameraTransform.position = Vector3.Lerp(cameraTransform.position, cubeTransform.position - offset, Time.deltaTime * 5);
		Quaternion rotation = Quaternion.LookRotation(cubeTransform.position - cameraTransform.position);
		cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, rotation, Time.deltaTime * 3f);
	}
}
