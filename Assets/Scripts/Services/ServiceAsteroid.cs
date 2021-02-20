using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceAsteroid : MonoBehaviour
{
    public static Asteroid asteroid;

    void Start()
    {
        asteroid = new Asteroid();
        initiateRandomRotation();
    }

    void Update()
    {
        initiateAcceleration();
        autoDestroyValidation();
    }

    public void initiateRandomRotation()
    {
        GetComponent<Rigidbody>().AddTorque(Random.Range(-1000, 1000), Random.Range(-1000, 1000), Random.Range(-1000, 1000));
    }

    public void initiateAcceleration()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(asteroid.getVelocity(), 0, 0);
    }

    public void autoDestroyValidation()
    {
        if (transform.position.x > 50)
        {
            Destroy(this.gameObject);
        }
    }

}
