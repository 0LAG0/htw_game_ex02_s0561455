using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null)
        {
            StartCoroutine(LoadGameOver());
        }
	}

    IEnumerator LoadGameOver()
    {
         yield return new WaitForSeconds(2f);
         SceneManager.LoadScene(2);
    }
}
