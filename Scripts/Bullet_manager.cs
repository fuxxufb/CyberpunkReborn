using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BulletType
{
	EmenyBullet,
	PlayerBullet
}

public class Bullet_manager : MonoBehaviour {


	public float speed=20;
	public BulletType bulletType;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (bulletType == BulletType.PlayerBullet) 
		{
			//move bullet and if out of camera destroy it
			this.transform.Translate (Vector3.up * speed * Time.deltaTime);
			if (this.transform.position.y > 4.4) {
				Destroy (this.gameObject);
			}
		} else if (bulletType == BulletType.EmenyBullet) 
		{
			this.transform.Translate (Vector3.down * speed * Time.deltaTime);
			if (this.transform.position.y < -5.4) {
				Destroy (this.gameObject);
			}
		}
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		//bullet hit emeny
		if ((other.gameObject.tag == "emeny") && (bulletType == BulletType.PlayerBullet)) {
			other.gameObject.SendMessage ("Hit");
			Destroy (this.gameObject);
		} 
		//player hitted by bullet
		else if ((other.gameObject.tag == "plane") && (bulletType == BulletType.EmenyBullet)) {
			other.gameObject.SendMessage ("Hit");
			Destroy (this.gameObject);
		} else if ((other.gameObject.tag == "playerbullet") && (bulletType == BulletType.EmenyBullet)) {
			Destroy (this.gameObject);
		} else if ((other.gameObject.tag == "emenybollet") && (bulletType == BulletType.PlayerBullet)) {
			Destroy (this.gameObject);
		}
	}
}
