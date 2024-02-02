using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    private float shotSpeed = -7f; // Stores the speed of the laser (Set to negative so it goes left)

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(shotSpeed * Time.deltaTime, 0f, 0f); // Makes the laser move horizontally depending on the shot speed
    } // End of update

    // Called when hitting other if it has a trigger active
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        { // If the other game object has the tag Player,
            HealthManager.instance.DamagePlayer(); // Damages the player
            Destroy(this.gameObject); // Destroys the laser
        }
    } // End of ontriggerenter
} // End of class
