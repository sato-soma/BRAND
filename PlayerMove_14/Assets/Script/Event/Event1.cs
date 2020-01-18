using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Event1 : MonoBehaviour
{
    public static bool Event_1Flag = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Event_1Flag == true)
        {
            if (PlayerState.EventEndFlag[1] == false)
            {
                if (Input.GetKeyDown(KeyCode.S) || Input.GetButton("Event"))
                {
                    SceneManager.LoadScene("event1");
                    PlayerState.EventEndFlag[1] = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Event_1Flag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Event_1Flag = false;
            Event1Image.StopTime1 = false;
        }
    }
}
