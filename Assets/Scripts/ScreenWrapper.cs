using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for creating ScreenWrapping for rocks and ship
/// </summary>
public class ScreenWrapper : MonoBehaviour
{
    //Radius of collider will be used n screen wrapping , hence creating a field to store it. 
    float colliderRadius;
    
    
    // Start is called before the first frame update
    void Start()
    {
        colliderRadius = GetComponent<CircleCollider2D>().radius;
    }

    /// <summary>
    /// Screen wrapping of ship and asteroid.
    /// </summary>
    void OnBecameInvisible()
    {

        Vector2 position = transform.position;

        // check left, right, top, and bottom sides


        if (position.x + colliderRadius < ScreenUtils.ScreenLeft ||
            position.x - colliderRadius > ScreenUtils.ScreenRight)
        {
            position.x *= -1;
        }
        if (position.y - colliderRadius > ScreenUtils.ScreenTop ||
            position.y + colliderRadius < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }

        // move ship
        transform.position = position;
    }

}
