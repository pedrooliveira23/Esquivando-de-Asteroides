using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptNave : MonoBehaviour
{
    public static float velocidade;
    void Update()
    {
        if (ScriptGameMaster.vivo && Mathf.Approximately(Time.timeScale, 1.0f)) { 
            velocidade = ScriptGameMaster.tempo*2f;
            movimentoDaNave();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "asteroide")
        {
            GameObject.Find("/AudioCollision").GetComponent<AudioSource>().Play();
            ScriptGameMaster.vivo = false;
        }
    }

    public void movimentoDaNave()
    {
        Vector3 pos = new Vector3();

        //pos = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20)), 0.1f);
        pos = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 20)), 0.1f);

        transform.position = pos;
    }
}
