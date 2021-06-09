using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Script for moving an asteroid in random direction.
/// </summary>
public class Asteroids : MonoBehaviour
{
    [SerializeField]
    Sprite GreenRock;

    [SerializeField]
    Sprite MagentaRock;

    [SerializeField]
    Sprite WhiteRock;

    float radius;
    Vector3 size;

    public Collider2D col;
    public ScreenWrapper screenLimit;

    private void Awake()
    {
        col = GetComponent<CircleCollider2D>();
        col.GetComponent<CircleCollider2D>().enabled = true;
        screenLimit = GetComponent<ScreenWrapper>();
        screenLimit.GetComponent<ScreenWrapper>().enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {


    }

   

    public void Initialize(Direction direction, Vector3 position)
    {
        

        this.transform.position = new Vector3(position.x, position.y, 0f);
        float angle;
        
        if (direction == Direction.Up)
        {
            angle = Random.Range(75 * Mathf.Deg2Rad, 105 * Mathf.Deg2Rad);
        }

        else if (direction == Direction.Left)
        {
            angle = Random.Range(165 * Mathf.Deg2Rad, 175 * Mathf.Deg2Rad);
        }

        else if (direction == Direction.Down)
        {
            angle = Random.Range(255 * Mathf.Deg2Rad, 285 * Mathf.Deg2Rad);
        }

        else
        {
            angle = Random.Range(-15 * Mathf.Deg2Rad, 15 * Mathf.Deg2Rad);
        }

        StartMoving(angle);

        //For choosing random asteroid from the three asterois color.
        SpriteRenderer rockSprite = GetComponent<SpriteRenderer>();
        int asteroidColor = Random.Range(0, 3);

        if (asteroidColor == 0)
        {
            rockSprite.sprite = GreenRock;
        }

        if (asteroidColor == 1)
        {
            rockSprite.sprite = MagentaRock;
        }

        if (asteroidColor == 2)
        {
            rockSprite.sprite = WhiteRock;
        }
    }

    //Created this method to provide impulse to big and small asteroids
    public void StartMoving(float tempAngle)
    {
        // apply impulse force to get game object moving
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;
        // float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 moveDirection = new Vector2(
     Mathf.Cos(tempAngle), Mathf.Sin(tempAngle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        size = new Vector3(transform.localScale.x / 1.5f, transform.localScale.y / 1.5f, transform.localScale.z);
        radius = GetComponent<CircleCollider2D>().radius / 2;

        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Destroy(this.gameObject);
        }
        if (size.x > 0.5f)
        {
            float angle = Random.Range(0f, 2f) * Mathf.PI;
            for (int i = 0; i < 2; i++)
            {
                GameObject asteroidClone = Instantiate(gameObject, transform.position, transform.rotation);
                asteroidClone.transform.localScale = size;
                asteroidClone.GetComponent<CircleCollider2D>().radius = radius;
                asteroidClone.GetComponent<Asteroids>().StartMoving(angle);
                asteroidClone.GetComponent<Asteroids>().col = asteroidClone.GetComponent<CircleCollider2D>();
                angle = Random.Range(0f, 2f) * Mathf.PI;
            }
            
        }
        Destroy(this.gameObject);
        AudioManager.Play(AudioClipName.AsteroidHit);
    }
        
        
       
    }



