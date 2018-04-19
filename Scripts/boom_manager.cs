using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boom_manager : MonoBehaviour {
 

	//--------the boom manager is only used for cw1, and has been thrown in cw2------------------------
	public static  boom_manager _instance;  
	public Sprite[] boom_button_sprites;
	public Button boom_button;
	private bool CanBoom=false;
	public int EmenyCount=0;
	public int EmenyRate;
	// Use this for initialization
	void Start () {
		_instance = this;  
		boom_button.image.sprite = boom_button_sprites [1];
	}

	public void addCount()
	{
		EmenyCount++;
	}
	void FixedUpdate()
	{
		if ((EmenyCount >= EmenyRate) && (!CanBoom)) {
			CanBoom = true;
		}
		if (!CanBoom&&(EmenyCount<EmenyRate)) {
			boom_button.image.sprite = boom_button_sprites [EmenyCount];
			//StartCoroutine (Delay ());
		} else if (CanBoom) {
			boom_button.image.sprite = boom_button_sprites [EmenyRate];
		}
	}

	public void ClickBoomButton()
	{
		if (CanBoom) 
		{
			
			CanBoom = false;
			EmenyCount = 0;
			boom_button.image.sprite = boom_button_sprites [0];
			this.BoomAction ();
		}
	}
	private void BoomAction()
	{
		GameObject[] emeny = GameObject.FindGameObjectsWithTag ("emeny");

		for (int i = 0; i < emeny.Length; i++) {
			emeny [i].SendMessage ("Boom");
		}
		GameObject[] emenybullet = GameObject.FindGameObjectsWithTag ("emenybollet");

		for (int i = 0; i < emenybullet.Length; i++) {
			Destroy (emenybullet [i]);
		}
	}


}
