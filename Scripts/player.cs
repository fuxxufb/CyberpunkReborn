using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class player : MonoBehaviour {

	//player controller for Lv3

	public static player instance;
	private CharacterController controller;
	private Rigidbody2D rb;
	public float speed = 1.0F;
	public Text test;
	private Vector2 swipeDelta, startTouch,targetPosition;
	private int direction=0;
	private bool moveTemp = false;
	private float angle,angletemp;
	private Vector3 ScreenArea;   
	private float screenXMin , screenXMax;  
	private float screenYMin , screenYMax;
	Animator anim;
	public AudioSource hitsound;
	void Awake()
	{
		instance = this;
		rb = GetComponent<Rigidbody2D> ();
	}

		
	void Start()
	{
		ScreenArea = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));

		screenXMin = -ScreenArea.x;  
		screenXMax = ScreenArea.x;      
		screenYMin = -ScreenArea.y;     
		screenYMax = ScreenArea.y;  
		anim = this.GetComponent<Animator> ();
	}
	void FixedUpdate ()
	{

		swipeDelta = Vector2.zero;
		//if touch happen
		if (Input.touches.Length != 0) 
		{
			switch (Input.touches [0].phase) 
			{
			case TouchPhase.Began:
				
				startTouch = Input.touches[0].position;
				break;
			case TouchPhase.Ended:
				//Debug.Log ("hello");
				startTouch= swipeDelta = Vector2.zero;
				moveTemp = true;
				break;
			case TouchPhase.Canceled:
				startTouch= swipeDelta = Vector2.zero;
				break;
			}
		}
		if (startTouch != Vector2.zero) 
		{
			if (Input.touches.Length != 0) 
			{
				swipeDelta = Input.touches [0].position - startTouch;
				targetPosition = Input.touches [0].position;

			}
		}
		// if confirm swipe && finger leave
		if (swipeDelta.magnitude>100&& moveTemp) {
			StartCoroutine (hit ());
			rb.AddForce (swipeDelta);
			angle = Mathf.Atan2 (swipeDelta.x, swipeDelta.y);
			angle = 180 / Mathf.PI * angle;
			this.transform.Rotate (new Vector3 (0, 0, angletemp));
			this.transform.Rotate(new Vector3(0,0,-angle));
			angletemp = angle;
			moveTemp = false;

		}
		CheckPosition ();

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "emeny_3") {
			if (rb.velocity.magnitude != 0) {
				
				other.gameObject.SendMessage ("Boom");
				Game_manager._instance.addscore (1);
			} else if (rb.velocity.magnitude == 0) {
				Destroy (this.gameObject);
				Game_manager._instance.dead ();

			}
		}
	}
	IEnumerator hit()
	{
		anim.SetBool ("isDead", true);
		hitsound.Play ();
		yield return new WaitForSeconds (0.2f);
		anim.SetBool ("isDead", false);
	}
	//out of range
	void CheckPosition()    
	{
		Vector3 pos = transform.position;
		float x = pos.x;
		float y = pos.y;
		x = x < screenXMin ? screenXMin : x;    
		x = x > screenXMax ? screenXMax : x;    
		y = y < screenYMin ? screenYMin : y;    
		y = y > screenYMax ? screenYMax : y;    
		transform.position = new Vector3(x, y, 0);  
		//Debug.Log(ScreenArea.x);
	}
}












		//if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		//{
			// Get movement of the finger since last frame
			//Vector2 pos=Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
		//Vector2 pos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//transform.position= new Vector3(pos.x, pos.y, 0);
		//Touch[] touches;
		//touches=Input.touches;
		//Debug.Log (touches.Length);
		//if (touches.Length > 0) {
		/*if (Input.touchCount>0)
		{
			Touch touch = Input.GetTouch (0);
			switch (touch.phase) {
			case TouchPhase.Began:
				test.text = "2";
				//test.text = Input.GetTouch (0).tapCount.ToString ();
				break;
			case TouchPhase.Moved:
				test.text = "1";
				break;
			case TouchPhase.Stationary:
				//test.text = Input.GetTouch (0).tapCount.ToString ();
				test.text="0";
				break;
			}
		//}
		}*/

		//}




