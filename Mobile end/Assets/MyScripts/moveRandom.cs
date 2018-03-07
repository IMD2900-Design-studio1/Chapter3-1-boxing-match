using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRandom : MonoBehaviour {

	public GameObject gameobject;
	//public float speed = 1.2f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3(0, 0, 0);
		gameobject.transform.Translate (Random.Range (.1f, .3f), Random.Range (0f, .2f), 0);
	}
}
