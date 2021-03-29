using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drop : MonoBehaviour
{
    public List<string> listofitems = new List<string> { };
    public Dropdown drop_menu;
    public GameObject menu;
    public Text selected;
    private rewrite2 toiletting;

    void Start()
    {
        drop_menu.GetComponent<Dropdown>().AddOptions(listofitems);
    }

    public void startloca()
    {
        place plc = GameObject.Find(selected.text).GetComponent<place>();
        Debug.Log(plc);
        GameObject.Find("nav").GetComponent<rewrite2>().start_loc = plc;
        GameObject.Find("nav").GetComponent<Transform>().position = plc.coord;
        GameObject.Find("nav").GetComponent<TrailRenderer>().Clear();
        GameObject.Find("Canvas").GetComponent<overall>().start_selected();
    }

    public void endlocation()
    {
        if (selected.text == "F Toilet")
        {
            toiletting = GameObject.Find("nav").GetComponent<rewrite2>();
            toiletting.closest_toilet(toiletting.Ftoilets);
        }
        else if(selected.text == "M Toilet")
        {
            toiletting = GameObject.Find("nav").GetComponent<rewrite2>();
            toiletting.closest_toilet(toiletting.Mtoilets);
        }
        else
        {
            Debug.Log(selected.text);
            place plc = GameObject.Find(selected.text).GetComponent<place>();
            Debug.Log(plc);
            GameObject.Find("nav").GetComponent<rewrite2>().go_to = plc;
        }
    }
}

/*
public void endloc()
{
    place plc = GameObject.Find(selected.text).GetComponent<place>();
    GameObject.Find("nav").GetComponent<rewrite2>().go_to = plc;
    if (selected.text == "Female toilet")
    {
        GameObject.Find("nav").GetComponent<rewrite2>().closest_toilet();
    }
    else if (selected.text == "Male toilet")
    {
        GameObject.Find("nav").GetComponent<rewrite2>().closest_toilet();
    }*/