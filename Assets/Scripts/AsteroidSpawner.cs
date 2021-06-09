using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for asteroid spawning
/// </summary>
public class AsteroidSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject prefabAsteroid;

    float radius;
    
    // Instantiating a asteroid.
    void AsteroidInitialize()
    {
        GameObject asteroid = Instantiate<GameObject>(prefabAsteroid);
        asteroid.GetComponent<Asteroids>().Initialize(Direction.Right, this.transform.position);
        radius = asteroid.GetComponent<CircleCollider2D>().radius;
        Destroy(asteroid);
    }
    
    // Start is called before the first frame update
    void Start()
    {

        

        AsteroidInitialize();
        GameObject left = Instantiate(prefabAsteroid);
        left.GetComponent<Asteroids>().Initialize(Direction.Left, new Vector2(ScreenUtils.ScreenRight - radius, (ScreenUtils.ScreenTop + ScreenUtils.ScreenBottom) / 2));
        GameObject right = Instantiate(prefabAsteroid);
        right.GetComponent<Asteroids>().Initialize(Direction.Right, new Vector2(ScreenUtils.ScreenLeft + radius, (ScreenUtils.ScreenTop + ScreenUtils.ScreenBottom) / 2));
        GameObject bottom = Instantiate(prefabAsteroid);
        bottom.GetComponent<Asteroids>().Initialize(Direction.Down, new Vector2((ScreenUtils.ScreenRight + ScreenUtils.ScreenLeft) / 2, ScreenUtils.ScreenTop - radius));
        GameObject top = Instantiate(prefabAsteroid);
        top.GetComponent<Asteroids>().Initialize(Direction.Up, new Vector2((ScreenUtils.ScreenRight + ScreenUtils.ScreenLeft) / 2, ScreenUtils.ScreenBottom + radius));

    }

    // Update is called once per frame
   
}
