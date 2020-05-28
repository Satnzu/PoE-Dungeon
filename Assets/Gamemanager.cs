using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public GameObject menu;
    public bool pause;
    public GameObject dragon;
    public GameObject player;

    private void Start()
    {
        menu.SetActive(false);
        dragon.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == true)
            {
                menu.SetActive(false);
                pause = false;
            }
            else
            {
                menu.SetActive(true);
                pause = true;
            }
        }       
    }

    public void ButtonPress(Button button)
    {

    }
}
