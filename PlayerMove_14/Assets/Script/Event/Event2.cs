using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event2 : MonoBehaviour
{
    public static bool Event_2Flag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Event_2Flag);

        if (Event_2Flag == true)
        {
            if (PlayerState.EventEndFlag[2] == false)
            {
                if (Input.GetKeyDown(KeyCode.S) || Input.GetButton("Event"))
                {
                    SceneManager.LoadScene("event2");
                    PlayerState.EventEndFlag[2] = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Event_2Flag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Event_2Flag = false;
            Event2Image.StopTime2 = false;
        }
    }
}
