using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; // Allows other scripts to use code from this script

    public int currentLives = 3; // Stores the current lives

    public float playerRespawnTime = 2f; // Stores the player's respawn time

    public int currentScore; // Stores the current score

    // Awake is called when the program loads
    void Awake()
    {
        instance = this; // Creates an instance of gamemanager, allowing other scripts to use it
    
    } // End of awake

    // Start is called on the first frame
    void Start()
    {
        Time.timeScale = 1; // Sets the time scale to 1 (plays the game at normal speed)b
        UIManager.instance.livesText.text = "x " + currentLives; // Displays the current lives from the UI manager
        UIManager.instance.scoreText.text = "" + currentScore; // Displays the current score from the UI manager
    } // End of start

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        { // If the player presses the ESC key,
            if (currentLives > 0)
            { // If current lives are greater than 0,
                PauseGame(); // Run the Pause Game function
            }
        }
    } // End of update

    // Called whenever the player presses the ESC key
    public void PauseGame()
    {
        Time.timeScale = 0; // Sets the time scale to 0 (freezes the game)
        PlayerController.instance.enabled = false; // Disables the player, making them unable to do anything
        UIManager.instance.pauseScreen.SetActive(true); // Enables the pause screen
    } // End of pausegame

    // Called when the player loses all health
    public void KillPlayer()
    {
        currentLives--; // Removes a life
        UIManager.instance.livesText.text = "x " + currentLives; // Re-displays the lives after one is lost

        if (currentLives > 0)
        { // If current lives is greater than 0,
            StartCoroutine(RespawnPlayerCor()); // Respawns the player
        }
        else 
        { // If lives are not greater than 0,
            UIManager.instance.gameOverscreen.SetActive(true); // Displays the game over screen
            Time.timeScale = 0; // Sets the time scale to 0 (freezes the game)
        }
    
    } // End of Kill Player function

    // The coroutine for respawning the player
    public IEnumerator RespawnPlayerCor()
    {
        yield return new WaitForSeconds(playerRespawnTime); // Waits for a few seconds depending on respawn time variable
        HealthManager.instance.RespawnPlayer(); // Respawns the player using the health manager
        PlayerController.instance.canFire = true; // Makes the player able to fire again
        yield return new WaitForSeconds(2); // When the player is active, wait a few more seconds
        HealthManager.instance.playerDamageable = true; // Make the player damageable again
    
    } // End of respawnplayer

    // The coroutine for adding score
    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd; // Adds on the score to the current score
        UIManager.instance.scoreText.text = "" + currentScore; // Displays the current score after being updated

    } // End of addscore

} // End of class
