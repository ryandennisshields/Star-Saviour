using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifetime; // Stores the lifetime 

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime); // Destroys the gameobject depending on the lifetime
    
    } // End of update

} // End of class
