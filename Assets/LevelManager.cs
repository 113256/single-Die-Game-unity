using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void loadLevel(string name)
	{
		Debug.Log("level load requested for"+ name);
		Application.LoadLevel(name);
	}
	
	public void quitRequest()
	{
		print("I want to quit!");//print = debug.log
		Application.Quit();
	}
}
