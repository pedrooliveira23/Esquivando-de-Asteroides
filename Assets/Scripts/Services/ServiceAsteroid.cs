using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceAsteroid : MonoBehaviour
{

    void Start()
    {
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
        GetComponent<Rigidbody>().velocity = new Vector3(Asteroid.velocity, 0, 0);
    }

    public void autoDestroyValidation()
    {
        if (transform.position.x > 50)
        {
            Destroy(this.gameObject);
        }
    }

    public void updateVelocity(int velocity)
    {
        Asteroid.velocity = velocity;
    }

}
