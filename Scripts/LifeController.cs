using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeController : MonoBehaviour {

	//haven't used in cw2
	// Use this for initialization
	public Image Life;
	public Sprite[] LifeSprite;
	void Start () {
		Life.sprite = LifeSprite [5];
	}
	
	// Update is called once per frame
	void Update () {
		if (Plane_manager._instance.life > 0) {
			Life.sprite = LifeSprite [Plane_manager._instance.life];
		}
	}
}
