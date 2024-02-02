using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance; // Allows other scripts to use code from PlayerController

    private float moveSpeed = 6; // Stores the move speed
    
    public Rigidbody2D rb2d; // Stores the rigid body of an object

    public Transform bottomBoundary, topBoundary; // Stores the position of the bottom and top boundaries

    public Transform laserFirePoint; // Stores the position of the fire point
    public GameObject laserShot; // Stores the laser gameobject
    public bool canFire = true; // Stores a bool that decides if the player can fire and sets it to true

    // Awake is called at the start of the program
    void Awake()
    {
        instance = this; // Allows other scripts to use code from PlayerController
    } // End of awake

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed; // Controls and allows the player to move using inputs (A and D allow left and right movement, W and S up and down movement)
        
        if (Input.GetButtonDown("Fire1"))
        { // If the player presses space or left click,
            if (canFire == true)
            { // If can fire is true,
                Instantiate(laserShot, laserFirePoint.position, laserFirePoint.rotation); // Fires a laser from the fire point
                StartCoroutine(FireDelay()); // Starts the FireDelay coroutine
            }

        }

    } // End of update

    // Called by pressing the fire button
    IEnumerator FireDelay()
    {
        canFire = false; // Sets can fire to false
        yield return new WaitForSeconds(0.2f); // Waits for a few seconds
        canFire = true; // Sets can fire to true
    }
} // End of Class
