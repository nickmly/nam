	
	private var mousePos : Vector2;
	private var screenPos : Vector3;
	public var offset : float;
	public var facingRight : boolean;
	
	function Update () 
	{
		
		mousePos = Input.mousePosition;
		screenPos = Camera.main.ScreenToWorldPoint(Vector3(mousePos.x, mousePos.y, transform.position.z - 
		                                                   Camera.main.transform.position.z));    	
		
		if(facingRight)
		{
			transform.rotation.eulerAngles.z = Mathf.Atan2(-(screenPos.y - transform.position.y),
		                                               (screenPos.x - transform.position.x))*Mathf.Rad2Deg - offset;
		}
		else
		{
			transform.rotation.eulerAngles.z = Mathf.Atan2((screenPos.y - transform.position.y),
		                                               (screenPos.x - transform.position.x))*Mathf.Rad2Deg - offset;
		}

		var v3 : Vector3 = Input.mousePosition;
		v3.z = 10.0f;
		v3 = Camera.main.ScreenToWorldPoint(v3);
		
		if(v3.x < transform.position.x)
		{
			var scale : Vector3 = transform.localScale;
			scale.x = -1f;
			scale.y = -1f;
			transform.localScale = scale;		
			facingRight = false;
		}
		else
		{
			scale = transform.localScale;
			scale.x = 1f;
			scale.y = 1f;
			transform.localScale = scale;
			facingRight = true;	   
		}   
		
	}