using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform bg, bg1; // Stores the two background's positions
    private float scrollSpeed = 3f; // Changes the scroll speed of the background

    // Update is called once per frame
    void Update()
    {
        bg.position = new Vector2(bg.position.x - (scrollSpeed * Time.deltaTime), bg.position.y); // Constantly changes the position of the background to make it scroll
        bg1.position = new Vector2(bg1.position.x - (scrollSpeed * Time.deltaTime), bg1.position.y); // Ditto

        if (bg.position.x <= -35)
        { // If the first background's position is less than or equal to -35,
            bg.position = new Vector2(0, 0); // Set the background's position to 0
        }
        if (bg1.position.x <= 0)
        { // If the second background's position is less than or equal to 0,
            bg1.position = new Vector2(35, 0); // Set the background's position to 35
        }
    } // End of update

} // End of class
