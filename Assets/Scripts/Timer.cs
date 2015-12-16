/// <summary>
/// Written by Jason Sullender
/// This counts time up and displays on the screen
/// </summary>
using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	private float startTime=0;//Start at time zero
	private string currentTime;//What is time currently to show on screen
	public GUIText timerText;//where the time is displayed
	public GameObject player;//player game object
	// Use this for initialization
	void Start () {


	}
	/// <summary>
	/// We update and show time that is being counted up.
	/// </summary>
	// Update is called once per frame
	void Update () {
		startTime += Time.deltaTime;
		currentTime = startTime.ToString ();		
		timerText.text = ("Time: " + currentTime);
		if (player.activeInHierarchy == null) {
			startTime=Time.deltaTime;
			currentTime=startTime.ToString();
			timerText.text=("You died at: "+currentTime);
		}
	}

}
