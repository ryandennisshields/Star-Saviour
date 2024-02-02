using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float moveSpeed = 2.5f; // Stores the move speed

    public Transform EnemyLaserFirePoint; // Stores the position of the enemy's firing point
    
    public GameObject EnemyShot; // Stores the enemy shot
    public GameObject enemyDestroy; // Stores the particle effect of the enemy explosion after being shot

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f); // Moves the enemy horizontally depending on the move speed
    
    } // End of update

    // Called when the ship becomes visible
    private void OnBecameVisible()
    {
        Instantiate(EnemyShot, EnemyLaserFirePoint.position, EnemyLaserFirePoint.rotation); // Fires a shot at the fire point's position
    
    } // End of becamevisible
    
    // Called when colliding with other
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") 
        { // If the other collider has the tag Player,
            HealthManager.instance.DamagePlayer(); // Damages the player
            Instantiate(enemyDestroy, transform.position, transform.rotation); // Creates the enemy destruction particle effect on the ship 
            Destroy(this.gameObject); // Removes the enemy ship
        
        }
    } // End of collisionenter2D


} // End of class