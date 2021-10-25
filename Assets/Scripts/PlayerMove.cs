using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10;
    Vector3 orbitAxis;
    int orbitDir = -1;
    bool isOpen = false; 
      
    // Start is called before the first frame update
    void Start()
    {
        orbitAxis.Set(0, orbitDir, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //check if player 1 or 2
        if (gameObject.tag == "Player1")
        {
            //move sideways
            if (Input.GetKey("a"))
            {
                transform.RotateAround(Vector3.zero, orbitAxis, moveSpeed * Time.deltaTime);
            }

            //move towards center if near open gate
            if (isOpen == true)
            {
                if (Input.GetKey("s"))
                {
                    float step = (moveSpeed / 2) * Time.deltaTime; // calculate distance to move
                    transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, step);
                }
            }
        }
        else if (gameObject.tag == "Player2")
        {
            //move sideways
            if (Input.GetKey("k"))
            {
                transform.RotateAround(Vector3.zero, orbitAxis, moveSpeed * Time.deltaTime);
            }

            //move towards center if near open gate
            if (isOpen == true)
            {
                if (Input.GetKey("l"))
                {
                    float step = (moveSpeed / 5) * Time.deltaTime; // calculate distance to move
                    transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, step);
                }
            }
        }


    }

    //reverse the player's movement direction if they hit a blue wall
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "playerReverse")
        {
            orbitDir = -orbitDir;
            orbitAxis.Set(0, orbitDir, 0);
        }
    }

    //Check if player is near an open gate
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "openDetector")
        {
            isOpen = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "openDetector")
        {
            isOpen = false;
        }
    }
}
