using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour {

	//haven't be used in cw2
	public Text historyscore;
	public Text finalscore;
	public static Gameover _instance;
	public int nowscore;
	public void restart()
	{
		SceneManager.LoadScene (1);
		dataSave.score = 0;
		Game_manager.GameisPause = false;
	}

	void Awake()
	{
		_instance = this;
	}

	// Use this for initialization
	void Start () {		
		nowscore = dataSave.score;
		int historymaxscore = PlayerPrefs.GetInt ("HistoryHighScore", 0);
		if (nowscore > historymaxscore) {
			PlayerPrefs.SetInt ("HistoryHighScore", nowscore);
			historymaxscore = nowscore;
		}
		historyscore.text = historymaxscore.ToString ();
		finalscore.text = nowscore.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*public void ShowScore(int nowscore)
	{
		int historymaxscore = PlayerPrefs.GetInt ("HistoryHighScore", 0);
		if (nowscore > historymaxscore) {
			PlayerPrefs.SetInt ("HistoryHighScore", nowscore);
		}
		historyscore.text = historymaxscore.ToString ();
		finalscore.text = nowscore.ToString ();
	}*/




}
