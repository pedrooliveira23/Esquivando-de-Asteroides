using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid
{
    private int velocity;

    public Asteroid()
    {
        velocity = 20;
    }

    public int getVelocity() { return velocity; }
    public void setVelocity(int velocity) { this.velocity = velocity; }
}
