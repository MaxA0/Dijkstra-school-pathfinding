using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class on_click : MonoBehaviour
{
    public Text selected;
    public GameObject start;
    public GameObject end;
    public GameObject button;

    //hides the objects on the screen when user presses start
    public void begin()
    {
        StartCoroutine(GameObject.Find("nav").GetComponent<rewrite2>().MoveTo());
        start.SetActive(false);
        end.SetActive(false);

    }

    //assigns all the start locations and end locations to the rewrite2 script
    public void startloca()
    {
        place plc = GameObject.Find(selected.text).GetComponent<place>();
        GameObject.Find("nav").GetComponent<rewrite2>().start_loc = plc;
        GameObject.Find("nav").GetComponent<Transform>().position = plc.coord;
        GameObject.Find("nav").GetComponent<TrailRenderer>().Clear();
        start.SetActive(false);
        end.SetActive(false);
    }
}

