using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRing : MonoBehaviour
{
    public float rotationSpeed = 10;
    private Vector3 rotAxis;
    public bool clockwise = true;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        if (clockwise)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        rotAxis.Set(0, direction, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotAxis * rotationSpeed * Time.deltaTime);

    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            direction = -direction;
            rotAxis.Set(0, direction, 0);
        }
    }
}
