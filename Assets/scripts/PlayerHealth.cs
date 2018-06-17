using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float fullHealth;
    float currentHealth;
    public GameObject deathfx;

    playerController cotrolMovement;

    // HUD
    public Slider healthSlider;


	// Use this for initialization
	void Start () {
        currentHealth = fullHealth-1;
        cotrolMovement = GetComponent<playerController>();

        // HUD
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;

        healthSlider.value = currentHealth;

        if(currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void addHealth(float health)
    {
        if(currentHealth != fullHealth)
        {
            currentHealth += health;
        }
       
        healthSlider.value = currentHealth;
    }

    public void makeDead()
    {
        Instantiate(deathfx, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
