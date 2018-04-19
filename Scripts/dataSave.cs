using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class dataSave : MonoBehaviour {

	public static int score;
	public static int currentscenenumber;
	// Use this for initialization

	// save the date between different scenes
	void Start () {
		GameObject.DontDestroyOnLoad (gameObject);


	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().buildIndex==1) {
		score = Game_manager._instance.score;
		}
	}
}
