using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartOrHome : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            PlayerPrefs.SetInt("Score",0);
            SceneManager.LoadScene(1);
        }
        if (Input.GetKey(KeyCode.H))
        {
            SceneManager.LoadScene(0);
        }
    }
}
