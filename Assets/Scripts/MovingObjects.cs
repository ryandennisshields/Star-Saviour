using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    private float moveSpeed = 2.5f; // Stores the move speed
    private float rotationSpeed; // Stores the rotation speed

    // Start is called on the first frame
    void Start()
    {
        rotationSpeed = Random.Range(-100, 100); // Randomly sets the rotation speed between -100 and 100
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f); // Moves the object horizontally depending on move speed
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime); // Rotates the object depnding on the rotation speed
    
    } // End of update
} // End of class
