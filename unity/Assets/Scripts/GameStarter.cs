using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour {
    public GameObject game;
    public PlayerController player1;
    public PlayerController player2;
    public AudioSource aud;
    private bool IsStarted = false;
    AudioClip victory;
    // Use this for initialization
    void Start () {
        StartCoroutine(playGame());
    }

    private void Update()
    {
        if(!aud.isPlaying && IsStarted)
        {

            checkWin();
        }
    }
    public void checkWin() {
        if (PlayerPrefs.GetInt("Score1") > PlayerPrefs.GetInt("Score2"))
        {
            player1.ani.SetTrigger("Win");
        }
        if (PlayerPrefs.GetInt("Score1") < PlayerPrefs.GetInt("Score2"))
        {
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
        yield return new WaitForSeconds(2.5f);
        player1.ani.SetTrigger("Robot");
        player2.ani.SetTrigger("Samba");
        game.SetActive(true);
        IsStarted = true;
    }
}
