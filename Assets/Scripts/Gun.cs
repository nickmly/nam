using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour 
{
	public Vector2 velocity;
	public Transform arm;
	public Movement player;

	private float timer = 30f;
	private bool collided = false;
	public Vector3 tempScale;

	public int ammo;
	public int maxAmmo;


	void Start()
	{
		tempScale = transform.localScale;
		arm = (Transform)GameObject.Find ("RightArm").GetComponent("Transform");
		player = (Movement)GameObject.Find ("Body").GetComponent("Movement");
	}

	public void Throw (bool isRight, float playerSpeed, Quaternion gunRot) 
	{
		if (ammo > 0) 
		{
			GameObject newGun = (GameObject)Instantiate (GameObject.Find (name));
			newGun.AddComponent ("BoxCollider2D");


			if (!isRight) 
			{
				newGun.transform.localScale = new Vector3 (-tempScale.x, -tempScale.y, tempScale.z);
			} 
			else 
			{
				newGun.transform.localScale = new Vector3 (-tempScale.x, tempScale.y, tempScale.z);
			}
			newGun.transform.rotation = gunRot;
			newGun.rigidbody2D.isKinematic = false;
			newGun.transform.position = transform.position;
			Vector3 sp = Camera.main.WorldToScreenPoint (newGun.transform.position); // get gun position in screen space (where the mouse is)
			Vector3 dir = (Input.mousePosition - sp).normalized; // the direction we want the gun to go is the mousePosition minus the gun position normalized
			newGun.rigidbody2D.AddForce (dir * (velocity.x + playerSpeed));// throw the gun in the direction specified with a speed plus the player's current speed
			newGun.rigidbody2D.AddTorque(Random.Range(50,150)); //rotate the gun randomly
			ammo -= 1;
			renderer.enabled = false;
		}
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if(!collided)
		{
			rigidbody2D.drag = 20;
			collided = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.R)) 
		{
			ammo = maxAmmo;
			if(!renderer.enabled)
			{
				renderer.enabled = true;
			}
		}

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
