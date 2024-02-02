using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Called whenever an object collides
    private void OnTriggerEnter2D(Collider2D other)
    { 
        Destroy(other.gameObject); // Destroy the other game object
    } // End of OnCollisionEnter
} // End of class
