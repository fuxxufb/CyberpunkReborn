using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_manager : MonoBehaviour {

	public GameObject bullet;
	public float shootrate = 0.2f;//射速
	// Use this for initialization
	public AudioSource Shootaudio;
	void Start () {
		openfire ();
	}

	void Update () {
		
	}
	void openfire()
	{
		InvokeRepeating ("Fire", 1, shootrate);
	}
	void Fire()
	{
		if (Shootaudio != null) {
			Shootaudio.Play ();
		}
		GameObject.Instantiate (bullet, transform.position, Quaternion.identity);
	}
}
