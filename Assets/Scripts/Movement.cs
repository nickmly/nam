using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

	public Vector2 velocity;
	public float moveSpeed = 5f;
	public float jumpSpeed = 300f;
	public bool hasJumped = false;
	Animator anim;
	public bool isRunning = false;
	public bool facingRight = true;

	public Gun gun;		
	public Transform gunTransform;
	public bool canThrow = true;
	public string currentGun = "Pistol";
	private float gunTimer = 0.5f;
	public float throwTimer = 0.35f;
	public bool thrown = false;
		// Use this for initialization
		void Start ()
		{	
			gun = (Gun)GameObject.Find (currentGun).GetComponent("Gun");
			gunTransform = (Transform)GameObject.Find (currentGun).GetComponent("Transform");
			anim = GetComponent<Animator> ();
		}

		void Update ()
		{
			if (Input.GetKeyDown (KeyCode.Space) && !hasJumped) 
			{				
				hasJumped = true;
				rigidbody2D.AddForce (new Vector3 (0, jumpSpeed, 0));
			}
			anim.SetBool ("HasJumped", hasJumped);

			anim.SetBool ("isThrowing", Input.GetKeyDown (KeyCode.Mouse0));

			if (Input.GetKeyDown (KeyCode.Mouse0) && canThrow) 
			{				
				thrown = true;
				canThrow = false;
			}	

			if(!canThrow)
			{
				if (gunTimer > 0f)
				{
					gunTimer -= Time.deltaTime;
				}
				else
				{
					if(gun.ammo > 0)
					{
						gun.renderer.enabled = true;
					}
					gunTimer = 0.5f;
					canThrow = true;
				}
			}

			if (thrown) 
			{
				if(throwTimer > 0)
				{
					throwTimer -= Time.deltaTime;
				}
				else
				{
					gun.Throw (facingRight, velocity.x, gun.transform.rotation);
					throwTimer = 0.35f;
					thrown = false;
				}
			}

		}

//		public void GetNewGun()
//		{
//			if(!canThrow)
//			{			
//				GameObject newGun = (GameObject)Instantiate(GameObject.Find(name));
//				
//				gun = (Gun)newGun.GetComponent("Gun");
//				gunTransform = (Transform)newGun.GetComponent("Transform");
//				Destroy(newGun.GetComponent("BoxCollider"));			
//				
//				newGun.transform.parent = transform.GetChild(4).GetChild(0).GetChild(0);
//				newGun.rigidbody2D.isKinematic = true;
//				canThrow = true;
//			}
//		}

	// Update is called once per frame
		void FixedUpdate ()
		{
			velocity = rigidbody2D.velocity;
			velocity.x = (float)(Input.GetAxis ("Horizontal") * moveSpeed);
			rigidbody2D.velocity = velocity;

			if ((velocity.x > 0.1 || velocity.x < 0.1) && !isRunning) 
			{
				isRunning = true;
			}

			if (velocity.x == 0) 
			{
				isRunning = false;
			}

			anim.SetBool ("isRunning", isRunning);
			
			Vector3 v3 = Input.mousePosition;
			v3.z = 10.0f;
			v3 = Camera.main.ScreenToWorldPoint (v3);

			if (v3.x < rigidbody2D.position.x) 
			{
				Vector3 scale = transform.localScale;
				scale.x = 1f;
				transform.localScale = scale;
				facingRight = false;
			} 
			else 
			{
				Vector3 scale = transform.localScale;
				scale.x = -1f;
				transform.localScale = scale;
				facingRight = true;
			}
		}

		void OnCollisionEnter2D (Collision2D col)
		{			
			hasJumped = false;			
		}
}
