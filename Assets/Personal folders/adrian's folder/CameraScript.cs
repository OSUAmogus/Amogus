using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0.0f, 1.0f) > 0.98f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1.0f);
        }
        else {

            transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
        }
    }
}
