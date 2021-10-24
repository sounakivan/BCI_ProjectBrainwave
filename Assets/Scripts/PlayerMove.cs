using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float orbitSpeed = 5;
    private Vector3 orbitAxis;
    private int orbitDir = -1;
    private Vector3 playerPos;
    
    // Start is called before the first frame update
    void Start()
    {
        orbitAxis.Set(0, orbitDir, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            transform.RotateAround(Vector3.zero, orbitAxis, orbitSpeed * Time.deltaTime);
        }

        if (Input.GetKey("b"))
        {
            print("will move towards soon");
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
}
