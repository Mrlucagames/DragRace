using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

   public GameObject[] mounthPieces;
   public GameObject eyesOpen;
   public  GameObject eyesClosed;
    public float singSpeed;
	// Use this for initialization
	void Start () {
        StartCoroutine(Blink());
        StartCoroutine(Sing());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator  Blink() {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 3f));
            eyesClosed.SetActive(true);
            eyesOpen.SetActive(false);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.3f));
            eyesClosed.SetActive(false);
            eyesOpen.SetActive(true);
        }
    }

    IEnumerator Sing()
    {
        int n;
        while (true)
        {
            n = Random.Range(0, mounthPieces.Length);
            
            for (int i = 0; i < mounthPieces.Length; i++)
            {
                mounthPieces[i].SetActive(false); 
            }
            mounthPieces[n].SetActive(true);
            yield return new WaitForSeconds(singSpeed);

        }
    }
}
