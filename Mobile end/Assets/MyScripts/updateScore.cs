using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class updateScore : MonoBehaviour {
	//public float range;
	//public Transform camTransform;
	public GameObject score;
	//public GameObject topStr;

	private int currScore = 0;
//	private float timeOffset;
//	private float originOffset = 5f;
//	private Vector3 origin;

	void OnEnable() {
		DBManager.TopScoreUpdated += UpdateTopScore;
	}

	void OnDisable() {
		DBManager.TopScoreUpdated -= UpdateTopScore;
	}

	void Start() {
//		timeOffset = 0f;
		SetScore ();
		//SetTarget ();
	}

	void Update () {
		// sinFactor oscillates between -2f and 2f
//		float sinFactor = Mathf.Sin (Time.time - timeOffset) * range;
//		transform.localPosition = origin + (transform.right * sinFactor); 
		addStrength();
	}

	private void UpdateTopScore() {
		//topStr.GetComponent<Text>().text = DBManager.Instance.topStrength.ToString ();
	}

//	// Reset the target position to be 5 meters in front of the camera
//	public void SetTarget() {
//		origin = camTransform.position + (camTransform.forward * originOffset);
//		transform.position = origin;
//		timeOffset = Time.time;
//		transform.LookAt (camTransform);
//	}

	// Detect scores
//	private void OnTriggerEnter(Collider col) {
//		currScore++;
//		DBManager.Instance.LogScore ((long)currScore);
//		SetScore ();
//	}
	private void addStrength(){
		if (strengthBar.isWin==1)
			currScore=1;//TODO:have to change to the counter++
		DBManager.Instance.LogScore ((long)currScore);
		SetScore ();
		
	}
	private void SetScore() {
		score.GetComponent<Text>().text = currScore.ToString();	
	}
}
