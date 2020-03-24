using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 250f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotateY = Input.GetAxis("Mouse X");
        float rotateX = Input.GetAxis("Mouse Y");
        transform.Rotate(rotateX * speed * Time.deltaTime * (-1), rotateY * speed * Time.deltaTime, 0, Space.World);
    }
}
