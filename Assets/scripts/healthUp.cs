using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthUp : MonoBehaviour {

    public float healthAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
            health.addHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
