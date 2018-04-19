using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_manager : MonoBehaviour {

	public GameObject emeny_small_0;
	public float emeny_small_0_starttime;
	public float emeny_small_0_rate;
	public GameObject emeny_mid_1;
	public float emeny_mid_1_starttime;
	public float emeny_mid_1_rate;
	public GameObject emeny_large_2;
	public float emeny_large_2_starttime;
	public float emeny_large_2_rate;
	public GameObject heart;
	public float heart_starttime;
	public float heart_rate;
	public GameObject Barrier;
	public float barrier_starttime;
	public float barrier_rate;
	public GameObject Coins;
	public float coins_starttime;
	public float coins_rate;
	public float maxX;
	public float minX;
	public float State=0;

	void Start () {
		if (emeny_small_0 != null) {
			InvokeRepeating ("Creatsmall", emeny_small_0_starttime, emeny_small_0_rate);
		}
		if (emeny_mid_1 != null) {
			InvokeRepeating ("Creatmid", emeny_mid_1_starttime, emeny_mid_1_rate);
		}
		if (emeny_large_2 != null) {
			InvokeRepeating ("Creatlarge", emeny_large_2_starttime, emeny_large_2_rate);
		}
		if (heart != null) {
			InvokeRepeating ("CreatHeart", heart_starttime, heart_rate);
		}
		if (Barrier != null) {
			InvokeRepeating ("CreatBarrier", barrier_starttime, barrier_rate);
		}
		if (Coins != null) {
			InvokeRepeating ("CreatCoin", coins_starttime, coins_rate);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Creatsmall()
	{
		Createmeny (maxX, minX, emeny_small_0,false);	
	}
	void Creatmid()
	{
		Createmeny (maxX, minX, emeny_mid_1,false);
	}
	void Creatlarge()
	{
		Createmeny (maxX, minX, emeny_large_2,false);
	}
	void CreatHeart()
	{
		Createmeny (maxX, minX, heart,false);
	}
	void CreatBarrier()
	{
		Createmeny (maxX, minX, Barrier,true);
	}
	void CreatCoin()
	{
		Createmeny (maxX, minX, Coins, true);
	}
	void Createmeny(float maxx,float minx,GameObject emeny,bool isBarrier)
	{
		if (State == 0) {
			if (isBarrier) {
				float[] xrange = { -1.2f, 0.0f, 1.2f };
				int dx = Random.Range (0, 3);
				GameObject.Instantiate (emeny, new Vector3 (xrange [dx], transform.position.y, 0), Quaternion.identity);
			} else {
				float dx = Random.Range (minx, maxx);
				GameObject.Instantiate (emeny, new Vector3 (dx, transform.position.y, 0), Quaternion.identity);
			}
		} else if (State == 1) {
			float dy = Random.Range (minx, maxx);
			GameObject.Instantiate (emeny, new Vector3 (transform.position.x, dy, 0), Quaternion.identity);
		}
			
	}
}
