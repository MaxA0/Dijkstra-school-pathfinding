using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class place : MonoBehaviour
{
    public Transform waypoint;
    public Vector3 coord;
    public string building;
    public int floor;


    private void Start()
    {
        coord = waypoint.transform.position;
    }
}
