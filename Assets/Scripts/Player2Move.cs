using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Move : MonoBehaviour
{
    public float moveSpeed = 5;
    public Vector3 orbitAxis;
    public int orbitDir = -1;
    public bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        orbitAxis.Set(0, orbitDir, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right"))
        {
            transform.RotateAround(Vector3.zero, orbitAxis, moveSpeed * Time.deltaTime);
        }

        if (isOpen == true)
        {
            if (Input.GetKey("down"))
            {
                float step = moveSpeed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, step);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "playerReverse")
        {
            orbitDir = -orbitDir;
            orbitAxis.Set(0, orbitDir, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "openDetector")
        {
            isOpen = true;
            print("open");
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "openDetector")
        {
            isOpen = false;
            print("not open");
        }
    }
}
