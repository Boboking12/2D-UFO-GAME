using UnityEngine;
using System.Collections;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float speed;				
	public Text countText;			
	public Text winText;			

	private Rigidbody2D rb2d;		
	private int count;				


	void Start()
	{
		
		rb2d = GetComponent<Rigidbody2D> ();
		
		count = 0;
		
		winText.text = "";
		
		SetCountText ();
	}

	
	void FixedUpdate()
	{	
		float moveHorizontal = Input.GetAxis ("Horizontal");

		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
	
		rb2d.AddForce (movement * speed);
	}

	
	void OnTriggerEnter2D(Collider2D other) 
	{
		
		if (other.gameObject.CompareTag ("PickUp")) 
		{		
			other.gameObject.SetActive(false);
						
			count = count + 1;
						
			SetCountText ();
		}
		

	}

	
	void SetCountText()
	{
		
		countText.text = "Keys Collected: " + count.ToString ();

		
		if (count >= 12)			
			winText.text = "You Escaped!";
	}
}
