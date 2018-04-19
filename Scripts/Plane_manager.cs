using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Plane_manager : MonoBehaviour {

	private bool isMouseDown=false;
	private Vector3 lastMousePosition;
	//public float speed = 1.0f;
	//private Vector3
	public int life;
	private bool isDead=false;
	private bool isHit = false;
	private Vector3 ScreenArea;   
	private float screenXMin , screenXMax;  
	private float screenYMin , screenYMax;  
	Animator anim;
	public static Plane_manager _instance;
	public Image YouDied;
	void Start () {
		ScreenArea = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));

		screenXMin = -1.16f;  
		screenXMax = 1.16f;      
		screenYMin = -ScreenArea.y;     
		screenYMax = ScreenArea.y;      
		anim=this.GetComponent<Animator>();
		_instance = this;
		YouDied.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//----------------------------------------------cw1 method of HCI-------------------------------------------
		/*if (Input.GetMouseButtonDown(0)) {
			isMouseDown = true;
		}
		if (Input.GetMouseButtonUp(0))
		{
			isMouseDown = false;
			//lastMousePosition = Vector3.zero;
		}
		if (isMouseDown&&(!Game_manager.GameisPause)) {     
			Vector3 offset = Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position) - lastMousePosition;
			Debug.Log (Input.GetTouch (0).position);
			Vector3 newPosition = transform.position + offset;

			//float x = newPosition.x;

			//Mathf.Clamp (x, -1.0f, 1.0f);

			//Debug.Log (x);

			transform.position = newPosition;


			/*Vector2 mousePosition;
			mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);

			Vector2 destination = Vector2.MoveTowards (transform.position, mousePosition, speed);
			GetComponent<Rigidbody2D> ().MovePosition (destination);

			//边界检测，小位移还没写
		}
		//lastMousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);*/
		//----------------------------------------------------------------------------------------

		//----------------------------------------------cw2 method of HCI-------------------------------------------

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;


			// Move object across XY plane
			transform.Translate(touchDeltaPosition.x * 0.01f, touchDeltaPosition.y * 0.01f, 0);
		}

		CheckPosition ();
		Checklife ();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "emeny") {
			crash ();
		}
	}
	void Hit()
	{
		life--;
		isHit = true;
	}
	void Checklife()
	{
		if (life == 0) {
			isDead = true;
			Game_manager.GameisPause = true;
			GameObject[] emenybullet = GameObject.FindGameObjectsWithTag ("emenybollet");
			for (int i = 0; i < emenybullet.Length; i++) {
				Destroy (emenybullet [i]);
			}
			StartCoroutine (Delay());
			//Gameover._instance.nowscore = Game_manager.score;
			//SceneManager.LoadScene (2);
		}
	}
	void crash()
	{
		life = 0;
		YouDied.gameObject.SetActive (true);
	}
	//check if out of range
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
	IEnumerator Delay()
	{
		
		//anim
		anim.SetBool("Dead",true);
		yield return new WaitForSeconds(1.0f);

		Destroy (this.gameObject);
		Game_manager._instance.dead ();
		//showview
		//SceneManager.LoadSceneAsync(2);
	}


}
