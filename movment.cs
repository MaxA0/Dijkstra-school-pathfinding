using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    public Transform[] locations;

    public float moveSpeed = 0.5f;
    public float scrollSpeed = 3;
    public int current = 0;
    public Camera cam;

    float MouseZoomSpeed = 15.0f;
    float ZoomMinBound = 0.1f;
    float ZoomMaxBound = 179.9f;

    void Update()
    {
        //movement scripts for the user
        Vector3 rotation = transform.eulerAngles;
        
        rotation.y += Input.GetAxis("Horizontal") * -moveSpeed * Time.deltaTime; // Standard Left-/Right Arrows and A & D Keys
        transform.eulerAngles = rotation;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Zoom(scroll, MouseZoomSpeed);

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position += scrollSpeed * new Vector3(0, Input.GetAxis("Vertical"), 0);
        }
        void Zoom(float deltaMagnitudeDiff, float speed)
        {
            cam.fieldOfView += deltaMagnitudeDiff * speed;
            // set min and max value of Clamp function upon your requirement
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, ZoomMinBound, ZoomMaxBound);
        }
    }

}

