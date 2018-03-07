using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multitouch : MonoBehaviour {


	void Update () 
	{
		Touch myTouch = Input.GetTouch(0);

		Touch[] myTouches = Input.touches;
		for(int i = 0; i < Input.touchCount; i++)
		{
			//Do something with the touches

		}
	}
}
