using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event3 : MonoBehaviour
{
    public static bool Event_3Flag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Event_3Flag == true)
        {
            if (PlayerState.EventEndFlag[3] == false)
            {
                if (Input.GetKeyDown(KeyCode.S) || Input.GetButton("Event"))
                {
                    SceneManager.LoadScene("event3");
                    PlayerState.EventEndFlag[3] = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Event_3Flag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Event_3Flag = false;
            Event3Image.StopTime3 = false;
        }
    }
}
