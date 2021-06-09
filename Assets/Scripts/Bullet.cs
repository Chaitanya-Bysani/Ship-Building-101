using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bullet class
/// </summary>
public class Bullet : MonoBehaviour
{
    const int BulletLife = 2;
    Timer time;
     void Awake()
    {
        time = gameObject.AddComponent<Timer>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        time.Duration = BulletLife;
        time.Run();
    }

    // Update is called once per frame
    void Update()
    {
        //Timer time = GetComponent<Timer>();
        if (time.Finished)
            Destroy(this.gameObject);
    }
    
    /// <summary>
    /// For direction of the bullet
    /// </summary>
    /// <param name="direction"></param>
    public void ApplyForce(Vector2 direction)
    {
        const float magnitude = 40f;

        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(magnitude * direction, ForceMode2D.Impulse);

    }


}
