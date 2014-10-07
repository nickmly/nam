using UnityEngine;
using System.Collections;

public class PlaceholderFollow : MonoBehaviour {

	public Transform bodyPart;
	
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = bodyPart.position;
		transform.rotation = bodyPart.rotation;
	}
}
