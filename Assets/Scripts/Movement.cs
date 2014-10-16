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

	//public Gun gun;		
	public GameObject gunObject;
	public Transform gunTransform;
	public bool canThrow = true;
	//public string currentGun = "Pistol";
	
	
	private bool thrown = false;
	
	
		// Use this for initialization
		void Start ()
		{	
			//gun = (Gun)GameObject.Find (currentGun).GetComponent("Gun");
			//gunObject = GameObject.Find ("gunPrefab");
			//gunTransform = (Transform)GameObject.Find (currentGun).GetComponent("Transform");
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

			
		if(gunObject.GetComponent<Gun>().isAutomatic)
		{
			anim.SetBool ("AutoThrow", Input.GetKey(KeyCode.Mouse0));
			if (Input.GetKey (KeyCode.Mouse0) && canThrow) 
			{				
				thrown = true;
				canThrow = false;
			}	
		}
		else
		{
			anim.SetBool ("isThrowing", Input.GetKeyDown (KeyCode.Mouse0));
			if (Input.GetKeyDown (KeyCode.Mouse0) && canThrow) 
			{				
				thrown = true;
				canThrow = false;
			}	
		}

			if(!canThrow)
			{
				if (gunObject.GetComponent<Gun>().fireRate > 0f)
				{
					gunObject.GetComponent<Gun>().fireRate -= Time.deltaTime;
				}
				else
				{
					if(gunObject.GetComponent<Gun>().ammo > 0)
					{
						gunObject.renderer.enabled = true;
					}
					gunObject.GetComponent<Gun>().fireRate = gunObject.GetComponent<Gun>().maxFireRate;
					canThrow = true;
				}
			}

			if (thrown) 
			{
				if(gunObject.GetComponent<Gun>().throwTimer > 0)
				{
					gunObject.GetComponent<Gun>().throwTimer -= Time.deltaTime;
				}
				else
				{
					gunObject.GetComponent<Gun>().Throw (facingRight, velocity.x, gunObject.transform.rotation);
					gunObject.GetComponent<Gun>().throwTimer = gunObject.GetComponent<Gun>().maxThrowTime;
					thrown = false;
				}
			}

		}
	
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
