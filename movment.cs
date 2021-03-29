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
        /*

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(current +2 > locations.Length)
            {
                current = 0;
            }
            else
            {
                current++;
            }
            transform.position = (locations[current].position);
            transform.rotation = locations[current].rotation;
            
            for (int i = 0; i < locations.Length; i++)
            {
                if (gameObject.transform == locations[i])
                {
                    current = i;
                    break;
                }
            }
            transform.position = (locations[current + 1].position);
            
        }
        
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            transform.position += moveSpeed * new Vector3(Input.GetAxisRaw("Vertical")*-1, 0, 0);
        }
        */
        Vector3 rotation = transform.eulerAngles;
        
        rotation.y += Input.GetAxis("Horizontal") * -moveSpeed * Time.deltaTime; // Standart Left-/Right Arrows and A & D Keys
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
