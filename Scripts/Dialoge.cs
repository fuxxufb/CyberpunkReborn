using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialoge : MonoBehaviour {
	//public float speed = 0.5f;
	//private Vector3 ScreenArea;
	public Image Diaimage;
	public Sprite[] Diasprite;
	private int count=0;
	void Start () {
		Diaimage.sprite = Diasprite [0];
	}

	void Update () {
		
	}
	//click skip button
	public void Clickskip()
	{
		count++;
		if (count <= Diasprite.Length - 1) {
			Diaimage.sprite = Diasprite [count];

		} else if (SceneManager.GetActiveScene ().buildIndex < 7) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
		//skip to menu
		else if (SceneManager.GetActiveScene ().name == "Level3-4") {
			SceneManager.LoadScene (0);
		}
	}

}
