using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScene1 : MonoBehaviour {
	//player controller for Lv1

	private Vector2 swipeDelta, startTouch,targetPosition;
	private bool moveTemp=false;
	public Vector2[] Pos;
	public int SwipePos = 0;//0 stop 1 left 2 right
	private int target=1;
	public float speed=0.5f;
	Animator anim;
	public AudioSource getcoin;
	void Start () {
		target = 1;
		Debug.Log (this.transform.position);
		//this.transform.position = transform.TransformPoint(Pos[target]);
		//Pos[1]=transform.TransformPoint(this.transform.position);
		//Debug.Log (Pos[1]);
		anim = this.GetComponent<Animator> ();
		//for (int i=0;i<3;i++) {
		//	Pos [i] = transform.TransformPoint (Pos [i]);
		//}
		//transform.worldToLocalMatrix;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//touch controller
		swipeDelta = Vector2.zero;
		//if touch happen
		SwipePos=0;
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
		//confirm swipe
		if (swipeDelta.magnitude > 50) {
			if (swipeDelta.x < 0) {				//left or right
				SwipePos = 1;
			} else if (swipeDelta.x > 0) {
				SwipePos = 2;
			}
		}
		//left
		if (SwipePos == 1&&moveTemp) {
			if (target > 0) {
				target--;
				this.transform.Translate (Vector2.left * speed);
				moveTemp = false;
			}
		}
		//right
		if (SwipePos == 2&&moveTemp) {
			if (target < 2) {
				target++;
				this.transform.Translate (Vector2.right * speed);
				moveTemp = false;
			}
		}
		//this.transform.position = Pos [target];
					


	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "barrier") {
			//Game_manager._instance.addscore (1);
			StartCoroutine (boomshakalaka ());

			//anim.SetBool ("isDead", true);
			//Destroy (this.gameObject);
		} else if (other.gameObject.tag == "coin") {
			getcoin.Play ();
		}

	}
	IEnumerator boomshakalaka()
	{
		anim.SetBool ("isDead", true);
		//yield return new WaitForSeconds (1.0f);
		Destroy (this.gameObject);
		Game_manager._instance.dead ();
		yield break;

	}

}
