using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	private float startTime=0;
	private string currentTime;
	public GUIText timerText;
	public GameObject player;
	// Use this for initialization
	void Start () {


	}
	
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
