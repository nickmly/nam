using UnityEngine;
using System.Collections;

public class ArmScriptThough : MonoBehaviour {

	public Movement movement;
	public Animator anim;

	// Use this for initialization
	void Start () {
	
		movement.GetComponent<Movement>();

	}
	
	// Update is called once per frame
	void Update () {
	
		anim.SetBool("isRunning", movement.isRunning);
		anim.SetBool("HasJumped", movement.hasJumped);

	}
}
