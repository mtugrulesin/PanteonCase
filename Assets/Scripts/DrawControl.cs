using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawControl : MonoBehaviour
{

    [SerializeField] public GameObject[] bricks;
    private bool isRed = false;
    private int brickSize = 0;
    [SerializeField] public Material redMaterial;
    [SerializeField] public Camera wallCamera;
    private string brickName = "";
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved && !isRed)
        {
            
            Ray ray = wallCamera.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Brick")
            {

                hit.collider.GetComponent<MeshRenderer>().material = redMaterial;



            }


        }

        
    }
}
