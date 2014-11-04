using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	public Movement player;
	public Gun gun;
	public GUIText ammoText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//ammoText.text = gun.ammo.ToString ();
	}

	void OnGUI()
	{

	}

}
