using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	
	public double health = 100;
	
	private bool thrown = false;

	public AudioClip acAR;
	public AudioClip acPistol;
	public AudioClip acHurt;
	public AudioClip acDead;
	public AudioClip acJump;
	public AudioClip acRun;
	
	
	private List<GameObject> audioObjects;
	private AudioClip[] audioClips;
		// Use this for initialization
		void Start ()
		{	
			//gun = (Gun)GameObject.Find (currentGun).GetComponent("Gun");
			//gunObject = GameObject.Find ("gunPrefab");
			//gunTransform = (Transform)GameObject.Find (currentGun).GetComponent("Transform");
			
			audioClips = new AudioClip[6] {acAR, acPistol, acHurt, acDead, acJump,acRun};
			audioObjects = new List<GameObject>();

			for(int i =0; i < audioClips.Length; i++)
			{			
				audioObjects.Add(new GameObject());							
				audioObjects[i].AddComponent("AudioSource");
				audioObjects[i].GetComponent<AudioSource>().clip = audioClips[i];				
			}
			
			anim = GetComponent<Animator> ();
		}

		void Update ()
		{


			if (Input.GetKeyDown (KeyCode.Space) && !hasJumped) 
			{				
				hasJumped = true;
				rigidbody2D.AddForce (new Vector3 (0, jumpSpeed, 0));			
				audioObjects[4].GetComponent<AudioSource>().Play();
			}
			anim.SetBool ("HasJumped", hasJumped);

			
		if(gunObject.GetComponent<Gun>().isAutomatic)
		{
			anim.SetBool ("AutoThrow", Input.GetKey (KeyCode.Mouse0));
			if (Input.GetKey (KeyCode.Mouse0) && canThrow) 
			{				
				thrown = true;
				canThrow = false;
				audioObjects[0].GetComponent<AudioSource>().Play();

			}	
		}
		else
		{
			anim.SetBool ("isThrowing", thrown);
			if (Input.GetKeyDown (KeyCode.Mouse0) && canThrow) 
			{
				thrown = true;
				canThrow = false;
				audioObjects[1].GetComponent<AudioSource>().Play();
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
				if(!hasJumped)
				{
					audioObjects[5].GetComponent<AudioSource>().loop = true;
					audioObjects[5].GetComponent<AudioSource>().Play();
				}
				else
				{
					if(audioObjects[5].GetComponent<AudioSource>().isPlaying)
					{
						audioObjects[5].GetComponent<AudioSource>().Pause();
					}
				}
			}

			if (velocity.x == 0) 
			{
				isRunning = false;
				if(audioObjects[5].GetComponent<AudioSource>().isPlaying)
				{
					audioObjects[5].GetComponent<AudioSource>().Pause();
				}
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
			
			for(int i =0; i < audioObjects.Count; i++)
			{			
				audioObjects[i].transform.position = transform.position;
			}
			
			
		}
		
		void OnCollisionStay2D(Collision2D col)
		{
		if(col.gameObject.tag == "Enemy")	
		{
			if(health > 1 && health != 10)
			{					
				audioObjects[2].GetComponent<AudioSource>().Play ();
				health -= 1;
			}
			
			else if(health >= 0)
			{				
				audioObjects[3].GetComponent<AudioSource>().Play ();
				health -= 1;
			}
			
		}
		}
		
		void OnCollisionEnter2D (Collision2D col)
		{			
			hasJumped = false;	 
		
		}
}
