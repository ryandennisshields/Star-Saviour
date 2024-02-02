using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public static HealthManager instance; // Allows other scripts to use code from healthmanager
    
    public int currentHealth; // Stores the current health
    public int maxHealth; // Stores the maximum health
    public bool playerDamageable = true; // Stores a bool deciding if the player is damageable or not and sets it to true

    public AudioSource hitSound; // Stores the player hit sound

    public GameObject playerDeathEffect; // Stores the player's death effect

    // Awake is called when the program loads
    private void Awake()
    {
        instance = this; // Allows other scripts to use code from healthmanager

    } // End of Awake
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // Sets the current health to be the maximum health
        UIManager.instance.healthBar.maxValue = maxHealth; // Sets the health bar's maximum health value from UI manager to the max health value
        UIManager.instance.healthBar.value = currentHealth; // Sets the health bar's value from UI manager to the current health value

    } // End of start

    // Damageplayer is called when the player takes damage from a source
    public void DamagePlayer()
    {
        if (playerDamageable == true)
        { // If the player is damageable,
            currentHealth--; // Reduces the player's health
            hitSound.Play(); // Plays the hit sound
            StartCoroutine(InvulFrames()); // Runs the InvulFrames coroutine
            UIManager.instance.healthBar.value = currentHealth; // Shows the updated health value on the health bar from UI manager

            if (currentHealth <= 0) 
            { // If the player's health reaches 0,
                playerDamageable = false; // Makes the player unable to take damage
                Instantiate(playerDeathEffect, transform.position, transform.rotation); // Create a explosion effect on the player
                gameObject.SetActive(false); // Makes the player inactive
                GameManager.instance.KillPlayer(); // Calls the kill player function from game manager
            }
        }

    } // End of DamagePlayer

    // Respawn player is called when the player respawns
    public void RespawnPlayer()
    {
        gameObject.SetActive(true); // Makes the player actve
        currentHealth = maxHealth; // Sets the current health to the maximum health
        UIManager.instance.healthBar.value = currentHealth; // Changes the health bar from UI manager to match the current health

    } // End of Respawn Player Function

    // Called by damage player
    IEnumerator InvulFrames()
    {
        if (currentHealth > 0)
        { // If the player's health is greater than 0,
            playerDamageable = false; // Make the player unable to take damage
            yield return new WaitForSeconds(0.5f); // Wait for some time
            playerDamageable = true; // Make the player damageable again
        }
    } // End of InvulFrames

} // End of class
