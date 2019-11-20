using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdBehaviour : MonoBehaviour
{
    public GameObject RotationPoint;
    public float rotationSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(RotationPoint.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
