using UnityEngine;
using System.Collections;

public class GUIGUN : MonoBehaviour {

	public Gun GUN;
	
	public Sprite Pistol;
	public Sprite AR;
	public Sprite RubberDuck;
	
	// Use this for initialization
	void Start () {
	
	GUN = (Gun)GameObject.Find ("GunPrefab").GetComponent("Gun");
	}
	
	// Update is called once per frame
	void Update () {

	
	
	}
}
