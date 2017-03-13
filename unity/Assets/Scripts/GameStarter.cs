using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour {
    public GameObject game;
    public PlayerController player1;
    public PlayerController player2;
    public AudioSource aud;
    public AudioSource winAud;
    private bool IsStarted = false;
    public AudioClip victory1;
    public AudioClip victory2;
    // Use this for initialization
    void Start () {
        StartCoroutine(playGame());
        winAud = GetComponent<AudioSource>();
    }

   
    public IEnumerator checkWin() {
        yield return new WaitForSeconds(70f);
        player1.ani.SetTrigger("Idle");
        player2.ani.SetTrigger("Idle");
        aud.Stop();
        if (PlayerPrefs.GetInt("Score1") > PlayerPrefs.GetInt("Score2"))
        {
            winAud.clip = victory1;
            winAud.Play();
            yield return new WaitForSeconds(17f);
            player1.ani.SetTrigger("Win");
         
        }
        if (PlayerPrefs.GetInt("Score1") < PlayerPrefs.GetInt("Score2"))
        {
            winAud.clip = victory2;
            winAud.Play();
            yield return new WaitForSeconds(17f);
            player2.ani.SetTrigger("Win");
        }
        if (PlayerPrefs.GetInt("Score1") == PlayerPrefs.GetInt("Score2"))
        {
            player1.ani.SetTrigger("Win");
            player2.ani.SetTrigger("Win");
        }
        PlayerPrefs.SetInt("Score1", 0);
        PlayerPrefs.SetInt("Score2", 0);

        IsStarted = false;
        game.SetActive(false);

    }
    public  IEnumerator playGame() {
        yield return new WaitForSeconds(3f);
        player1.ani.SetTrigger("Robot");
        player2.ani.SetTrigger("Samba");
        StartCoroutine(checkWin());
        game.SetActive(true);
        IsStarted = true;
    }
}
