using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMarker : MonoBehaviour
{
    private float moveSpeed = 2.5f; // Stores the move speed

    private string endLevelScreen = "End Level"; // Stores the end level scene

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f); // Makes the end marker move
    
    } // End of update

    // OnBecameInvisible is called when the object is no longer in camera view
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject); // Removes the marker
    
    } // End of onbecameinvisible

    private void OnTriggerEnter2D(Collider2D other) // When the marker collides with other
    {
        if (other.gameObject.tag == "Player") // Set the other to pick up a gameobject with the tag Player
        {
            SceneManager.LoadScene(endLevelScreen); // Loads the end of level scene
        }
    }

}
