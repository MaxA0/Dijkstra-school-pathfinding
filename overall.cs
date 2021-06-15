using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class overall : MonoBehaviour
{
    public GameObject buildings;
    public GameObject start;
    public GameObject end;
    public GameObject start_button;
    public GameObject canvas;

    //starts the navigation system, makes it find the destination
    public void begin()
    {
        StartCoroutine(GameObject.Find("nav").GetComponent<rewrite2>().MoveTo());
        start.SetActive(false);
        end.SetActive(false);
        canvas.SetActive(false);
    }

    //opens the end screen
    public void start_selected()
    {
        start.SetActive(false);
        end.SetActive(true);
    }

    //reloads the program
    public void Reset()
    {
        SceneManager.LoadScene("main");
    }

    //hides and shows the buildings to see navigatin more clearly
    public void hideshow()
    {
        if (buildings.activeInHierarchy)
        {
            buildings.SetActive(false);
        }
        else
        {
            buildings.SetActive(true);
        }
        
    }
}
