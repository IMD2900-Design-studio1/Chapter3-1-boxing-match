using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class DBManager: MonoBehaviour {
	public static DBManager Instance;
	public long topStrength = 0;
	public long topAccuracy=0;
	public long topSpeed=0;

	public delegate void ScoreAction ();
	public static event ScoreAction TopScoreUpdated;

	private DatabaseReference db;
	private long curStrength = 0;


	void Awake() {
		if (Instance == null) Instance = this;

		// Set this before calling into the realtime database.
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://imd2900a.firebaseio.com/");

		// Get the root reference location of the database, from which we will operate on the database.
		db = FirebaseDatabase.DefaultInstance.GetReference("Chapter3");

		// Get top score, listen for changes.
		GetTopScore ();
		db.ValueChanged += HandleTopScoreChange;
	}

	private void GetTopScore() {
		db.GetValueAsync().ContinueWith(task => {
			if (task.IsFaulted) {
				// ERROR HANDLER
			}
			else if (task.IsCompleted) {
				Dictionary<string, object> results = (Dictionary<string, object>) task.Result.Value;
				topStrength = (long) results["strength"];
			}
		});
	}

	public void LogScore(long s) {
		curStrength = s;
		if (curStrength > topStrength) {
			db.RunTransaction (UpdateTopScore);
		}
	}

	private TransactionResult UpdateTopScore(MutableData md) {
		if (md.Value != null) {
			Dictionary<string,object> updatedScore = md.Value as Dictionary<string,object>;
			topStrength = (long) updatedScore ["strength"];
		}

		// Compare the cur score to the top score.
		if (curStrength > topStrength) { // Update topScore, triggers other UpdateTopScores to retry
			topStrength = curStrength;
			md.Value = new Dictionary<string,object>(){{"strength", curStrength}};
			return TransactionResult.Success(md);
		}
		return TransactionResult.Abort (); // Aborts the transaction
	}

	void HandleTopScoreChange(object sender, ValueChangedEventArgs args) {
		Dictionary<string,object> update = (Dictionary<string,object>)args.Snapshot.Value;
		topStrength = (long) update["topScore"];
		Debug.Log ("New Top Score: " + topStrength);
		if (TopScoreUpdated != null) TopScoreUpdated ();
	}
}
