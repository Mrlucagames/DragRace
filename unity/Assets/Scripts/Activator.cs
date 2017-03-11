using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Activator : MonoBehaviour {

	SpriteRenderer sr;
	public KeyCode key;
	bool active = false;
	GameObject note;
	Color old;
	KeyCode[] player1 = { KeyCode.A, KeyCode.S, KeyCode.D };
	KeyCode[] player2 = { KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.RightArrow };


	public bool createMode;
	public GameObject n;

	// Use this for initialization
	void Awake () {
		sr = GetComponent<SpriteRenderer> ();
	}

	void Start() {
		old = sr.color;
		PlayerPrefs.SetInt ("Score1", 0);
		PlayerPrefs.SetInt ("Score2", 0);
	}

	// Update is called once per frame
	void Update () {
		if (createMode && Input.GetKeyDown (key)) {
			if (Input.GetKeyDown (key)) {
				Instantiate (n, transform.position, Quaternion.identity);
			}
		} else {
			if (Input.GetKeyDown (key)) {
				StartCoroutine (Pressed ());
			}
			if (Input.GetKeyDown (key) && active) {
				Destroy (note);
				if (player1.Contains (key)) {
					AddScore ("Score1");
				} else if (player2.Contains (key)) {
					AddScore ("Score2");
				}
				active = false;
			}
		}


	}

	void OnTriggerEnter2D(Collider2D col)
	{
		active = true;
		if (col.gameObject.tag == "Note") {
			note = col.gameObject;
		}
			
	}

	void OnTriggerExit2D(Collider2D col)
	{
		active = false;
	}

	void AddScore(string player) {
		PlayerPrefs.SetInt (player, PlayerPrefs.GetInt (player) + 100);
	}

	IEnumerator Pressed () {
		sr.color = new Color (0, 0, 0);
		yield return new WaitForSeconds (0.1f);
		sr.color = old;

	}

}
