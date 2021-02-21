using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceShip : MonoBehaviour
{
    private Ship ship;
    void Start()
    {
        ship = GetComponent<Ship>();
    }

    void Update()
    {
        if (ship.getCanMove())
        {
            playerInput();
        }
    }
    public void playerInput()
    {
        //controle via mouse
        //transform.position = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20)), 0.1f);

        //Controle via touch
        transform.position = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 20)), 0.1f);
    }

    public void pauseInput()
    {
        if(ship.getCanMove()) {
            ship.setCanMove(false);
        } else
        {
            ship.setCanMove(true);
        }
    }

    public bool isInputPaused()
    {
        return ship.getCanMove();
    }

    public bool isAlive()
    {
        return ship.getIsAlive();
    }

    public void initiateNewGame()
    {
        ship.setIsAlive(true);
        ship.setCanMove(true);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            GameObject.Find("/AudioCollision").GetComponent<AudioSource>().Play();
            ship.setCanMove(false);
            StartCoroutine("die");
        }
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(1f);
        ship.setIsAlive(false);
    }
}
