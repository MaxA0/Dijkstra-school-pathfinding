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

    //adds the options to the list of items (main menu)
    void Start()
    {
        drop_menu.GetComponent<Dropdown>().AddOptions(listofitems);
    }

    //assigns the start location to the navigation 
    public void startloca()
    {
        place plc = GameObject.Find(selected.text).GetComponent<place>();
        Debug.Log(plc);
        GameObject.Find("nav").GetComponent<rewrite2>().start_loc = plc;
        GameObject.Find("nav").GetComponent<Transform>().position = plc.coord;
        GameObject.Find("nav").GetComponent<TrailRenderer>().Clear();
        GameObject.Find("Canvas").GetComponent<overall>().start_selected();
    }
    // assigns the end locatino to the navigation
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
