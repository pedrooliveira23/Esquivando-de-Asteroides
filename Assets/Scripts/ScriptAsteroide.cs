using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAsteroide : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(ScriptNave.velocidade, 0, 0);
        rb.AddTorque(Random.Range(-1000, 1000), Random.Range(-1000, 1000), Random.Range(-1000, 1000));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 50){
            Destroy(this.gameObject);
        }
        rb.velocity = new Vector3(ScriptNave.velocidade, 0, 0);
    }
}
