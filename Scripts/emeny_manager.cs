using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Enemytype
{
	smallPlane,
	midPlane,
	largePlane,
	barrier,
	coins,
	support,
	boom
}

public class emeny_manager : MonoBehaviour {
	public float speed;
	public float life;
	public int score;
	private bool isDead = false;
	private bool isHit = false;
	public Enemytype planetype = Enemytype.smallPlane;
	Animator anim;
	public static emeny_manager _instance;

	private GameObject mtarget;
	Vector2 mlookdir;
	float angle,angletemp;
	const float epsilon = 0.01f;
	AudioSource emenydead;
	//public Button BoomButton;
	void Start () {
		// get gameobjects from prefabs
		anim = GetComponent<Animator> ();
		mtarget = GameObject.Find ("player");
		emenydead = GetComponent<AudioSource> ();
		_instance = this;
	}
	

	void Update () {
		
		if (Game_manager._instance.GameState == "Level1") {
			if (!Game_manager.GameisPause) {
				//move below
				transform.Translate (Vector3.down * speed * Time.deltaTime);
				//-----------------------
				if (transform.position.y <= -5.4) {
					Destroy (this.gameObject);
				}
				//overrange checking
				//checklife ();

			}

		} else if (Game_manager._instance.GameState == "Level2") {
			if (!Game_manager.GameisPause) {
				//move below
				transform.Translate (Vector3.down * speed * Time.deltaTime);
				//-----------------------
				if (transform.position.y <= -5.4) {
					Destroy (this.gameObject);
				}
				//overrange checking
				checklife ();

			}
		}
		else if (Game_manager._instance.GameState == "Level3") {
			//Debug.Log ("hello");
			Vector2 trs;//this pos to v2
			trs = new Vector2 (transform.position.x,transform.position.y);
			Vector2 targetpos = new Vector2 (mtarget.transform.position.x, mtarget.transform.position.y);
			//direct v2
			mlookdir = (targetpos - trs).normalized;

			transform.Translate (mlookdir * Time.deltaTime * speed);

			Debug.Log (targetpos-trs);

		}
		//skills is here -----------

	}
	void Boom()
	{
		//this.life = -1;
		isDead=true;
		StartCoroutine (DestroyPlane (4));
	}

	void Hit()
	{
		this.life--;
		//Debug.Log ("hello");
		this.isHit = true;
	}
	void checklife()
	{
		if (planetype == Enemytype.smallPlane) {
			if (life <= 0) {
				isDead = true;
				Game_manager._instance.addscore (score);
				//emenydead.Play ();
				Destroy (this.gameObject);
				//StartCoroutine (DestroyPlane (1));
			}
		} else if (planetype == Enemytype.midPlane) {
			if (life <= 0) {
				isDead = true;
				Game_manager._instance.addscore (score);
				//emenydead.Play ();
				Destroy (this.gameObject);
				//StartCoroutine (DestroyPlane (2));
			}
		} else if (planetype == Enemytype.largePlane) {
			if (life <= 0) {
				isDead = true;
				Game_manager._instance.addscore (score);
				//emenydead.Play ();
				Destroy (this.gameObject);
				//StartCoroutine (DestroyPlane (3));
			}
		}
	}
	IEnumerator DestroyPlane(int state)
	{
		if (state == 1) {
			//anim dead----------
			//anim.SetBool ("Dead", true);
			yield return new WaitForSeconds (0.2f);
			if (isDead) {
				Game_manager._instance.addscore (score);

				Destroy (this.gameObject);
			}
		} else if (state == 2) {
			//anim hit---------
			//anim.SetBool ("Dead", true);
			yield return new WaitForSeconds (0.3f);
			if (isDead) {
				Game_manager._instance.addscore (score);

				Destroy (this.gameObject);
			}

		} else if (state == 3) {
			//anim hitlarge------
			//anim.SetBool ("Dead", true);
			yield return new WaitForSeconds (0.3f);
			if (isDead) {
				Game_manager._instance.addscore (score);

				Destroy (this.gameObject);
			}
		} else if (state == 4) {
			//anim.SetBool ("Dead", true);
			yield return new WaitForSeconds (0);
			if (isDead) {
				//Game_manager._instance.addscore (score);

				Destroy (this.gameObject);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if ((this.gameObject.tag == "coin") && (other.gameObject.tag == "barrier")) {
			Destroy (this.gameObject);
		} else if ((this.gameObject.tag == "coin") && (other.gameObject.tag == "Player")) {
			Game_manager._instance.addscore (1);
			Destroy (this.gameObject);
		}
	}



}
