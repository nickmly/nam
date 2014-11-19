using UnityEngine;
using System.Collections;

public class BackGroundMusic : MonoBehaviour {

	public AudioClip backgroundmusic;

	// Use this for initialization
	IEnumerator Start () {
	
		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
		audio.clip = backgroundmusic;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	


	}
}
