using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
           
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
    }

}
