using UnityEngine;
using System.Collections;

public class ClickEvent : MonoBehaviour {

	
	
	public void startClicked () 
	{
		Application.LoadLevel("Scene");
	}
	
	public void quitClicked () 
	{
		Application.Quit();
	}
	
}
