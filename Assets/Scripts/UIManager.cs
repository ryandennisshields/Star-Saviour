using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance; // Allows other scripts to use UIManager's code

    public GameObject gameOverscreen; // Stores the gameobject game over screen

    public GameObject pauseScreen; // Stores the pause screen

    public Text livesText; // Stores the life text

    public Slider healthBar; // Stores the health bar

    public Text scoreText; // Stores the score text

    public string mainMenuName = "Main Menu"; // Stores the main menu name, and names it Main Menu

    // Start is called before the first frame update
    void Start()
    {
        instance = this; // Allows other scripts to use UImanager's code
    
    } // End of start

    // Called when a scene needs to restart
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restarts the current scene
    
    } // End of restart

    // Called when the user wants to quit to main menu
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(mainMenuName); // Loads the main menu screen
   
    } // End of quittomainmenu
      
    // Called when the player un-pauses
    public void UnPause()
    {
        Time.timeScale = 1; // Sets the time scale to 1 (plays the game at normal speed)
        PlayerController.instance.enabled = true; // Enables the player
        pauseScreen.SetActive(false); // Disables the pause screen
    } // End of unpause
} // End of class

