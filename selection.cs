using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selection : MonoBehaviour
{
    public Text selected;
    public GameObject art_building;
    public GameObject primary_building;
    public GameObject centre_building;
    public GameObject sec_building;
    public void select_building()
    {
        if(selected.text == "Art building")
        {
            art_building.SetActive(true);
            primary_building.SetActive(false);
            centre_building.SetActive(false);
            sec_building.SetActive(false);
        }
        else if (selected.text == "Primary building")
        {
            art_building.SetActive(false);
            primary_building.SetActive(true);
            centre_building.SetActive(false);
            sec_building.SetActive(false);
        }
        else if (selected.text == "Centre building")
        {
            art_building.SetActive(false);
            primary_building.SetActive(false);
            centre_building.SetActive(true);
            sec_building.SetActive(false);
        }
        else if (selected.text == "Secondary building")
        {
            art_building.SetActive(false);
            primary_building.SetActive(false);
            centre_building.SetActive(false);
            sec_building.SetActive(true);
        }
    }
}

// aware that making should only occur now and that i've been practicing