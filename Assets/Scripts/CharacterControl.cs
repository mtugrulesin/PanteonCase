using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Touch touch;
    private bool left;
    private bool right;
    [SerializeField] private float lerpValue;
    public GameObject camChar;
    public GameObject camWall;
    private float characterSpeed = 8.0f;
    public Rigidbody r;

    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0, characterSpeed * Time.deltaTime);
        Vector3 getRight = new Vector3(transform.position.x, transform.position.y, 1.8f);
        Vector3 getLeft = new Vector3(transform.position.x, transform.position.y, -1.8f);
        if (Input.touchCount > 0) {

            touch = Input.GetTouch(0);
            if (touch.deltaPosition.x > 25.0f)
            {
                right = true;
                left = false;
            }
            if (touch.deltaPosition.x < -25.0f)
            {
                right = false;
                left = true;
            }

            if (right == true)
            {
                transform.position = Vector3.Lerp(transform.position, getRight, lerpValue * Time.deltaTime * 2);
            }
            if (left == true)
            {
                transform.position = Vector3.Lerp(transform.position, getLeft, lerpValue * Time.deltaTime * 2);
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WhiteWall") {
            camChar.SetActive(false);
            camWall.SetActive(true);
            Destroy(gameObject);
            other.gameObject.tag = "Brick";
            if (GameControl.runnerSequence != 1) {
                GameControl.gameState = false;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RotPlatform1" || collision.gameObject.tag == "RotPlatform3")
        {
            r.AddForce(-transform.right * 1000);
            
        }
        if (collision.gameObject.tag == "RotPlatform2") {
            r.AddForce(transform.right * 1000);
        }
        if (collision.gameObject.tag == "Plane") {

            transform.position = new Vector3(99.0f, 0.0f, 0.0f);
        }
    }
}
