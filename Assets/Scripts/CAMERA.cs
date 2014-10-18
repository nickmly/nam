using UnityEngine;
using System.Collections;

public class CAMERA : MonoBehaviour {

	public Transform target;
	public float trackSpeed =10;

	// Use this for initialization
	void Start () {
	
	}

	private float IncrementTowards(float n, float target, float a) 
	{
				if (n == target) {
						return n;
				} else {
						float dir = Mathf.Sign (target - n); // Must n be increased or decreased to get closer to target
						n += a * Time.deltaTime * dir;
						return (dir == Mathf.Sign (target - n)) ? n : target; // if n has now passed the target then return to target
				}
		}
/*	void LateUpdate () {
		if (target.transform.position.x > 50) 
		{
			Vector3 stophere = transform.position;
			stophere.x = 50;
			stophere.y = transform.position.y;
			stophere.z = -10;
			transform.position = stophere;
		} 
		if (target.transform.position.x < -60) 
		{
			Vector3 stopnow = transform.position;
			stopnow.x = (-60);
			stopnow.y = transform.position.y;
			stopnow.z = -10;
			transform.position = stopnow;
			/*Vector3 stoplol = transform.position;
			stoplol.x = -50;
			transform.position = stoplol;
		}
		if (target.transform.position.x < 50 || target.transform.position.x > -60) {
			if (target) {
				float x = IncrementTowards(transform.position.x, target.position.x, trackSpeed);
				float y = IncrementTowards(transform.position.y, target.position.y, trackSpeed);
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			}
		}
		
	}*/
	
	// Update is called once per frame
	void Update () 
	{

	
		Vector3 cam = transform.position;
		Vector3 player = target.transform.position;
		cam.x = player.x;
		cam.y = player.y;
		cam.z = -10;
		transform.position = cam;

		if (target.transform.position.x > 52) 
		{
			Vector3 stophere = transform.position;
			stophere.x = 52;
			stophere.y = transform.position.y;
			stophere.z = transform.position.z;
			transform.position = stophere;
		
		} 
		if (target.transform.position.x < -52) 
		{
			/*Vector3 stopnow = transform.position;
			stopnow.x = -37;
			stopnow.y = transform.position.y;
			stopnow.z = -10;
			transform.position = stopnow;*/
			Vector3 stoplol = transform.position;
			stoplol.x = -52;
			stoplol.y = transform.position.y;
			stoplol.z = transform.position.z;
			transform.position = stoplol;

		}
		if (target.transform.position.x < 52 || target.transform.position.x > -52) {
			if (target) {
				float x = IncrementTowards(transform.position.x, target.position.x, trackSpeed);
				float y = IncrementTowards(transform.position.y, target.position.y, trackSpeed);
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			}
		}
		else{
		}

	
	}


	}
