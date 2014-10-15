using UnityEngine;
using System.Collections;

public class ShirtChange : MonoBehaviour {


public Sprite sprite1;
public Sprite sprite2;

private SpriteRenderer spriteRenderer;
public Movement movement;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = sprite1; // set the sprite to sprite1
	}
	
	// Update is called once per frame
	void Update () {
	if(movement.facingRight == true)
	{
		changeTheDamnSprite();	
	}
	else
	{
	spriteRenderer.enabled = true;
	}
	}
	
	void changeTheDamnSprite()
	{
		spriteRenderer.enabled = false;
	}
}
