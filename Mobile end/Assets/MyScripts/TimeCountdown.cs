using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountdown : MonoBehaviour {

	float totalTime = 120f; //2 minutes
	public GameObject timer;
	private void Update()
	{
		totalTime -= Time.deltaTime;
		UpdateLevelTimer(totalTime );
	}

	public void UpdateLevelTimer(float totalSeconds)
	{
		int minutes = Mathf.FloorToInt(totalSeconds / 60f);
		int seconds = Mathf.RoundToInt(totalSeconds % 60f);

		string formatedSeconds = seconds.ToString();

		if (seconds == 60)
		{
			seconds = 0;
			minutes += 1;
		}
		timer.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00");
	}
}
