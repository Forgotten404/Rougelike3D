using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    // Start is called before the first frame update
 
        public Transform target;
        public float smoothSpeed = 0.1f;
        public Vector3 offset;
        public float turningSpeed = 50f;
        int degrees = 10;


    void Update()
    {

    }


    void LateUpdate()
    {
        Vector3 desiredPost = target.position + offset;
        Vector3 smoothPost = Vector3.Lerp(transform.position, desiredPost, smoothSpeed);
        transform.position = smoothPost;
       
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * turningSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.back * turningSpeed * Time.deltaTime);
        }

    }

}

