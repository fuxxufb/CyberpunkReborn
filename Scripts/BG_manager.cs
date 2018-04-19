using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BG_manager : MonoBehaviour {
	public float speed = 0.5f;
	public Image Background;
	private Vector3 ScreenArea;
	private Vector3 BgArea;
	void Start () {

	}
		
	void Update () {
		//L1 bg move and change to the top
		if (Game_manager._instance.GameState == "Level1") {
			ScreenArea = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
			BgArea = Camera.main.ScreenToWorldPoint (Background.rectTransform.rect.size);
			this.transform.Translate (new Vector3 (0, -1, 0) * speed * Time.deltaTime);
			//Debug.Log (this.transform.position.y);
			if (this.transform.position.y <= -8.45f) {
				this.transform.position = new Vector3 (transform.position.x, 8.4f, transform.position.z);
			}
			//L2 bg move and change to the top
		} else if (Game_manager._instance.GameState == "Level2") {
			ScreenArea = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
			BgArea = Camera.main.ScreenToWorldPoint (Background.rectTransform.rect.size);
			//Debug.Log (BgArea);
			this.transform.Translate (new Vector3 (0, -1, 0) * speed * Time.deltaTime);
			//Debug.Log (this.transform.position.y);
			if (this.transform.position.y <= -13.8f) {
				this.transform.position = new Vector3 (transform.position.x, 12.6f, transform.position.z);
			}
		}
	}
}