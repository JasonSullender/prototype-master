using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {



		public void Reset()
		{
			Application.LoadLevel ("LevelOne");
		}
		
		public void ExitGame()
		{
		Application.LoadLevel ("Main Menu");
		}
	

}
