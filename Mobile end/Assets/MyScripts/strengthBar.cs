using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class strengthBar : MonoBehaviour {

	Vector2 accelerationDir;
	public float currentStrength { get; set;}
	public float maxStrengh{ get; set;}
	public Slider strenghbar;
	public static int isWin;

	int Start()
	{
		maxStrengh = 20f;
		isWin = 0;
		currentStrength = maxStrengh;
		strenghbar.value = shakingStrength ();
		return isWin;
	}

	void Update()
	{
		accelerationDir = Input.acceleration;

		if (accelerationDir.sqrMagnitude > 30f) {
			hitTarget (5);
		}

		if (accelerationDir.sqrMagnitude <= 30f && accelerationDir.sqrMagnitude > 20f) {
			hitTarget (3);
		}

		if (accelerationDir.sqrMagnitude <= 20f && accelerationDir.sqrMagnitude > 10f) {
			hitTarget (2);
		}


	}

	void hitTarget(float hitValue)
	{
		currentStrength -= hitValue;
		strenghbar.value = shakingStrength ();
		if (currentStrength <= 0)
			win ();
	}

	float shakingStrength ()
	{
		return currentStrength / maxStrengh;
	}

	int win()
	{
		currentStrength = 0;
		isWin = 1;
		return isWin;
	}

	//Lack of the transition

}
