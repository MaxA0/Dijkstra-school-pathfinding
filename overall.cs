using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class overall : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    public GameObject start_button;
    public GameObject canvas;

    public void begin()
    {
        StartCoroutine(GameObject.Find("nav").GetComponent<rewrite2>().MoveTo());
        start.SetActive(false);
        end.SetActive(false);
        canvas.SetActive(false);
    }

    public void start_selected()
    {
        start.SetActive(false);
        end.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene("main");
    }
}
