using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour 
{
	public Vector2 velocity;
	public Transform arm;
	public Movement player;
	private BoxCollider box;
	private float timer = 30f;
	private bool collided = false;
	public Vector3 tempScale;
	public Movement moveSpeed;

	void Start()
	{
		tempScale = transform.localScale;
		arm = (Transform)GameObject.Find ("RightArm").GetComponent("Transform");
		player = (Movement)GameObject.Find ("Body").GetComponent("Movement");
	}

	public void Throw (bool isRight, float playerSpeed, Quaternion gunRot) 
	{
//		transform.parent.DetachChildren();
//

		GameObject newGun = (GameObject)Instantiate(GameObject.Find (name));
		newGun.AddComponent("BoxCollider");
		if(!isRight)
		{
			newGun.transform.localScale = new Vector3(-tempScale.x,-tempScale.y,tempScale.z);
		}
		else
		{
			newGun.transform.localScale = new Vector3(-tempScale.x,tempScale.y,tempScale.z);
		}
		newGun.transform.rotation = gunRot;
		newGun.rigidbody.isKinematic = false;
		newGun.transform.position = transform.position;
		Vector3 sp = Camera.main.WorldToScreenPoint(newGun.transform.position); // get gun position in screen space (where the mouse is)
		Vector3 dir = (Input.mousePosition - sp).normalized; // the direction we want the gun to go is the mousePosition minus the gun position normalized
		newGun.rigidbody.AddForce (dir * (velocity.x + playerSpeed));// throw the gun in the direction specified with a speed plus the player's current speed
		newGun.rigidbody.AddTorque (0, 0, velocity.x); //rotate the gun in relation to how hard the player throws it
	}

	void OnCollisionEnter(Collision col)
	{
		if(!collided)
		{
			collided = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (collided)
		{
			if(timer > 0f)
			{
				timer -= Time.deltaTime;
			}
			else
			{

				Destroy (gameObject);
			}
		}
	}
}
