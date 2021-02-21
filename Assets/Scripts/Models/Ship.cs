using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private bool isAlive;
    private bool canMove;

    public Ship()
    {
        this.isAlive = true;
        this.canMove = true;
    }
    public void setIsAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }

    public bool getIsAlive()
    {
        return isAlive;
    }

    public void setCanMove(bool canMove)
    {
        this.canMove = canMove;
    }

    public bool getCanMove()
    {
        return canMove;
    }
}
