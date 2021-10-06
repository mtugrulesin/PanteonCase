using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    private Rigidbody r;
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 8 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StaticObstacle" || other.gameObject.tag == "HorizontalObstacle" || other.gameObject.tag == "Stick" || other.gameObject.tag == "DonutAbstacle") {
            transform.position = new Vector3(105.0f,0.0f,0.0f);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RotPlatform1" || collision.gameObject.tag == "RotPlatform3")
        {
            r.AddForce(-transform.right * 1000);

        }
        if (collision.gameObject.tag == "RotPlatform2")
        {
            r.AddForce(transform.right * 1000);
        }
        
    }
}
