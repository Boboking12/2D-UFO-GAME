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
    private Vector3 movement;
    public GameObject door;
    public AudioSource audioSource;
    public AudioClip audio;

	void Start()
	{
		
		rb2d = GetComponent<Rigidbody2D> ();
		
		count = 0;
		
		winText.text = "";
		
		SetCountText ();
    }

	
	void FixedUpdate()
	{
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);

        //float moveHorizontal = Input.GetAxisRaw ("Horizontal");

		//float moveVertical = Input.GetAxisRaw ("Vertical");
		
		//Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
	
		//rb2d.AddForce (movement.normalized * speed);
        
	}

	void Move(float h, float v)
    {
        movement.Set(h, v, 0f);
        movement = movement.normalized * speed * Time.deltaTime;
        rb2d.MovePosition(transform.position + movement);
    }

	void OnTriggerEnter2D(Collider2D other) 
	{
		
		if (other.gameObject.CompareTag ("Keys")) 
		{		
			other.gameObject.SetActive(false);
						
			count = count + 1;
						
			SetCountText ();

            AudioSource.PlayClipAtPoint(audio, transform.position);
        }
		

	}

	
	void SetCountText()
	{
		
		countText.text = "Keys Collected: " + count.ToString ();


        if (count >= 3)
        {
            door.gameObject.SetActive(false);
        }
	}
}
