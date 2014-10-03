using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour 
{
	public Vector2 velocity;
	public Transform player;

	public void Throw (bool isRight, float playerSpeed) 
	{
		Vector3 tempScale = transform.localScale;
		transform.parent.DetachChildren();

		if(!isRight)
		{
			transform.localScale = new Vector3(-tempScale.x,-tempScale.y,tempScale.z);
		}
		else
		{
			transform.localScale = new Vector3(-tempScale.x,tempScale.y,tempScale.z);
		}


		rigidbody.isKinematic = false;
		Vector3 sp = Camera.main.WorldToScreenPoint(transform.position); // get gun position in screen space (where the mouse is)
		Vector3 dir = (Input.mousePosition - sp).normalized; // the direction we want the gun to go is the mousePosition minus the gun position normalized
		rigidbody.AddForce (dir * (velocity.x + playerSpeed));// throw the gun in the direction specified with a speed plus the player's current speed

	/*	if(person="Likes dick")
		{
			
		person = gay;
		}
		else
		{
			person = stillgay;
		}*/
	}

	void OnCollisionEnter(Collision col)
	{
		Debug.Log("FUCK");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.rotation = Quaternion.identity;
		//transform.rotation = player.rotation;
	}
}
