using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    private float shotSpeed = 7f; // Stores the shot speed

    public GameObject asteroidImpact; // Stores the asteroid impact particle gameobject
    public GameObject enemyDestroy; // Stores the enemy destroy particle gameobject

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(shotSpeed * Time.deltaTime, 0f, 0f); // Makes the laser move horizontally depending on shot speed
    
    } // End of update

    // Called when other hits an object with a trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Asteroid")
        { // If the other gameobject with the tag asteroid is triggered,
            Instantiate(asteroidImpact, other.transform.position, other.transform.rotation); // Creates the asteroid explosion effect on the asteroid
            Destroy(other.gameObject); // Destroys the asteroid
            Destroy(this.gameObject); // Destroys the laser
            GameManager.instance.AddScore(500); // Adds 500 score using gamemanager
        } 
        
        if (other.gameObject.tag == "Enemy")
        { // If the other gameobject with the tag enemy is triggered,
            Instantiate(enemyDestroy, other.transform.position, other.transform.rotation); // Creates the enemy explosion effect on the enemy
            Destroy(other.gameObject); // Destroys the enemy
            Destroy(this.gameObject); // Destroys the laser
            GameManager.instance.AddScore(1000); // Adds 1000 score using gamemanager
        }
    } // End of OnTriggerEnter

    // Called when object becomes invisible
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject); // Destroys the laser 
    
    } // End of becomeinvisible
} // End of class
