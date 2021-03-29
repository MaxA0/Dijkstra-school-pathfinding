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

    public Vector3[] waypoints;
    public List<int> ignore = new List<int>();

    public place go_to;
    public place start_loc;

    public bool move;
    public Vector3 move_to;

    public Vector3 currentdest;

    public place[] Mtoilets;
    public place[] Ftoilets;

    public bool beginmove;

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
    public IEnumerator MoveTo()
    {
        if (go_to.building != start_loc.building)
        {
            if (go_to.building == "centre")
            {
                if (start_loc.building == "sec")
                {
                    if (start_loc.floor != 2)
                    {
                        targetassign(secondary[start_loc.floor]);
                        currentdest = waypoints[0];
                        while (move_to != waypoints[0])
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        targetassign(secondary[2]);
                        transform.position = waypoints[0];
                        ignore.Clear();
                    }

                    // go to front of sec building
                    targetassign(secondary[2]);
                    currentdest = waypoints[1];
                    while (move_to != waypoints[1])
                    {
                        closest();
                        yield return new WaitForSeconds(0.1f);
                        transform.position = move_to;
                    }
                    yield return new WaitForSeconds(0.1f);
                    ignore.Clear();

                    if (go_to.floor == 2)
                    {
                        targetassign(mainbuilding[1]);
                        currentdest = waypoints[1];
                        while (move_to != waypoints[1])
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        targetassign(centre[go_to.floor]);
                        transform.position = waypoints[0];
                        ignore.Clear();
                        currentdest = go_to.coord;
                        while (move_to != go_to.coord)
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        ignore.Clear();
                    }
                }
                if (start_loc.building == "main")
                {
                    if (start_loc.floor == 0 || start_loc.floor == 1)
                    {
                        targetassign(mainbuilding[start_loc.floor]);
                        currentdest = waypoints[0];
                        while (move_to != waypoints[0])
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        targetassign(mainbuilding[go_to.floor]);
                        transform.position = waypoints[0];
                        ignore.Clear();
                        currentdest = go_to.coord;
                        while (move_to != waypoints[0])
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        ignore.Clear();
                    }
                    else
                    {
                        targetassign(mainbuilding[start_loc.floor]);
                        currentdest = waypoints[0];
                        while (move_to != waypoints[0])
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        targetassign(mainbuilding[1]);
                        transform.position = waypoints[0];
                        ignore.Clear();
                        currentdest = waypoints[1];
                        while (move_to != waypoints[1])
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        targetassign(centre[2]);
                        transform.position = waypoints[0];
                        ignore.Clear();
                        currentdest = go_to.coord;
                        while (move_to != go_to.coord)
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        ignore.Clear();
                    }
                }
            }

            if (go_to.building == "main")
            {
                if (start_loc.building == "sec")
                {
                    if (start_loc.floor != 2)
                    {
                        targetassign(secondary[start_loc.floor]);
                        currentdest = waypoints[0];
                        while (move_to != waypoints[0])
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        targetassign(secondary[2]);
                        transform.position = waypoints[0];
                        ignore.Clear();
                    }

                    // go to front of sec building
                    targetassign(secondary[2]);
                    currentdest = waypoints[1];
                    while (move_to != waypoints[1])
                    {
                        closest();
                        yield return new WaitForSeconds(0.1f);
                        transform.position = move_to;
                    }
                    yield return new WaitForSeconds(0.1f);
                    ignore.Clear();



                    if (go_to.floor == 1)
                    {
                        targetassign(mainbuilding[go_to.floor]);
                        currentdest = go_to.coord;
                        while (move_to != go_to.coord)
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        transform.position = go_to.coord;
                        ignore.Clear();
                    }
                    else if (go_to.floor == 0)
                    {
                        targetassign(mainbuilding[1]);
                        currentdest = waypoints[1];
                        while (move_to != waypoints[1])
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        targetassign(mainbuilding[go_to.floor]);
                        transform.position = waypoints[1];
                        ignore.Clear();
                        currentdest = go_to.coord;
                        while (move_to != go_to.coord)
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        ignore.Clear();
                    }
                    else if (go_to.floor > 1)
                    {
                        targetassign(mainbuilding[1]);
                        currentdest = waypoints[0];
                        while (move_to != waypoints[0])
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        transform.position = waypoints[0];

                        targetassign(mainbuilding[go_to.floor]);
                        transform.position = waypoints[0];
                        ignore.Clear();
                        currentdest = go_to.coord;
                        while (move_to != go_to.coord)
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        ignore.Clear();
                    }

                    if (start_loc.building == "centre")
                    {
                        targetassign(centre[2]);
                        currentdest = waypoints[0];
                        while (move_to != waypoints[0])
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        transform.position = waypoints[0];
                        targetassign(mainbuilding[1]);
                        ignore.Clear();
                        transform.position = waypoints[1];

                        if (go_to.floor == 1)
                        {
                            currentdest = go_to.coord;
                            while (move_to != go_to.coord)
                            {
                                closest();
                                yield return new WaitForSeconds(0.1f);
                                transform.position = move_to;
                            }
                            ignore.Clear();
                        }
                        else
                        {
                            currentdest = waypoints[0];
                            while (move_to != waypoints[0])
                            {
                                closest();
                                yield return new WaitForSeconds(0.1f);
                                transform.position = move_to;
                            }
                            ignore.Clear();
                            targetassign(mainbuilding[go_to.floor]);
                            transform.position = waypoints[0];

                            currentdest = go_to.coord;
                            while (move_to != go_to.coord)
                            {
                                closest();
                                yield return new WaitForSeconds(0.1f);
                                transform.position = move_to;
                            }
                            ignore.Clear();

                            currentdest = waypoints[0];
                        }
                    }

                }
        
                if (go_to.building == "sec")
                {
                    if(start_loc.building == "center")
                    {
                        targetassign(centre[2]);
                        currentdest = waypoints[0];
                        while (move_to != waypoints[0])
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        transform.position = waypoints[0];
                        targetassign(mainbuilding[1]);
                        ignore.Clear();
                        transform.position = waypoints[1];


                        currentdest = waypoints[3];
                        while (move_to != waypoints[3])
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        ignore.Clear();

                        if (go_to.floor == 2)
                        {
                            targetassign(secondary[2]);
                            currentdest = go_to.coord;
                            while (move_to != go_to.coord)
                            {
                                closest();
                                yield return new WaitForSeconds(0.1f);
                                transform.position = move_to;
                            }
                            ignore.Clear();
                        }
                        else
                        {
                            targetassign(secondary[2]);
                            currentdest = waypoints[0];
                            while (move_to != waypoints[0])
                            {
                                closest();
                                yield return new WaitForSeconds(0.1f);
                                transform.position = move_to;
                            }
                            transform.position = waypoints[0];
                            ignore.Clear();

                            targetassign(secondary[go_to.floor]);
                            transform.position = waypoints[0];

                            currentdest = go_to.coord;
                            while (move_to != go_to.coord)
                            {
                                closest();
                                yield return new WaitForSeconds(0.1f);
                                transform.position = move_to;
                            }
                            transform.position = go_to.coord;
                        }
                    }
                }

                if (start_loc.building == "main")
                {
                    targetassign(secondary[start_loc.floor]);
                    currentdest = waypoints[0];
                    while (move_to != waypoints[0])
                    {
                        closest();
                        yield return new WaitForSeconds(0.1f);
                        transform.position = move_to;
                    }
                    transform.position = waypoints[0];
                    ignore.Clear();


                    targetassign(secondary[1]);
                    transform.position = waypoints[0];
                    currentdest = waypoints[3];
                    while (move_to != waypoints[3])
                    {
                        closest();
                        yield return new WaitForSeconds(0.1f);
                        transform.position = move_to;
                    }
                    transform.position = waypoints[3];
                    ignore.Clear();

                    if (go_to.floor == 2)
                    {
                        targetassign(secondary[2]);
                        currentdest = go_to.coord;
                        while (move_to != go_to.coord)
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        ignore.Clear();
                    }
                    else
                    {
                        targetassign(secondary[2]);
                        currentdest = waypoints[0];
                        while (move_to != waypoints[0])
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        transform.position = waypoints[0];
                        ignore.Clear();

                        targetassign(secondary[go_to.floor]);
                        transform.position = waypoints[0];

                        currentdest = go_to.coord;
                        while (move_to != go_to.coord)
                        {
                            closest();
                            yield return new WaitForSeconds(0.1f);
                            transform.position = move_to;
                        }
                        transform.position = go_to.coord;
                    }

                }
            }
        }
        if(go_to.building == start_loc.building)
        {
            if(go_to.building == "main")
            {
                if(go_to.floor != start_loc.floor)
                {
                    targetassign(mainbuilding[start_loc.floor]);
                    currentdest = waypoints[0];
                    while (move_to != waypoints[0])
                    {
                        closest();
                        yield return new WaitForSeconds(0.1f);
                        transform.position = move_to;
                    }
                    yield return new WaitForSeconds(0.1f);
                    targetassign(mainbuilding[go_to.floor]);
                    transform.position = waypoints[0];
                    ignore.Clear();

                    currentdest = go_to.coord;
                    while (move_to != go_to.coord)
                    {
                        closest();
                        yield return new WaitForSeconds(0.1f);
                        transform.position = move_to;
                    }
                    transform.position = go_to.coord;
                    ignore.Clear();
                }
                else
                {
                    targetassign(mainbuilding[start_loc.floor]);
                    currentdest = go_to.coord;
                    while (move_to != go_to.coord)
                    {
                        closest();
                        yield return new WaitForSeconds(0.1f);
                        transform.position = move_to;
                    }
                    transform.position = go_to.coord;
                    ignore.Clear();
                }
            }
            if (go_to.building == "centre")
            {
                targetassign(centre[start_loc.floor]);
                currentdest = go_to.coord;
                while (move_to != go_to.coord)
                {
                    closest();
                    yield return new WaitForSeconds(0.1f);
                    transform.position = move_to;
                }
                transform.position = go_to.coord;
                ignore.Clear();
            }
            if (go_to.building == "sec")
            {
                if (go_to.floor != start_loc.floor)
                {
                    targetassign(secondary[start_loc.floor]);
                    currentdest = waypoints[0];
                    while (move_to != waypoints[0])
                    {
                        closest();
                        yield return new WaitForSeconds(0.1f);
                        transform.position = move_to;
                    }
                    yield return new WaitForSeconds(0.1f);
                    transform.position = waypoints[0];
                    ignore.Clear();

                    targetassign(mainbuilding[go_to.floor]);
                    transform.position = waypoints[0];

                    currentdest = go_to.coord;
                    while (move_to != go_to.coord)
                    {
                        closest();
                        yield return new WaitForSeconds(0.1f);
                        transform.position = move_to;
                    }
                    yield return new WaitForSeconds(0.1f);
                    transform.position = go_to.coord;
                    ignore.Clear();
                }
                else
                {
                    targetassign(mainbuilding[go_to.floor]);
                    currentdest = go_to.coord;
                    while (move_to != go_to.coord)
                    {
                        closest();
                        yield return new WaitForSeconds(0.1f);
                        transform.position = move_to;
                    }
                    yield return new WaitForSeconds(0.1f);
                    transform.position = go_to.coord;
                    ignore.Clear();
                }
            }
        }
    }

    public void targetassign(GameObject holder)
    {
        Array.Resize(ref waypoints, holder.transform.childCount);
        for (int i = 0; i < holder.transform.childCount; i++)
        {
            waypoints[i] = holder.transform.GetChild(i).transform.position;
        }
    }

    public void closest()
    {
        if (transform.position != currentdest)
        {
            float hcost = cost(currentdest);
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

    public float cost(Vector3 node)
    {
        float x;
        float y;

        x = Mathf.Abs(node[0] - gameObject.transform.position.x);
        y = Mathf.Abs(node[2] - gameObject.transform.position.z);

        return Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
    }
}
