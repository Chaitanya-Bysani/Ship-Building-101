using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creating a ship script for ship sprite
/// </summary>


public class Ship : MonoBehaviour

{
    [SerializeField]
    GameObject prefabBullet;
    
    //Thrust Component
    Rigidbody2D rb2d;
    Vector2 thrustDirection = new Vector2(1, 0);  // We're doing this so we don't have to create a new Vector2 every time we apply thrust to the ship.

    const float ThrustForce = 10f;

      
    // rotation of  spaceship
    const float RotateDegreesPerSecond = 180;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0)
        {

            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        
        {

            GameObject bullet = Instantiate(prefabBullet, transform.position, transform.rotation);
            bullet.GetComponent<Bullet>().ApplyForce(thrustDirection);
            AudioManager.Play(AudioClipName.PlayerShot);

        }
    }

    /// <summary>
    /// FixedUpdate where we add thrust if space is pressed
    /// </summary>
    void FixedUpdate()
    {

        if (Input.GetAxis("Thrust") != 0)
        {
            rb2d.AddForce(ThrustForce * thrustDirection, ForceMode2D.Force);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
            Destroy(gameObject);

    }
}

