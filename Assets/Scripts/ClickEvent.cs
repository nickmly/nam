using UnityEngine;
using System.Collections;

public class ClickEvent : MonoBehaviour {

	public AudioClip Select;
	public AudioClip Click;
	
	public void startClicked () 
	{
		Application.LoadLevel("Scene");
		audio.Play();
	}
	
	public void quitClicked () 
	{
		Application.Quit();
		audio.Play();
	}
	
}
