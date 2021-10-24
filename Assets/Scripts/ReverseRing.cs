using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseRing : MonoBehaviour
{
    public RotatingRing getRing;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            getRing.direction = -getRing.direction;
            getRing.rotAxis.Set(0, getRing.direction, 0);
        }
    }
}
