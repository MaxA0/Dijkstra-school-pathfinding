using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class rewrite2 : MonoBehaviour
{
    //waypoints
    public GameObject[] mainbuilding;
    public GameObject[] centre;
    public GameObject[] secondary;

    public place[] Mtoilets;
    public place[] Ftoilets;

    public Vector3[] waypoints;
    public List<int> ignore = new List<int>();

    //start and end locations
    public place go_to;
    public place start_loc;
    //location nav should move to next
    public bool move;
    public Vector3 move_to;
    public Vector3 current_target;


    //to find the closes toilet
    public void closest_toilet(place[] toilets)
    {
        float smallest = cost(toilets[0].coord);
        place closest = toilets[0];

        for (int i = 0; i < waypoints.Length; i++)
        {
            float temp = cost(toilets[i].coord);
            if (temp < smallest)
            {
                smallest = temp;
                closest = toilets[i];
            }
        }
        go_to = closest;
        Debug.Log(closest.coord);
    }
    //Algorithm which assigns staircases to go to and to move to the destination
    public IEnumerator MoveTo()
    {
        //if statement if the locations are not in the same building
        if (go_to.building != start_loc.building)
        {
            //if the location is in the centre
            if (go_to.building == "centre")
            {
                if (start_loc.building == "sec")
                {
                    if (start_loc.floor != 2)
                    {
                        targetassign(secondary[start_loc.floor]);
                        StartCoroutine(moveish(waypoints[0]));
                    }
                    yield return new WaitForSeconds(2f);
                    targetassign(secondary[2]);
                    transform.position = waypoints[0];
                    StartCoroutine(moveish(waypoints[0]));

                    yield return new WaitForSeconds(2f);
                    targetassign(mainbuilding[1]);
                    transform.position = waypoints[3];
                    StartCoroutine(moveish(waypoints[1]));

                    yield return new WaitForSeconds(2f);
                    targetassign(centre[2]);
                    transform.position = waypoints[1];
                    StartCoroutine(moveish(go_to.coord));
                }
                if ((start_loc.building == "main") && (start_loc.middle == true))
                {
                    targetassign(mainbuilding[start_loc.floor]);
                    StartCoroutine(moveish(waypoints[1]));
                    yield return new WaitForSeconds(2f);

                    targetassign(centre[2]);
                    transform.position = waypoints[1];

                    yield return new WaitForSeconds(2f);
                    targetassign(centre[2]);
                    transform.position = waypoints[1];
                    StartCoroutine(moveish(go_to.coord));
                }
                else if ((start_loc.building == "main") && (start_loc.middle == false))
                {
                    if (start_loc.floor < 2)
                    {
                        targetassign(mainbuilding[start_loc.floor]);
                        StartCoroutine(moveish(waypoints[1]));

                        yield return new WaitForSeconds(2f);
                        targetassign(centre[2]);
                        transform.position = waypoints[1];
                        yield return new WaitForSeconds(2f);
                        StartCoroutine(moveish(go_to.coord));
                    }
                    else if (start_loc.floor >= 2)
                    {
                        targetassign(mainbuilding[start_loc.floor]);
                        StartCoroutine(moveish(waypoints[0]));

                        yield return new WaitForSeconds(2f);
                        targetassign(mainbuilding[0]);
                        transform.position = waypoints[0];
                        StartCoroutine(moveish(waypoints[1]));

                        yield return new WaitForSeconds(2f);
                        targetassign(centre[2]);
                        transform.position = waypoints[1];
                        yield return new WaitForSeconds(2f);
                        StartCoroutine(moveish(go_to.coord));
                    }
                    
                }
            }
            //if the location is in the main building
            if (go_to.building == "main")
            {
                if (start_loc.building == "sec")
                {
                    if (start_loc.floor != 2)
                    {
                        targetassign(secondary[start_loc.floor]);
                        StartCoroutine(moveish(waypoints[0]));
                        yield return new WaitForSeconds(2f);
                    }
                    targetassign(secondary[2]);
                    StartCoroutine(moveish(waypoints[1]));
                    yield return new WaitForSeconds(2f);

                    if (go_to.floor == 1)
                    {
                        targetassign(mainbuilding[go_to.floor]);
                        StartCoroutine(moveish(go_to.coord));
                    }
                    else if (go_to.floor == 0)
                    {
                        targetassign(mainbuilding[1]);
                        StartCoroutine(moveish(waypoints[1]));
                        yield return new WaitForSeconds(2f);

                        targetassign(mainbuilding[go_to.floor]);
                        transform.position = waypoints[1];
                        yield return new WaitForSeconds(2f);
                        StartCoroutine(moveish(go_to.coord));

                    }
                    else if (go_to.floor > 1)
                    {
                        targetassign(mainbuilding[1]);
                        StartCoroutine(moveish(waypoints[0]));
                        yield return new WaitForSeconds(7f);

                        targetassign(mainbuilding[go_to.floor]);
                        transform.position = waypoints[0];
                        StartCoroutine(moveish(go_to.coord));
                    }
                }

                if ((start_loc.building == "centre"))
                {
                    targetassign(centre[2]);
                    StartCoroutine(moveish(waypoints[1]));
                    yield return new WaitForSeconds(2f);

                    if (go_to.floor < 2)
                    {
                        targetassign(mainbuilding[go_to.floor]);
                        transform.position = (waypoints[1]);
                        yield return new WaitForSeconds(2f);
                        StartCoroutine(moveish(go_to.coord));
                    }
                    else if (go_to.floor >= 2)
                    {
                        targetassign(mainbuilding[1]);
                        StartCoroutine(moveish(waypoints[0]));
                        yield return new WaitForSeconds(5f);

                        targetassign(mainbuilding[go_to.floor]);
                        StartCoroutine(moveish(go_to.coord));
                    }
                }
            }
            //if the location is in the secondary building
            if (go_to.building == "sec")
            {
                if (start_loc.building == "centre")
                {
                    targetassign(centre[2]);
                    StartCoroutine(moveish(waypoints[1]));
                    yield return new WaitForSeconds(2f);

                    targetassign(mainbuilding[1]);
                    transform.position = waypoints[1];
                    yield return new WaitForSeconds(2f);
                    StartCoroutine(moveish(waypoints[3]));
                    yield return new WaitForSeconds(2f);
                }

                if ((start_loc.building == "main"))
                {
                    if (start_loc.floor == 1)
                    {
                        targetassign(mainbuilding[start_loc.floor]);
                        StartCoroutine(moveish(waypoints[3]));
                        yield return new WaitForSeconds(5f);
                    }
                    else if (start_loc.floor == 0)
                    {
                        targetassign(mainbuilding[0]);
                        StartCoroutine(moveish(waypoints[1]));
                        yield return new WaitForSeconds(2f);

                        targetassign(mainbuilding[1]);
                        transform.position = waypoints[1];
                        yield return new WaitForSeconds(2f);

                        StartCoroutine(moveish(waypoints[3]));
                        yield return new WaitForSeconds(5f);
                    }
                    else if (start_loc.floor >= 2)
                    {
                        targetassign(mainbuilding[start_loc.floor]);
                        StartCoroutine(moveish(waypoints[0]));
                        yield return new WaitForSeconds(2f);

                        targetassign(centre[1]);
                        transform.position = waypoints[0];
                        yield return new WaitForSeconds(2f);

                        StartCoroutine(moveish(waypoints[3]));
                        yield return new WaitForSeconds(5f);
                    }

                    if (go_to.floor == 2)
                    {
                        targetassign(secondary[2]);
                        StartCoroutine(moveish(go_to.coord));
                        yield return new WaitForSeconds(2f);
                    }
                    else
                    {
                        targetassign(secondary[2]);
                        StartCoroutine(moveish(waypoints[0]));
                        yield return new WaitForSeconds(2f);

                        targetassign(secondary[go_to.floor]);
                        transform.position = waypoints[0];
                        StartCoroutine(moveish(go_to.coord));
                    }
                }
                }
        }
        //if the locations are in the same building
        if (go_to.building == start_loc.building)
        {
            // if the locations are in the main building
            if (go_to.building == "main")
            {
                if(start_loc.middle == true && go_to.middle == true)
                {
                    targetassign(mainbuilding[start_loc.floor]);
                    StartCoroutine(moveish(waypoints[1]));
                    yield return new WaitForSeconds(2f);

                    targetassign(mainbuilding[go_to.floor]);
                    transform.position = waypoints[1];
                    StartCoroutine(moveish(go_to.coord));
                }
                else
                {
                    if (go_to.floor != start_loc.floor)
                    {
                        targetassign(mainbuilding[start_loc.floor]);
                        StartCoroutine(moveish(waypoints[0]));
                        targetassign(mainbuilding[go_to.floor]);
                        transform.position = waypoints[0];

                        StartCoroutine(moveish(go_to.coord));
                    }
                    else
                    {
                        targetassign(mainbuilding[start_loc.floor]);
                        StartCoroutine(moveish(go_to.coord));
                        transform.position = go_to.coord;
                    }
                }
                
            }
            //if the locations are in the centre building
            if (go_to.building == "centre")
            {
                targetassign(centre[start_loc.floor]);
                StartCoroutine(moveish(go_to.coord));
            }
            // if the locations are in the secondary building
            if (go_to.building == "sec")
            {
                if (go_to.floor != start_loc.floor)
                {
                    targetassign(secondary[start_loc.floor]);
                    StartCoroutine(moveish(waypoints[0]));
                    yield return new WaitForSeconds(0.1f);
                    transform.position = waypoints[0];
                    ignore.Clear();

                    targetassign(secondary[go_to.floor]);
                    transform.position = waypoints[0];

                    StartCoroutine(moveish(go_to.coord));
                    yield return new WaitForSeconds(0.1f);
                    transform.position = go_to.coord;
                }
                else
                {
                    targetassign(secondary[go_to.floor]);
                    StartCoroutine(moveish(go_to.coord));
                    yield return new WaitForSeconds(0.1f);
                    transform.position = go_to.coord;
                }
            }
        }
    }

    //algorithm to get to the current target assigned
    public IEnumerator moveish(Vector3 coord)
    {
        current_target = coord;
        ignore.Clear();
        closest();
        while (move_to != coord)
        {
            closest();
            yield return new WaitForSeconds(0.1f);
            transform.position = move_to;
        }
        yield return new WaitForSeconds(0.1f);
        transform.position = move_to;
        ignore.Clear();
    }

    //reassigns new waypoints to the waypoints array
    public void targetassign(GameObject holder)
    {
        Array.Resize(ref waypoints, holder.transform.childCount);
        for (int i = 0; i < holder.transform.childCount; i++)
        {
            waypoints[i] = holder.transform.GetChild(i).transform.position;
        }
    }

    // finds the closest node using the dijkstra algorithm by calculating h cost, g cost and f cost
    public void closest()
    {
        if (transform.position != current_target)
        {
            float hcost = cost(current_target);
            float smallest = 1000;
            int pos = 0;
            for (int i = 0; i < waypoints.Length; i++)
            {
                float x = (Mathf.Abs(waypoints[i][0] - transform.position[0]));
                float y = (Mathf.Abs(waypoints[i][2] - transform.position[2]));
                if ((hcost + cost(waypoints[i]) < smallest) && (Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2)) < 25))
                {
                    if (!ignore.Contains(i))
                    {
                        smallest = hcost + cost(waypoints[i]);
                        pos = i;
                    }
                }
            }
            move_to = waypoints[pos];
            ignore.Add(pos);
        }
    }

    //find the cost of the position passed into the subroutine
    public float cost(Vector3 node)
    {
        float x;
        float y;

        x = Mathf.Abs(node[0] - gameObject.transform.position.x);
        y = Mathf.Abs(node[2] - gameObject.transform.position.z);

        return Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
    }
}

