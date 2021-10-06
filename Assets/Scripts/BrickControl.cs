using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickControl : MonoBehaviour
{
    [SerializeField] public Material redMaterial;
    void Update()
    {
        if (gameObject.GetComponent<MeshRenderer>().sharedMaterial ==redMaterial) {
            Destroy(gameObject.GetComponent<BrickControl>());
            print("red");
            GameControl.brickSize++;
        }   
    }
}
