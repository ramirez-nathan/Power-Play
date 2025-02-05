using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControllers : MonoBehaviour
{
    private float startPos;
    public GameObject cam;
    public float parallaxEffect; //The speed at which the background should move relative to the camera

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("PlayerCamera");
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cam = GameObject.FindGameObjectWithTag("PlayerCamera");

        //Calculate distance background should move based on cam movement
        float distance = cam.transform.position.x * parallaxEffect; // 0 = move with cam || 1 = won't move || 0.5 = half

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    
    
    }
}
