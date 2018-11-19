﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {
    //HUD variables
    public Slider healthSlider;

    //calculat health variables
    public float fullHealth;
    float currentHealth;
    public GameObject deathFX;

    playerController controlMovement;
    public int levelBoundary; // [RC] Found to be -17 on the current level

    // Use this for initialization
    void Start () {
        currentHealth = fullHealth;
        controlMovement = GetComponent<playerController>();

        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

	}
	
	// Update is called once per frame
	void Update () {
        // [RC] Kill player if they go out of bounds
        if (gameObject.transform.transform.position.y <= levelBoundary && currentHealth > 0)
        {
            currentHealth = 0;
            makeCharacterDead();
        }
    }


    public void addDamage(float damage){
        if(damage<= 0){
            return;
        }
        currentHealth = currentHealth - damage;
        healthSlider.value = currentHealth;


        if(currentHealth <= 0 ){

            Debug.Log("In current health less then script");
            makeCharacterDead();


        }
    }

    public void makeCharacterDead(){
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        Debug.Log("In Make Dead");
    }
}
