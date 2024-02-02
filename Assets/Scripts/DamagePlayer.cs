using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Called when a colliding with other
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") 
        { // If the other collider has the tag Player,
            HealthManager.instance.DamagePlayer(); // Damages the player using healthmanager
        }
    } // End of collisionenter2d

} // End of class
