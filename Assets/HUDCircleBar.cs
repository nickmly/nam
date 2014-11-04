using UnityEngine;
using System.Collections;

public class HUDCircleBar : MonoBehaviour {

	public Gun gun;
	public double value;
	public double maxValue;
	Sprite circleFull;
	Sprite circle90;
	Sprite circle80;
	Sprite circle70;
	Sprite circle60;
	Sprite circle50;
	Sprite circle40;
	Sprite circle30;
	Sprite circle20;
	Sprite circle10;	
	
	void Start()
	{
		value = gun.ammo;
		maxValue = gun.maxAmmo;
		circleFull = Resources.Load<Sprite>("HUD/circlefull");
		circle90 = Resources.Load<Sprite>("HUD/circle90");
		circle80 = Resources.Load<Sprite>("HUD/circle80");
		circle70 = Resources.Load<Sprite>("HUD/circle70");
		circle60 = Resources.Load<Sprite>("HUD/circle60");
		circle50 = Resources.Load<Sprite>("HUD/circle50");
		circle40 = Resources.Load<Sprite>("HUD/circle40");
		circle30 = Resources.Load<Sprite>("HUD/circle30");
		circle20 = Resources.Load<Sprite>("HUD/circle20");
		circle10 = Resources.Load<Sprite>("HUD/circle10");		
	}
	
	void Update () 
	{
		value = gun.ammo;
		maxValue = gun.maxAmmo;
		if(value == maxValue)
		{
			GetComponent<SpriteRenderer>().sprite = circleFull;
		}
		if(value == (maxValue * 0.9))
		{
			GetComponent<SpriteRenderer>().sprite = circle90;
		}
		if(value == (maxValue * 0.8))
		{
			GetComponent<SpriteRenderer>().sprite = circle80;
		}
		if(value == (maxValue * 0.7))
		{
			GetComponent<SpriteRenderer>().sprite = circle70;
		}
		if(value == (maxValue * 0.6))
		{
			GetComponent<SpriteRenderer>().sprite = circle60;
		}
		if(value == (maxValue * 0.5))
		{
			GetComponent<SpriteRenderer>().sprite = circle50;
		}
		if(value == (maxValue * 0.4))
		{
			GetComponent<SpriteRenderer>().sprite = circle40;
		}
		if(value == (maxValue * 0.3))
		{
			GetComponent<SpriteRenderer>().sprite = circle30;
		}
		if(value == (maxValue * 0.2))
		{
			GetComponent<SpriteRenderer>().sprite = circle20;
		}
		if(value == (maxValue * 0.1))
		{
			GetComponent<SpriteRenderer>().sprite = circle10;
		}
		if(value <= 0)
		{
			renderer.enabled = false;
		}
		else
		{
			if(!renderer.enabled)
			{
				renderer.enabled = true;
			}
		}
	}
}
