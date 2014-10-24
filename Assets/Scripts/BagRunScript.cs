using UnityEngine;
using System.Collections;

public class BagRunScript : MonoBehaviour {

	public Animator anim;
	public bool Running;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	if(Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.A))
	{
	Running = true;
	}
	
	else
	{
	Running = false;
	}
	
	anim.SetBool ("isRunning", Running);
	
	}
}
