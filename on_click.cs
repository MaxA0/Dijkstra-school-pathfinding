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


    public void begin()
    {
        StartCoroutine(GameObject.Find("nav").GetComponent<rewrite2>().MoveTo());
        start.SetActive(false);
        end.SetActive(false);

    }

    public void startloca()
    {
        place plc = GameObject.Find(selected.text).GetComponent<place>();
        GameObject.Find("nav").GetComponent<rewrite2>().start_loc = plc;
        GameObject.Find("nav").GetComponent<Transform>().position = plc.coord;
        GameObject.Find("nav").GetComponent<TrailRenderer>().Clear();
        start.SetActive(false);
        end.SetActive(false);
    }
    /*

    public void endloc()
    {
        if(selected.text == "Female toilet")
        {
            GameObject.Find("nav").GetComponent<rewrite2>().closest_toilet();
        }
        else if(selected.text == "Male toilet")
        {
            GameObject.Find("nav").GetComponent<rewrite2>().closest_toilet();
        }
        else
        {
            place plc = GameObject.Find(selected.text).GetComponent<place>();
            GameObject.Find("nav").GetComponent<rewrite2>().go_to = plc;
        }
        button.SetActive(false);
    }*/
}
