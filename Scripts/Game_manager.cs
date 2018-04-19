using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_manager : MonoBehaviour {


	public Text ScoreText;
	public static Game_manager _instance;
	public int score;
	public static bool GameisPause=false;
	public string GameState;
	bool gamestop=false;
	private int currentscene;
	void Awake()
	{
		score = dataSave.score = 0;
	}
	void Start () {
		_instance = this;
		//if (dataSave != null) {
			score = dataSave.score;
		//}
		gamestop=false;
		GameisPause = false;
	}
	
	// Update is called once per frame
	void Update () {
		//score to text in UGUI
		if (ScoreText != null) {
			if (ScoreText.text != "Score" + score.ToString ()) {
				ScoreText.text = "Score" + score.ToString ();
			}
		}
		//get game state
		GameState = SceneManager.GetActiveScene ().name;

		//chect if finish and load scene
		if (GameState == "Level1" && score > 10) {
			SceneManager.LoadScene ("Level1-2");

		} else if (GameState == "Level2" && score > 30) {
			SceneManager.LoadScene ("Level2-3");
		} else if (GameState == "Level3" && score > 10) {
			SceneManager.LoadScene ("Level3-4");
		}

				
	}
	public void addscore(int sc)
	{
		score += sc;
		dataSave.score=score;
		if (ScoreText != null) {
			ScoreText.text = "Score:" + score.ToString ();
		}
		//boom_manager._instance.addCount ();
	}
	public void reStart()
	{
		SceneManager.LoadScene (1);
	}
	public void resume()
	{
		//loadscore-------------------
		dataSave.score=PlayerPrefs.GetInt ("HistoryHighScore", 0);
		SceneManager.LoadScene (1);
	}
	public void dead()
	{
		//save current index
		dataSave.currentscenenumber = SceneManager.GetActiveScene ().buildIndex;
		Debug.Log (dataSave.currentscenenumber);
		//show dead scene
		SceneManager.LoadScene ("Deadscene");
	}
	public void resummmme()
	{
		//load scene from save data
		SceneManager.LoadSceneAsync (dataSave.currentscenenumber);
	}
		


}
